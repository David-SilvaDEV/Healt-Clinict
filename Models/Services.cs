using System;
using System.Linq;
using System.Collections.Generic;
using Healt_Clinict.obj.Models;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace Healt_Clinict.Models;

public class Services
{


    // Lista en memoria para poder buscar clientes al registrar solo mascota
    public static List<Customer> _customers = new()
{
    new Customer
    {
        Id = Guid.NewGuid(),
        Name = "Carlos",
        LastName = "Ramírez",
        Age = 28,
        TypeDocument = "CC",
        NumberDocument = "1002456789",
        Email = "carlos.ramirez@example.com",
        PhoneNumber = "3004567890",
        Pets = new List<Pet>()
        {
            new Pet("Firulais", "Perro", "Macho", 3, "Marrón", "15kg", "Sano",null! ) // asignaremos Owner luego
        }
    },
    new Customer
    {
        Id = Guid.NewGuid(),
        Name = "Laura",
        LastName = "Gómez",
        Age = 34,
        TypeDocument = "CC",
        NumberDocument = "1003987654",
        Email = "laura.gomez@example.com",
        PhoneNumber = "3019876543",
        Pets = new List<Pet>()
        {
            new Pet("Michi", "Gato", "Hembra", 2, "Blanco", "4kg", "Resfriado leve", null!)
        }
    },
    new Customer
    {
        Id = Guid.NewGuid(),
        Name = "Andrés",
        LastName = "Torres",
        Age = 22,
        TypeDocument = "TI",
        NumberDocument = "1122334455",
        Email = "andres.torres@example.com",
        PhoneNumber = "3021234567",
        Pets = new List<Pet>()
        {
            new Pet("Rex", "Perro", "Macho", 5, "Negro", "20kg", "Cojea", null!)
        }
    },
    new Customer
    {
        Id = Guid.NewGuid(),
        Name = "Valentina",
        LastName = "Martínez",
        Age = 29,
        TypeDocument = "CC",
        NumberDocument = "1005678912",
        Email = "valentina.martinez@example.com",
        PhoneNumber = "3156789123",
        Pets = new List<Pet>()
        {
            new Pet("Luna", "Conejo", "Hembra", 1, "Gris", "1.5kg", "Sano" , null!)
        }
    },
    new Customer
    {
        Id = Guid.NewGuid(),
        Name = "Miguel",
        LastName = "Suárez",
        Age = 40,
        TypeDocument = "CE",
        NumberDocument = "890123456",
        Email = "miguel.suarez@example.com",
        PhoneNumber = "3168901234",
        Pets = new List<Pet>()
        {
            new Pet("Rocky", "Perro", "Macho", 7, "Café", "25kg", "Dolor en la pata", null!)
        }
    }


};

    public void Interface(string sectionName)
    {
        Console.Clear();
        Console.WriteLine($"-[section of {sectionName}]-");

        Console.WriteLine("----------------------------------");
    }
    public void RegisterCustomer()
    {

        Interface("Register Customer");



        Console.WriteLine("Write the client's name: ");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the customer's last name: ");
        string lastName = Console.ReadLine() ?? "";

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

        Console.WriteLine("Enter the type of document: ");
        string typeDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the document number: ");
        string numberDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the email: ");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        Customer NewCustomer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = name,
            LastName = lastName,
            Age = age,
            TypeDocument = typeDocument,
            NumberDocument = numberDocument,
            Email = email,
            PhoneNumber = phoneNumber,
            Pets = new List<Pet>()
        };

        // Registrar la mascota y asociarla al cliente creado
        Pet newPet = RegisterPet();
        newPet.Owner = NewCustomer;
        NewCustomer.Pets.Add(newPet);

        // Guardar el cliente para búsquedas posteriores (Registeronlypet)
        _customers.Add(NewCustomer);
    }


    public Pet RegisterPet()
    {
        Interface("Register Pet");
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

    public void Registeronlypet()
    {
        Interface("Register Pet");
        Console.WriteLine("Write the identification number (document number) to which the pet belongs:");
        string idNumber = Console.ReadLine() ?? "";
        Console.WriteLine("Write the name of the pet owner (name, last name or full name): ");
        string ownerName = Console.ReadLine() ?? "";

        // Buscar cliente que coincida en id y en nombre (Name o LastName o "Name LastName")
        var customer = _customers.FirstOrDefault(c =>
            !string.IsNullOrEmpty(c.NumberDocument) &&
            c.NumberDocument.Equals(idNumber, StringComparison.OrdinalIgnoreCase) &&
            (
                c.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Equals(ownerName, StringComparison.OrdinalIgnoreCase) ||
                $"{c.Name} {c.LastName}".Equals(ownerName, StringComparison.OrdinalIgnoreCase)
            )
        );

        if (customer == null)
        {
            Console.WriteLine("No customer found with that ID and name. Please verify the details or create a new one first.");
            return;
        }

        Pet newPet = RegisterPet();
        newPet.Owner = customer;
        customer.Pets.Add(newPet);
        Console.WriteLine("Pet registered and associated with the client correctly.");
    }




    //--------------------------------------------------------------------------------------------------------------------
    // FILTRADOS----------------------------------


    public void FilterPetType()
    {
        Interface("Filter Pets by Type");

        // Mostrar los tipos únicos
        Console.WriteLine("Types of registered animals:");
        foreach (var pet in Services._customers.SelectMany(c => c.Pets).DistinctBy(p => p.TypeAnimal))
        {
            Console.WriteLine($"- {pet.TypeAnimal}");
        }

        Console.WriteLine("Enter the type of animal to filter: ");
        string typeAnimal = Console.ReadLine() ?? "";

        // Filtrar y mostrar todas las mascotas de ese tipo
        var filteredPets = Services._customers
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
        Interface("Filter Pets by Age");

        var sortedPets = Services._customers
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
        Interface("Filter Pets by Name (Alphabetically)");

        var sortedPets = Services._customers
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
        Interface("All Registered Pets");

        var allPets = Services._customers
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
        Console.WriteLine("--------------------------------------------");
    }
}




