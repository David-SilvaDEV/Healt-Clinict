using System.Globalization;

namespace Healt_Clinict.ClassesSupport
{
    using System.Globalization;
    using System.Linq;

    public class AppointmentCalendar
    {
        private AppointmentSystem appointmentSystem;

        public AppointmentCalendar(AppointmentSystem appointmentSystem)
        {
            this.appointmentSystem = appointmentSystem;
        }

        // Método para mostrar el calendario de un mes específico
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
                // Mostrar el día en el calendario
                Console.Write($"{day,3} ");

                // Salto de línea después de la séptima columna (fin de la semana)
                if ((firstDayOfWeek + day - 1) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            // Espacio después del calendario
            Console.WriteLine();
        }
    }

    public class ReservationsSystem
    {
        private AppointmentSystem appointmentSystem = new AppointmentSystem();

        public ReservationsSystem()
        {
            // Obtener el año actual
            int currentYear = DateTime.Now.Year;

            // Solicitar al usuario solo el mes
            Console.WriteLine("Enter the month (MM) to display available appointments:");

            string monthInput = Console.ReadLine() ?? "";
            int month;

            // Verificar si el mes ingresado es válido
            if (int.TryParse(monthInput, out month) && month >= 1 && month <= 12)
            {
                // Generar citas para el mes y año actuales
                appointmentSystem.GenerateAppointments(month, currentYear);

                // Crear una instancia del calendario, pasando el sistema de citas
                AppointmentCalendar calendar = new AppointmentCalendar(appointmentSystem);

                // Mostrar el calendario con citas disponibles para el mes solicitado
                Console.WriteLine($"\nDisplaying calendar for {new DateTime(currentYear, month, 1):MMMM yyyy}:\n");
                calendar.DisplayCalendar(month, currentYear);

                // Permitir que el usuario seleccione un día
                AskForDay(month, currentYear);
            }
            else
            {
                Console.WriteLine("Invalid month. Please enter a valid month (1-12).");
            }
        }

        // Método para preguntar el día y mostrar las citas disponibles
        private void AskForDay(int month, int year)
        {
            Console.WriteLine("\nEnter the day (DD) to view available appointments:");
            string dayInput = Console.ReadLine() ?? "";
            int day;

            // Verificar si el día ingresado es válido
            if (int.TryParse(dayInput, out day) && day >= 1 && day <= DateTime.DaysInMonth(year, month))
            {
                DateTime selectedDate = new DateTime(year, month, day);

                // Mostrar las horas disponibles para el día seleccionado
                ShowAvailableAppointmentsForDay(selectedDate);
            }
            else
            {
                Console.WriteLine("Invalid day. Please enter a valid day.");
            }
        }

        // Método para mostrar las horas disponibles para un día específico
        private void ShowAvailableAppointmentsForDay(DateTime selectedDate)
        {
            // Obtener las citas disponibles para el día seleccionado
            var availableAppointments = appointmentSystem.GetAvailableAppointments(selectedDate);

            // Si hay citas disponibles, mostrarlas
            if (availableAppointments.Any())
            {
                Console.WriteLine($"\nAvailable appointments for {selectedDate:dddd, MMM dd, yyyy}:");

                foreach (var appointment in availableAppointments)
                {
                    Console.WriteLine($"  {appointment.DateAndTime:HH:mm}");
                }

                // Permitir que el usuario seleccione una hora para reservar
                Console.WriteLine("\nEnter a time (HH:mm) to reserve:");
                string timeInput = Console.ReadLine() ?? "";

                if (DateTime.TryParseExact(timeInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime time))
                {
                    DateTime appointmentTime = selectedDate.Date.Add(time.TimeOfDay);

                    bool isReserved = appointmentSystem.ReserveAppointment(appointmentTime);
                    if (isReserved)
                    {
                        Console.WriteLine("Your appointment has been successfully reserved.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, the selected appointment time is unavailable.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid time format.");
                }
            }
            else
            {
                Console.WriteLine("No available appointments for this day.");
            }
        }
    }
}

