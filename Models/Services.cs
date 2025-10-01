using System;
using System.Linq;
using System.Collections.Generic;
using Healt_Clinict.obj.Models;

namespace Healt_Clinict.Models;

public class Services
{
    // Lista en memoria para poder buscar clientes al registrar solo mascota
    private readonly List<Customer> _customers = new();

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
}
