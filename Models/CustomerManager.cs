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


}
