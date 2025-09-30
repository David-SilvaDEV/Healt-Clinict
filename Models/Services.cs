using Healt_Clinict.obj.Models;

namespace Healt_Clinict.Models;

public class Services
{

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
    }


    public void RegisterPet()
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

        Pet newPet = new Pet
        {
            Name = name,
            TypeAnimal = typeAnimal,
            Sex = sex,
            Age = age,
            Color = color,
            Weight = weight,
            Symptoms = symptoms,

        }
    }



}
