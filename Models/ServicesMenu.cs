namespace Healt_Clinict.Models;

public class ServicesMenu
{
    Services Services = new Services();
    CustomerManager customerManager = new CustomerManager();
    //----------------------------------------------------------------------------------------------------------
    public void MainMenu()
    {
        while (true)
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
                    CustomerMennu();
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
                    break;
            }
        }

    }

    public void CustomerMennu()
    {
        Services.Interface(" Customer Menu");
        Console.WriteLine("[1] -Register customer");
        Console.WriteLine("[2] -View customer information");
        Console.WriteLine("[3] -Update customer information");
        Console.WriteLine("[4] -Delete customer");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                Services.RegisterCustomer();
                break;
            case "2":

                customerManager.viewcustomerinformation();
                break;
            case "3":
                Console.WriteLine("Update customer information");
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
                Services.RegisterPet();
                break;
            case "2":

                break;
            case "3":
                Console.WriteLine("Update pet information");
                break;
            case "4":
                Console.WriteLine("Delete pet");
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

    public void ShowInformation ()
    {
        Services.Interface(" Information");
        Console.WriteLine("[2] -View all pets");
        Console.WriteLine("[3] -View pet by type");
        Console.WriteLine("[4] -View pets by age (oldest to youngest)");
        Console.WriteLine("[5] -View pets alphabetically by name");
        Console.WriteLine("[6] -Return to main menu");

        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                customerManager.viewcustomerinformation();
                break;
            case "2":
                
                break;
            case "3":
                Console.WriteLine("View all employees");
                break;
            case "4":
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
