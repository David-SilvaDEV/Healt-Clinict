
namespace Healt_Clinict.Utils;

public static class VisualInterface
{
    public static void Interface(string sectionName)
    {
        Console.Clear();
        Console.WriteLine($"-[section of {sectionName}]-");



        Console.WriteLine("----------------------------------");
    }


    public static void GreenColor(string TexColor)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{TexColor}");

        // Restaura el color predeterminado
        Console.ResetColor();

    }

    public static void RedColor(string TexColor)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{TexColor}");

        // Restaura el color predeterminado
        Console.ResetColor();

    }
}
