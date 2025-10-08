
using Healt_Clinict.database;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
using Healt_Clinict.repository;
using Healt_Clinict.Utils;



public  class PetRepository
    {
    Customer customer = new Customer();


    public static void Register(Pet newPet)
    {
        Warehouse.customers.ForEach(c => c.Pets.Add(newPet));

    }
   



    //--------------------------------------------------------------------------------------------------------------------
    // FILTRADOS----------------------------------


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

    }

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
    }


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
    }

    public void ShowAllPets()
    {
        VisualInterface.Interface("All Registered Pets");

        var allPets = Warehouse.customers
            .SelectMany(c => c.Pets);

        if (!allPets.Any())
        {
            Console.WriteLine("No pets registered.");
            return;
            
        }

        Console.WriteLine("List of all registered pets:");
        foreach (var pet in allPets)
        {
            Console.WriteLine($"- Name: {pet.Name} | Type: ({pet.TypeAnimal}), Age: ({pet.Age} years old), Owner: {pet.Owner.Name} {pet.Owner.NumberDocument}");
        }
        Console.WriteLine("------------------------------------------------");
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
                    customer.Pets.Remove(petToRemove);
                    Console.WriteLine($"Pet '{petName}' removed successfully.");
                }
                else
                {
                    Console.WriteLine($"No pet named '{petName}' found for this owner.");
                }
                Console.WriteLine("--------------------------------------------");
                return;
            }
        }

    }
    //----------------------------------------------------------------------------------------------------------------------

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
                    Console.WriteLine($"No pet named '{petName}' found for this owner.");

                }
                Console.WriteLine("--------------------------------------------");
                return;
            }
        }

    }
    }
