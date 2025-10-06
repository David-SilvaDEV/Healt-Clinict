using Healt_Clinict.Models;

namespace Healt_Clinict.Services;


public class ServicesValidation
{    
     static ServicesMenu servicesMenu = new ServicesMenu();
    public static void ReturnToMenu()
    {   

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        servicesMenu.MainMenu();



    }
    

}
