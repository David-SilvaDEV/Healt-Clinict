using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Healt_Clinict.Services;

namespace Healt_Clinict.Utils;

public class Menu
{
    CustomerServices customerServices = new();
    PetServices petServices = new PetServices();
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
                    VisualInterface.RedColor("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

    }

    public void CustomerMenu()
    {
        VisualInterface.Interface(" Customer Menu");
        Console.WriteLine("[1] -Register customer");
        Console.WriteLine("[2] -View customer information");
        Console.WriteLine("[3] -Update customer information");
        Console.WriteLine("[4] -Delete c1ustomer");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                //VisualInterface.RegisterCustomer();
                customerServices.RegisterCustomer();

                break;
            case "2":

                customerServices.viewcustomerinformation();

                break;
            case "3":
                customerServices.UpdateCustomer();

                break;
            case "4":
                customerServices.DeleteCustomer();

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
        VisualInterface.Interface(" Pets Menu");
        Console.WriteLine("[1] -Register pet");
        Console.WriteLine("[2] -View pet information");
        Console.WriteLine("[3] -Update pet information");
        Console.WriteLine("[4] -Delete pet");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                //VisualInterface.RegisterPet();
                customerServices.RegisterCustomer();
                break;
            case "2":
                ShowInformationPets();
                break;
            case "3":
                customerServices.UpdateCustomer();
                break;
            case "4":
                customerServices.DeleteCustomer();
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
        VisualInterface.Interface(" Information");
        Console.WriteLine("[1] -View all pets");
        Console.WriteLine("[2] -View pet by type");
        Console.WriteLine("[3] -View pet by age");
        Console.WriteLine("[4] -View pets alphabetically by name");
        Console.WriteLine("[5] -Return to main menu");

        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                petServices.ShowAllPets();
                break;
            case "2":
                petServices.FilterPetType();
                break;
            case "3":
                petServices.FilterPetAgeMoreless();
                break;
            case "4":
                petServices.FilterPetAlfabeticName();
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

    public void EmployeeMenu()
    {
        
    }

}
