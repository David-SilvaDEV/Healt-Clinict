using Healt_Clinict.Models;
using Healt_Clinict.Utils;

namespace Healt_Clinict.Services;


public class ServicesValidation
{
    static Menu menu = new Menu();
    public static void ReturnToMenu()
    {   

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        menu.MainMenu();



    }
    

}
