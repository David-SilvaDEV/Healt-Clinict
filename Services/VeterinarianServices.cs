using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Healt_Clinict.repository;
using Healt_Clinict.Utils;
using Healt_Clinict.Models;
using Healt_Clinict.database;
namespace Healt_Clinict.Services;


public class VeterinarianServices
{
    public void RegisterVeterinarian()
    {
        VisualInterface.Interface("Register Veterinarian");

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

        Veterinarian NewVeterinarian = new Veterinarian();

        NewVeterinarian.Id = Guid.NewGuid();
        NewVeterinarian.Name = name;
        NewVeterinarian.LastName = lastName;
        NewVeterinarian.Age = age;
        NewVeterinarian.TypeDocument = typeDocument;
        NewVeterinarian.NumberDocument = numberDocument;

        NewVeterinarian.SetEmail(email);
        NewVeterinarian.SetPhoneNumber(phoneNumber);

        VeterinarianRepository.Register(NewVeterinarian);


    }


    public void viewVeterinarianinformation()
    {
        VisualInterface.Interface(" View Veterinarian");


        if (Warehouse.veterinarians == null || Warehouse.veterinarians.Count == 0)
        {
            VisualInterface.RedColor("No Veterinarian registered.");
            return;
        }

        Warehouse.veterinarians.ForEach(v => v.ShowInfoBasic());

        Console.WriteLine("Which vet do you want to see? Write the document number: ");
        string specificVeterinarian = Console.ReadLine() ?? "";

        var veterinarian = Warehouse.veterinarians
        .FirstOrDefault(v => v.NumberDocument.Equals(specificVeterinarian, StringComparison.OrdinalIgnoreCase));

        if (veterinarian == null)
        {
            VisualInterface.RedColor("Veterinarian not found.");
            return;
        }

        Console.WriteLine("\nVeterinarian details:\n");
        veterinarian.ShowFullInfo();
    }
    //----------------------------------------------------------------------------------------------
    public void DeleteVeterinarian()
    {
        VisualInterface.Interface(" Delete Veterinarian");

        if (Warehouse.veterinarians == null || Warehouse.veterinarians.Count == 0)
        {
            VisualInterface.RedColor("No Veterinarian registered.");
            return;
        }

        else
        {
            Console.WriteLine("write the veterinarian document number to delete: ");
            string documentNumber = Console.ReadLine() ?? "";
            Console.WriteLine("write the type of client document: ");
            string typeDocument = Console.ReadLine() ?? "";
            foreach (var veterinarian in Warehouse.veterinarians)
            {
                if (veterinarian.NumberDocument.Equals(documentNumber) && veterinarian.TypeDocument.Equals(typeDocument))

                {
                    VeterinarianRepository.Delete(veterinarian);
                    VisualInterface.GreenColor("Veterinarian deleted successfully.");
                    return;
                }

                else
                {
                    VisualInterface.RedColor("[x] Veterinarian not found. (*-*)");
                    Console.WriteLine("----------------------------------------");
                    return;

                }


            }
        }
    }
    

    public void UpdateVeterinarian()
    {
        VisualInterface.Interface(" Update Veterinarian");

        Console.WriteLine("Enter the name of the Veterinarian you want to update: ");
        string Uname = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the document number: ");
        string Udocument = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the type of document: ");
        string UtypeDocument = Console.ReadLine() ?? "";

        foreach (var veterinarian in Warehouse.veterinarians)
        {
            if (veterinarian.Name.Equals(Uname) && veterinarian.NumberDocument.Equals(Udocument) && veterinarian.TypeDocument.Equals(UtypeDocument))

            {
                Console.WriteLine("Which client fields do you want to update?");
                Console.WriteLine("[1] Name");
                Console.WriteLine("[2] LastName");
                Console.WriteLine("[3] Age");
                Console.WriteLine("[4] Email");
                Console.WriteLine("[5] Phone Number");
                Console.WriteLine("[6] Exit");

                string field = Console.ReadLine() ?? "";

                if (field == "1")
                {
                    Console.WriteLine("Enter new name (or press Enter to keep current): ");
                    string newName = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        veterinarian.Name = newName;
                    }

                }

                else if (field == "2")
                {
                    Console.WriteLine("Enter new last name (or press Enter to keep current): ");
                    string newLastName = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newLastName))
                    {
                        veterinarian.LastName = newLastName;
                    }
                }
                else if (field == "3")
                {
                    Console.WriteLine("Enter new age (or press Enter to keep current): ");
                    string newAgeInput = Console.ReadLine() ?? "";
                    if (int.TryParse(newAgeInput, out int newAge))
                    {
                        veterinarian.Age = newAge;
                    }
                }


                else if (field == "3")
                {
                    Console.WriteLine("Enter new email (or press Enter to keep current): ");
                    string newEmail = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newEmail))
                    {
                        veterinarian.SetEmail(newEmail);
                    }
                }


                else if (field == "4")
                {

                    Console.WriteLine("Enter new phone number (or press Enter to keep current): ");
                    string newPhoneNumber = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newPhoneNumber))
                    {
                         veterinarian.SetPhoneNumber(newPhoneNumber);
                    }

                }

                else
                {
                    ServicesValidation.ReturnToMenu();
                }

               

                Console.WriteLine($"veterinarian {veterinarian.Name} information updated successfully.");
                Console.WriteLine("----------------------------------------");
                return;
            }
        }
    }
}
