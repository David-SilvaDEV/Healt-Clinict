
using Healt_Clinict.database;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
using Healt_Clinict.repository;
using Healt_Clinict.Utils;



public class PetRepository
{
    Customer customer = new Customer();


    public static void Register(Pet newPet)
    {
        Warehouse.customers.ForEach(c => c.Pets.Add(newPet));

    }


    public static void Delete(Pet petToRemove)
    {
       
        Warehouse.customers.ForEach(c => c.Pets.Remove(petToRemove));
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
