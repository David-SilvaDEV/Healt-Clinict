using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Healt_Clinict.repository;
using Healt_Clinict.Utils;
using Healt_Clinict.Models;
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
}
