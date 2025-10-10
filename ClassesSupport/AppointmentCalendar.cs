using System;
using System.Globalization;
using System.Linq;

namespace Healt_Clinict.ClassesSupport
{
    public class AppointmentCalendar
    {
        private AppointmentSystem appointmentSystem;

        public AppointmentCalendar(AppointmentSystem appointmentSystem)
        {
            this.appointmentSystem = appointmentSystem;
        }

        // Mostrar el calendario de un mes específico
        public void DisplayCalendar(int month, int year)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine($"{firstDayOfMonth.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}");
            Console.WriteLine("Sun|Mon|Tue|Wed|Thu|Fri|Sat");

            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            if (firstDayOfWeek == 0) firstDayOfWeek = 7;

            // Imprimir espacios hasta el primer día del mes
            for (int i = 1; i < firstDayOfWeek; i++)
            {
                Console.Write("    ");
            }

            // Mostrar los días del mes
            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write($"{day,3} ");

                if ((firstDayOfWeek + day - 1) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}
