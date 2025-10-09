using Healt_Clinict.obj.Models;
using Healt_Clinict.Utils;
using Healt_Clinict.database;

namespace Healt_Clinict.Services;

public class PetServices


{
    PetRepository petRepository = new PetRepository();
    public Pet RegisterPet()
    {
        VisualInterface.Interface("Register Pet");
        Console.WriteLine("Enter the pet's name: ");
        string name = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the type of animal: ");
        string typeAnimal = Console.ReadLine() ?? "";

        Console.WriteLine("Sex of the animal: ");
        string sex = Console.ReadLine() ?? "";

        int age = -1; // Inicializamos en un valor negativo para entrar en el ciclo

        // Validación de la edad
        while (age < 0)
        {
            try
            {
                Console.WriteLine("Write patient age:");
                age = int.Parse(Console.ReadLine() ?? "");

                if (age < 0)
                {
                    Console.WriteLine("Age must be a positive number. Please enter a valid age.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }

        Console.WriteLine("Enter the color of the animal: ");
        string color = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the weight of the animal: ");
        string weight = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the symptoms of the animal: ");
        string symptoms = Console.ReadLine() ?? "";


        // Crear usando el constructor que requiere parámetros
        Pet newPet = new Pet(name, typeAnimal, sex, age, color, weight, symptoms);


        // devolver la mascota para que el llamador la asigne al cliente
        return newPet;


    }


    //----------------------------------------------------------------------

    public void Registeronlypet()
    {
        VisualInterface.Interface("Register Pet");
        Console.WriteLine("Write the identification number (document number) to which the pet belongs:");
        string idNumber = Console.ReadLine() ?? "";
        Console.WriteLine("Write the name of the pet owner (name, last name or full name): ");
        string ownerName = Console.ReadLine() ?? "";

        // Buscar cliente que coincida en id y en nombre (Name o LastName o "Name LastName")
        var customer = Warehouse.customers.FirstOrDefault(c =>
            !string.IsNullOrEmpty(c.NumberDocument) &&
            c.NumberDocument.Equals(idNumber, StringComparison.OrdinalIgnoreCase) &&
            (
                c.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Equals(ownerName, StringComparison.OrdinalIgnoreCase) ||
                $"{c.Name} {c.LastName}".Equals(ownerName, StringComparison.OrdinalIgnoreCase)
            )
        );

        // Verificar si se encontró el cliente
        if (customer == null)
        {
            Console.WriteLine("No customer found with that ID and name. Please verify the details or create a new one first.");
            return;  // Salir si no se encuentra el cliente
        }

        // Registrar la nueva mascota
        Pet newPet = RegisterPet();  // Llamamos al método RegisterPet()

        // Asignar el dueño (customer) a la mascota
        newPet.Owner = customer;

        // Agregar la nueva mascota a la lista de mascotas del cliente
        customer.Pets.Add(newPet);

        Console.WriteLine("Pet registered and associated with the client correctly.");

        // Devolver al menú o continuar con la lógica posterior
        ServicesValidation.ReturnToMenu();
    }


    //--------------------------------------------------------------------------------------------------------------------------------------------
    public void FilterPetType()
    {
        VisualInterface.Interface("Filter Pets by Type");

        // Mostrar los tipos únicos
        Console.WriteLine("Types of registered animals:");
        foreach (var pet in Warehouse.customers.SelectMany(c => c.Pets).DistinctBy(p => p.TypeAnimal))
        {
            Console.WriteLine($"- {pet.TypeAnimal}");
        }

        Console.WriteLine("Enter the type of animal to filter: ");
        string typeAnimal = Console.ReadLine() ?? "";

        // Filtrar y mostrar todas las mascotas de ese tipo
        var filteredPets = Warehouse.customers
            .SelectMany(c => c.Pets)
            .Where(p => p.TypeAnimal.Equals(typeAnimal, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"\nPets of type '{typeAnimal}':");
        foreach (var pet in filteredPets)
        {
            
            Console.WriteLine($"- Name: {pet.Name} | ({pet.Age} years old) | Symptoms: ({pet.Symptoms}), Owner: {pet.Owner.Name} {pet.Owner.LastName} ");
        }
        Console.WriteLine("--------------------------------------------");
        ServicesValidation.ReturnToMenu();

    }
    //-------------------------------------------------------------------------------------------------------------------------
    public void FilterPetAgeMoreless()
    {
        VisualInterface.Interface("Filter Pets by Age");

        var sortedPets = Warehouse.customers
            .SelectMany(c => c.Pets)
            .OrderByDescending(p => p.Age); // mayor a menor

        Console.WriteLine("Pets from oldest to youngest:");
        foreach (var pet in sortedPets)
        {
            Console.WriteLine($"- {pet.Age} years old,| Name: {pet.Name} |Type: ({pet.TypeAnimal}),  Owner: {pet.Owner.Name}");
        }
        ServicesValidation.ReturnToMenu();
    }
    //-----------------------------------------------------------------------------------------------------------

    public void FilterPetAlfabeticName()
    {
        VisualInterface.Interface("Filter Pets by Name (Alphabetically)");

        var sortedPets = Warehouse.customers
            .SelectMany(c => c.Pets)
            .OrderBy(p => p.Name); // Ordenar alfabéticamente por nombre

        Console.WriteLine("Pets sorted alphabetically by name:");
        foreach (var pet in sortedPets)
        {
            Console.WriteLine($"- Name: {pet.Name} | Type: ({pet.TypeAnimal}), Age: ({pet.Age} years old), Owner: {pet.Owner.Name}");
        }
        Console.WriteLine("--------------------------------------------");
        ServicesValidation.ReturnToMenu();
    }

    //-------------------------------------------------------------------------------------------------------------------

    public void ShowAllPets()
    {
        VisualInterface.Interface("All Registered Pets");

        // Obtenemos todas las mascotas de todos los clientes
        var allPets = Warehouse.customers
            .SelectMany(c => c.Pets);


        if (!allPets.Any())
        {
            VisualInterface.RedColor("[X]No pets registered. (*-*) ");
            return;
        }

        Console.WriteLine("List of all registered pets:");


        foreach (var pet in allPets)
        {
            pet.ShowAllAnimals();
        }

        Console.WriteLine("------------------------------------------------");
        ServicesValidation.ReturnToMenu();
    }


    public void DeletePet()
    {
        VisualInterface.Interface("Delete Pet");

        Console.WriteLine("Enter the name of the pet to delete:");
        string petName = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the document number of the pet owner:");
        string ownerDocument = Console.ReadLine() ?? "";

        foreach (var customer in Warehouse.customers)
        {
            if (customer.NumberDocument.Equals(ownerDocument, StringComparison.OrdinalIgnoreCase))
            {
                var petToRemove = customer.Pets.FirstOrDefault(p => p.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));
                if (petToRemove != null)
                {
                    petRepository.Delete(petToRemove);
                    VisualInterface.GreenColor($"Pet '{petName}' removed successfully.");
                }
                else
                {
                    VisualInterface.RedColor($" [X]No pet named '{petName}' found for this owner. (-_*)");
                    ServicesValidation.ReturnToMenu();
                }
                Console.WriteLine("--------------------------------------------");
                ServicesValidation.ReturnToMenu();
                return;
            }
        }

    }    //------------------------------------------------------------------------------------------------------------------------------------


    public void UpdatePet()
    {
        VisualInterface.Interface("Update Pet");

        Console.WriteLine("Enter the name of the pet to update:");
        string petName = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the document number of the pet owner:");
        string ownerDocument = Console.ReadLine() ?? "";

        foreach (var customer in Warehouse.customers)
        {
            if (customer.NumberDocument.Equals(ownerDocument, StringComparison.OrdinalIgnoreCase))
            {
                var petToUpdate = customer.Pets.FirstOrDefault(p => p.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));
                if (petToUpdate != null)
                {
                    Console.WriteLine("Enter new details for the pet (leave blank to keep current value):");

                    Console.WriteLine($"Current Name: {petToUpdate.Name}. New Name:");
                    string newName = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newName)) petToUpdate.Name = newName;

                    Console.WriteLine($"Current Type: {petToUpdate.TypeAnimal}. New Type:");
                    string newType = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newType)) petToUpdate.TypeAnimal = newType;

                    Console.WriteLine($"Current Age: {petToUpdate.Age}. New Age:");
                    string newAge = Console.ReadLine() ?? "";
                    if (int.TryParse(newAge, out int age))
                    {
                        petToUpdate.Age = age;
                    }

                    Console.WriteLine($"Pet '{petName}' updated successfully.");
                }
                else
                {
                    VisualInterface.RedColor($" [X] No pet named '{petName}' found for this owner (-_*).");
                    ServicesValidation.ReturnToMenu();

                }
                Console.WriteLine("--------------------------------------------");
                 ServicesValidation.ReturnToMenu();
                return;
            }
        }

    }
}




