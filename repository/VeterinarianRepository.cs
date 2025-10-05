namespace Healt_Clinict.repository;

using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Healt_Clinict.Models;
using Healt_Clinict.Thing_Models;
using Healt_Clinict.database;



public class VeterinarianRepository
{
    Services services = new Services();
    Warehouse warehouse = new Warehouse();
    public void RegisterVeterinarian()
    {
        services.Interface("Register Veterinarian");

        Veterinarian veterinarian = new Veterinarian();

        Console.WriteLine("Enter the veterinarian's first name: ");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the veterinarian's last name: ");
        string lastName = Console.ReadLine() ?? "";

        int age = -1; // Inicializamos en un valor negativo para entrar en el ciclo

        // Validación de la edad
        while (age < 0)
        {
            try
            {
                Console.WriteLine("Write veterinarian age:");
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
        veterinarian.Age = age;

        Console.WriteLine("Enter the type of document : ");
        string typeDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the document number: ");
        string numberDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the email address: ");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        // Aquí puedes agregar lógica para guardar el veterinario en una base de datos o lista si es necesario

        Veterinarian NewVeterinarian = new Veterinarian
        {
            Id = Guid.NewGuid(),
            Name = name,
            LastName = lastName,
            Age = age,
            TypeDocument = typeDocument,
            NumberDocument = numberDocument,
            Email = email,
            PhoneNumber = phoneNumber,

        };

        warehouse._veterinarians.Add(NewVeterinarian);

    }

    public void viewcustomerinformation()
    {
        services.Interface(" View Veterinarian");


        if (warehouse._veterinarians == null || warehouse._veterinarians.Count == 0)
        {
            Console.WriteLine("No Veterinarian registered.");
            return;
        }

        foreach (var veterinarian in warehouse._veterinarians)
        {
            Console.WriteLine($"{veterinarian.Name} {veterinarian.LastName} - Document: {veterinarian.TypeDocument} {veterinarian.NumberDocument}");
            Console.WriteLine($"--");

        }

        Console.WriteLine("Which vet do you want to see? Write the document number: ");
        string specificVeterinarian = Console.ReadLine() ?? "";

        ShowInfo(specificVeterinarian);

    }

    public void ShowInfo(string specificVeterinarian)
    {
        if (specificVeterinarian == null)
        {
            Console.WriteLine("No client specified.");
            return;
        }

        else
        {
            foreach (var veterinarian in warehouse._veterinarians)
            {
                if (veterinarian.NumberDocument.Equals(specificVeterinarian))

                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Customer Information:");
                    Console.WriteLine($"Name: {veterinarian.Name} {veterinarian.LastName}");
                    Console.WriteLine($"Last Name:  {veterinarian.LastName}");
                    Console.WriteLine($"Age: {veterinarian.Age}");
                    Console.WriteLine($"Document: {veterinarian.TypeDocument} {veterinarian.NumberDocument}");
                    Console.WriteLine($"Email: {veterinarian.Email}");
                    Console.WriteLine($"Phone Number: {veterinarian.PhoneNumber}");
                    Console.WriteLine("----------------------------------------");
                    return;
                }
            }
        }

    }

    


    public void DeleteVeterinarian()
    {
        services.Interface(" Delete Veterinarian");

        if (warehouse._veterinarians == null || warehouse._veterinarians.Count == 0)
        {
            Console.WriteLine("No Veterinarian registered.");
            return;
        }

        else
        {
            Console.WriteLine("write the veterinarian document number to delete: ");
            string documentNumber = Console.ReadLine() ?? "";
            Console.WriteLine("write the type of client document: ");
            string typeDocument = Console.ReadLine() ?? "";
            foreach (var veterinarian in warehouse._veterinarians)
            {
                if (veterinarian.NumberDocument.Equals(documentNumber) && veterinarian.TypeDocument.Equals(typeDocument))

                {
                    warehouse._veterinarians.Remove(veterinarian);
                    Console.WriteLine("Veterinarian deleted successfully.");
                    return;
                }

                else
                {
                    Console.WriteLine("Veterinarian not found.");
                    return;
                }

                Console.WriteLine("----------------------------------------");
            }
        }
    }
    //--------------------------------------------------------------------------

    public void UpdateCustomer()
    {
        services.Interface(" Update Veterinarian");

        Console.WriteLine("Enter the name of the Veterinarian you want to update: ");
        string Uname = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the document number: ");
        string Udocument = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the type of document: ");
        string UtypeDocument = Console.ReadLine() ?? "";

        foreach (var veterinarian in warehouse._veterinarians)
        {
            if (veterinarian.Name.Equals(Uname) && veterinarian.NumberDocument.Equals(Udocument) && veterinarian.TypeDocument.Equals(UtypeDocument))

            {
                Console.WriteLine("Enter new name (or press Enter to keep current): ");
                string newName = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    veterinarian.Name = newName;
                }

                Console.WriteLine("Enter new last name (or press Enter to keep current): ");
                string newLastName = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    veterinarian.LastName = newLastName;
                }

                Console.WriteLine("Enter new age (or press Enter to keep current): ");
                string newAgeInput = Console.ReadLine() ?? "";
                if (int.TryParse(newAgeInput, out int newAge))
                {
                    veterinarian.Age = newAge;
                }

                Console.WriteLine("Enter new email (or press Enter to keep current): ");
                string newEmail = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    veterinarian.Email = newEmail;
                }

                Console.WriteLine("Enter new phone number (or press Enter to keep current): ");
                string newPhoneNumber = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newPhoneNumber))
                {
                    veterinarian.PhoneNumber = newPhoneNumber;
                }

                Console.WriteLine($"veterinarian {veterinarian.Name} information updated successfully.");
                Console.WriteLine("----------------------------------------");
                return;
            }
        }
    }
}


