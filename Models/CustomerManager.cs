namespace Healt_Clinict.Models;

public class CustomerManager
{

    Services Services = new Services();
    //--------------------------------------------------------------------------
    public void viewcustomerinformation()
    {
        Services.Interface(" View customer");

        if (Services._customers == null || Services._customers.Count == 0)
        {
            Console.WriteLine("No customers registered.");
            return;
        }

        foreach (var customer in Services._customers)
        {
            Console.WriteLine($"{customer.Name} {customer.LastName} - Document: {customer.TypeDocument} {customer.NumberDocument}");
            Console.WriteLine($"--");

        }

        Console.WriteLine("Which client do you want to see specifically? Enter their document number.");
        string specificClient = Console.ReadLine() ?? "";
        Console.WriteLine("[1] -see information?");
        Console.WriteLine("[2] -see pets?");
        string answer = Console.ReadLine() ?? "";
        if (answer == "1")
        {
            ShowInfo(specificClient);

        }
        else if (answer == "2")
        {
            ShowClientPets(specificClient);

        }
        else
        {
            Console.WriteLine("Invalid option.");

        }



    }

    public void ShowInfo(string specificClient)
    {
        if (specificClient == null)
        {
            Console.WriteLine("No client specified.");
            return;
        }

        else
        {
            foreach (var customer in Services._customers)
            {
                if (customer.NumberDocument.Equals(specificClient))

                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Customer Information:");
                    Console.WriteLine($"Name: {customer.Name} {customer.LastName}");
                    Console.WriteLine($"Last Name:  {customer.LastName}");
                    Console.WriteLine($"Age: {customer.Age}");
                    Console.WriteLine($"Document: {customer.TypeDocument} {customer.NumberDocument}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                    Console.WriteLine("----------------------------------------");
                    return;
                }
            }
        }

    }

    public void ShowClientPets(string specificClient)
    {
        if (specificClient == null)
        {
            Console.WriteLine("No client specified.");
            return;
        }
        else
        {
            foreach (var customer in Services._customers)
            {
                if (customer.NumberDocument.Equals(specificClient))

                {
                    Console.Clear();
                    Console.WriteLine($"Pets of {customer.Name} {customer.LastName}:");
                    if (customer.Pets == null || customer.Pets.Count == 0)
                    {
                        Console.WriteLine("No pets registered for this customer.");
                    }
                    else
                    {

                        foreach (var pet in customer.Pets)
                        {
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Type: {pet.TypeAnimal} | Name: {pet.Name}, | Age: {pet.Age}, | Symptoms: {pet.Symptoms}");
                            Console.WriteLine("----------------------------------------");
                        }

                    }
                    return;

                }
            }
        }
    }


    public void DeleteCustomer()
    {
        Services.Interface(" Delete Customer");

        if (Services._customers == null || Services._customers.Count == 0)
        {
            Console.WriteLine("No customers registered.");
            return;
        }

        else
        {
            Console.WriteLine("write the client's document number to delete: ");
            string documentNumber = Console.ReadLine() ?? "";
            Console.WriteLine("write the type of client document: ");
            string typeDocument = Console.ReadLine() ?? "";
            foreach (var customer in Services._customers)
            {
                if (customer.NumberDocument.Equals(documentNumber) && customer.TypeDocument.Equals(typeDocument))

                {
                    Services._customers.Remove(customer);
                    Console.WriteLine("Customer deleted successfully.");
                    return;
                }

                else
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }
            }
        }
    }
    //--------------------------------------------------------------------------

    public void UpdateCustomer()
    {
        Services.Interface(" Update Customer");

        Console.WriteLine("Enter the name of the client you want to update: ");
        string Uname = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the document number: ");
        string Udocument = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the type of document: ");
        string UtypeDocument = Console.ReadLine() ?? "";

        foreach (var customer in Services._customers)
        {
            if (customer.Name.Equals(Uname) && customer.NumberDocument.Equals(Udocument) && customer.TypeDocument.Equals(UtypeDocument))

            {
                Console.WriteLine("Enter new name (or press Enter to keep current): ");
                string newName = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    customer.Name = newName;
                }

                Console.WriteLine("Enter new last name (or press Enter to keep current): ");
                string newLastName = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    customer.LastName = newLastName;
                }

                Console.WriteLine("Enter new age (or press Enter to keep current): ");
                string newAgeInput = Console.ReadLine() ?? "";
                if (int.TryParse(newAgeInput, out int newAge))
                {
                    customer.Age = newAge;
                }

                Console.WriteLine("Enter new email (or press Enter to keep current): ");
                string newEmail = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    customer.Email = newEmail;
                }

                Console.WriteLine("Enter new phone number (or press Enter to keep current): ");
                string newPhoneNumber = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newPhoneNumber))
                {
                    customer.PhoneNumber = newPhoneNumber;
                }

                Console.WriteLine($"Customer {customer.Name} information updated successfully.");
                Console.WriteLine("----------------------------------------");
                return;
            }
        }
    }
}
