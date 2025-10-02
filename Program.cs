
using Healt_Clinict.Models;


using Healt_Clinict.obj.Models;
Services services = new Services();
CustomerManager customerManager = new CustomerManager();

static void MainMenu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("---- Welcome to the Health Clinic Manager ----");
        Console.WriteLine("Choose the corresponding option:");
        Console.WriteLine("[1] Register Customers");
        Console.WriteLine("[2] show list of clients with their pets");
        Console.WriteLine("[3] Delete Patient");
        Console.WriteLine("[4] Delete pet");

        // ...menu logic...
    }
}



customerManager.viewcustomerinformation();
