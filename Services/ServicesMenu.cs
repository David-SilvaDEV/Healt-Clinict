using Healt_Clinict.obj.Models;
using Healt_Clinict.repository;

namespace Healt_Clinict.Models;

public class ServicesMenu
{
   
    CustomerRepository customerManager = new CustomerRepository();
    PetRepository petManager = new PetRepository();


    //----------------------------------------------------------------------------------------------------------
    public void MainMenu()
    {

        {
            Console.Clear();
            Console.WriteLine("---- Welcome to the Health Clinic Manager ----");
            Console.WriteLine("Choose the corresponding option:");
            Console.WriteLine("[1] Customer");
            Console.WriteLine("[2] pets");
            Console.WriteLine("[3] Employees");
            Console.WriteLine("[4] Exis");

            string answer = Console.ReadLine() ?? "";
            switch (answer)
            {
                case "1":
                    CustomerMenu();
                    break;
                case "2":
                    PetsMenu();
                    break;
                case "3":

                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

    }

    public void CustomerMenu()
    {
        Services.Interface(" Customer Menu");
        Console.WriteLine("[1] -Register customer");
        Console.WriteLine("[2] -View customer information");
        Console.WriteLine("[3] -Update customer information");
        Console.WriteLine("[4] -Delete c1ustomer");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                //Services.RegisterCustomer();
                customerManager.RegisterCustomer();

                break;
            case "2":

                customerManager.viewcustomerinformation();

                break;
            case "3":
                customerManager.UpdateCustomer();

                break;
            case "4":
                customerManager.DeleteCustomer();

                break;
            case "5":
                MainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
        }

    }

    public void PetsMenu()
    {
        Services.Interface(" Pets Menu");
        Console.WriteLine("[1] -Register pet");
        Console.WriteLine("[2] -View pet information");
        Console.WriteLine("[3] -Update pet information");
        Console.WriteLine("[4] -Delete pet");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                //Services.RegisterPet();
                customerManager.RegisterCustomer();
                break;
            case "2":
                ShowInformationPets();
                break;
            case "3":
                customerManager.UpdateCustomer();
                break;
            case "4":
                customerManager.DeleteCustomer();
                break;
            case "5":
                MainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
        }
    }

    public void ShowInformationPets()
    {
        Services.Interface(" Information");
        Console.WriteLine("[1] -View all pets");
        Console.WriteLine("[2] -View pet by type");
        Console.WriteLine("[3] -View pet by age");
        Console.WriteLine("[4] -View pets alphabetically by name");
        Console.WriteLine("[5] -Return to main menu");

        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                petManager.ShowAllPets();
                break;
            case "2":
                petManager.FilterPetType();
                break;
            case "3":
                petManager.FilterPetAgeMoreless();
                break;
            case "4":
                petManager.FilterPetAlfabeticName();
                break;
            case "5":
                MainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
        }

    }

}
