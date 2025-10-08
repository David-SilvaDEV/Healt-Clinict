using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Healt_Clinict.database;
using Healt_Clinict.obj.Models;
using Healt_Clinict.repository;
using Healt_Clinict.Utils;


namespace Healt_Clinict.Services;

public class CustomerServices
{
    CustomerRepository customerRepository = new CustomerRepository();
    PetRepository petRepository = new PetRepository();
    public  void RegisterCustomer()
    {

        VisualInterface.Interface("Register Customer");



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
                Console.WriteLine("Write Customer age:");
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

        // Crear el nuevo cliente usando el constructor por defecto
        Customer NewCustomer = new Customer();

        // Asignar valores a las propiedades del cliente
        NewCustomer.Id = Guid.NewGuid();
        NewCustomer.Name = name;
        NewCustomer.LastName = lastName;
        NewCustomer.Age = age;
        NewCustomer.TypeDocument = typeDocument;
        NewCustomer.NumberDocument = numberDocument;

        // Asignar el email y el teléfono usando los métodos SetEmail y SetPhoneNumber
        NewCustomer.SetEmail(email);
        NewCustomer.SetPhoneNumber(phoneNumber);

        

        // Registrar mascota (ya devuelve el objeto Pet)
        PetServices petServices = new PetServices();
        Pet newPet = petServices.RegisterPet();
        newPet.Owner = NewCustomer;
        NewCustomer.Pets.Add(newPet);

        // Guardar el cliente para búsquedas posteriores (Registeronlypet)
        customerRepository.Register(NewCustomer);
        VisualInterface.GreenColor("Customer added successfully!");


        ServicesValidation.ReturnToMenu();
        return;

    }


    //-----------------------------------------------------------------------------------------------------------------------------------------
    public void viewcustomerinformation()
    {
        VisualInterface.Interface(" View customer");


        if (Warehouse.customers == null || Warehouse.customers.Count == 0)
        {
            VisualInterface.RedColor("No customers registered.");
            return;
        }

        Warehouse.customers.ForEach(c => c.ShowInfoBasic());
        //customer.ShowInfoBasic();


        Console.WriteLine("Which client do you want to see specifically? Enter their document number.");
        string specificClient = Console.ReadLine() ?? "";
        var customer = Warehouse.customers.FirstOrDefault(c => c.NumberDocument == specificClient);

        if (customer == null)
        {
            VisualInterface.RedColor("[x]!Customer not found.");
            return;
        }

        Console.WriteLine("[1] - See information?");
        Console.WriteLine("[2] - See pets?");
        string answer = Console.ReadLine() ?? "";

        if (answer == "1")
        {
            // Mostrar toda la información del cliente
            customer.ShowFullInfo();
        }
        else if (answer == "2")
        {
            customer.ShowMyPets(specificClient);

        }
        else
        {
            VisualInterface.RedColor("[X] Invalid option.");

            return;

        }

        ServicesValidation.ReturnToMenu();

    }
    //---------------------------------------------------------------------------------------

    public void DeleteCustomer()
    {
        VisualInterface.Interface(" Delete Customer");

        if (Warehouse.customers == null || Warehouse.customers.Count == 0)
        {
            VisualInterface.RedColor("No customers registered.");
            return;
        }

        else
        {
            Console.WriteLine("write the client's document number to delete: ");
            string documentNumber = Console.ReadLine() ?? "";
            Console.WriteLine("write the type of client document: ");
            string typeDocument = Console.ReadLine() ?? "";
            foreach (var customer in Warehouse.customers)
            {
                if (customer.NumberDocument.Equals(documentNumber) && customer.TypeDocument.Equals(typeDocument))

                {
                    customerRepository.Delete(customer);
                    VisualInterface.GreenColor("Customer deleted successfully.");
                    return;
                }

                else
                {
                    VisualInterface.RedColor("Customer not found.");
                    return;
                }
            }
        }
        ServicesValidation.ReturnToMenu();
    }


    public void UpdateCustomer()
    {
        VisualInterface.Interface(" Update Customer");

        Console.WriteLine("Enter the name of the client you want to update: ");
        string Uname = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the document number: ");
        string Udocument = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the type of document: ");
        string UtypeDocument = Console.ReadLine() ?? "";

        foreach (var customer in Warehouse.customers)
        {
            if (customer.Name.Equals(Uname) && customer.NumberDocument.Equals(Udocument) && customer.TypeDocument.Equals(UtypeDocument))

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
                        customer.Name = newName;
                    }

                }

                else if (field == "2")
                {
                    Console.WriteLine("Enter new last name (or press Enter to keep current): ");
                    string newLastName = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newLastName))
                    {
                        customer.LastName = newLastName;
                    }
                }
                else if (field == "3")
                {
                    Console.WriteLine("Enter new age (or press Enter to keep current): ");
                    string newAgeInput = Console.ReadLine() ?? "";
                    if (int.TryParse(newAgeInput, out int newAge))
                    {
                        customer.Age = newAge;
                    }
                }


                else if (field == "3")
                {
                    Console.WriteLine("Enter new email (or press Enter to keep current): ");
                    string newEmail = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newEmail))
                    {
                        customer.SetEmail(newEmail);
                    }
                }


                else if (field == "4")
                {

                    Console.WriteLine("Enter new phone number (or press Enter to keep current): ");
                    string newPhoneNumber = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newPhoneNumber))
                    {
                         customer.SetPhoneNumber(newPhoneNumber);
                    }

                }

                else
                {
                    ServicesValidation.ReturnToMenu();
                }

               

                Console.WriteLine($"Customer {customer.Name} information updated successfully.");
                Console.WriteLine("----------------------------------------");
                return;
            }
        }
    }
}

