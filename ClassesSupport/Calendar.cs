
namespace Healt_Clinict.ClassesSupport;

using System;
using System.Globalization;

public class Calendar
{
    // Método para mostrar el calendario del mes actual
    public void DisplayCurrentCalendar()
    {
        // Obtener la fecha actual
        DateTime currentDate = DateTime.Now;

        // Mostrar el calendario para el mes actual
        DisplayCalendar(currentDate.Month, currentDate.Year);
    }

    // Método para mostrar el calendario de un mes y año específicos
    private void DisplayCalendar(int month, int year)
    {
        // Obtener el primer día del mes y el número de días en ese mes
        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        int daysInMonth = DateTime.DaysInMonth(year, month);

        // Mostrar el nombre del mes y el año
        Console.WriteLine($"{firstDayOfMonth.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}");
        Console.WriteLine("Sun|Mon|Tue|Wed|Thu|Fri|Sat");

        // Calcular qué día de la semana cae el primer día del mes
        int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

        // Ajustar para que el domingo sea el primer día de la semana
        if (firstDayOfWeek == 0)
        {
            firstDayOfWeek = 7;
        }

        // Mostrar los espacios antes del primer día
        for (int i = 1; i < firstDayOfWeek; i++)
        {
            Console.Write("    ");  // Espacios para los días anteriores
        }

        // Mostrar los días del mes con alineación
        for (int day = 1; day <= daysInMonth; day++)
        {
            // Asegurar que cada número tenga un ancho fijo de 3 caracteres
            Console.Write($"{day,3} ");  // Alineación a la derecha con 3 espacios

            // Si el día es sábado (fin de semana), saltamos a la siguiente línea
            if ((firstDayOfWeek + day - 1) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();    
    }
}



