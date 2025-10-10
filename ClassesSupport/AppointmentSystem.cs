using System;
using System.Linq;
using Healt_Clinict.database;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
using Healt_Clinict.Utils;
using Microsoft.VisualBasic;


namespace Healt_Clinict.ClassesSupport
{
    public class ReservationsSystem
        
    {    
        
        private AppointmentSystem appointmentSystem = new AppointmentSystem();

        public ReservationsSystem()
        {
            int currentYear = DateTime.Now.Year;

            Console.WriteLine("Enter the month (MM) to display available appointments:");
            string monthInput = Console.ReadLine() ?? "";
            int month;

            if (int.TryParse(monthInput, out month) && month >= 1 && month <= 12)
            {
                appointmentSystem.GenerateAppointments(month, currentYear);
                AppointmentCalendar calendar = new AppointmentCalendar(appointmentSystem);

                Console.WriteLine($"\nDisplaying calendar for {new DateTime(currentYear, month, 1):MMMM yyyy}:\n");
                calendar.DisplayCalendar(month, currentYear);

                AskForDay(month, currentYear);
            }
            else
            {
                Console.WriteLine("Invalid month. Please enter a valid month (1-12).");
            }
        }

        private void AskForDay(int month, int year)
        {
            Console.WriteLine("\nEnter the day (DD) to view available appointments:");
            string dayInput = Console.ReadLine() ?? "";
            int day;

            if (int.TryParse(dayInput, out day) && day >= 1 && day <= DateTime.DaysInMonth(year, month))
            {
                DateTime selectedDate = new DateTime(year, month, day);
                ShowAvailableAppointmentsForDay(selectedDate);
            }
            else
            {
                Console.WriteLine("Invalid day. Please enter a valid day.");
            }
        }

        private void ShowAvailableAppointmentsForDay(DateTime selectedDate)
        {
            var availableAppointments = appointmentSystem.GetAvailableAppointments(selectedDate);

            if (availableAppointments.Any())
            {
                Console.WriteLine($"\nAvailable appointments for {selectedDate:dddd, MMM dd, yyyy}:");

                foreach (var appointment in availableAppointments)
                {
                    Console.WriteLine($"  {appointment.DateAndTime:HH:mm}");
                }
//----------------------------------------------------------------------------------------------------------------------------------------------------
                Console.WriteLine("\nEnter a time (HH:mm) to reserve:");
                string timeInput = Console.ReadLine() ?? "";

                if (DateTime.TryParseExact(timeInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime time))
                {
                    DateTime appointmentTime = selectedDate.Date.Add(time.TimeOfDay);

                    // Pedir datos del cliente
                    Console.WriteLine("Enter customer name:");
                    string customerName = Console.ReadLine() ?? "";

                    Console.WriteLine("Enter customer document number:");
                    string customerDoc = Console.ReadLine() ?? "";

                    var customer = Warehouse.customers
                        .FirstOrDefault(c => c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase)
                                            && c.NumberDocument == customerDoc);

                    if (customer == null)
                    {
                        VisualInterface.GreenColor("[X] Customer not found (*-*).");
                        return;
                    }

                    if (customer.Pets == null || customer.Pets.Count == 0)
                    {
                        VisualInterface.GreenColor(" [X] Customer has no pets registered (-_*).");
                        return;
                    }

                    Console.WriteLine("Select a pet:");
                    for (int i = 0; i < customer.Pets.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {customer.Pets[i].Name}");
                    }

                    if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 1 || petIndex > customer.Pets.Count)
                    {
                        Console.WriteLine("Invalid pet selection.");
                        return;
                    }
                    var pet = customer.Pets[petIndex - 1];

                    if (Warehouse.veterinarians.Count == 0)
                    {
                        Console.WriteLine("No veterinarians available.");
                        return;
                    }

                    Console.WriteLine("Select a veterinarian:");
                    for (int i = 0; i < Warehouse.veterinarians.Count; i++)
                    {
                        var vet = Warehouse.veterinarians[i];
                        Console.WriteLine($"{i + 1}. {vet.Name} {vet.LastName}");
                    }

                    if (!int.TryParse(Console.ReadLine(), out int vetIndex) || vetIndex < 1 || vetIndex > Warehouse.veterinarians.Count)
                    {
                        Console.WriteLine("Invalid veterinarian selection.");
                        return;
                    }
                    var veterinarian = Warehouse.veterinarians[vetIndex - 1];

                    // Reservar cita con todos los datos
                    bool isReserved = appointmentSystem.ReserveAppointment(appointmentTime, customer, pet, veterinarian);

                    if (isReserved)
                    {
                        VisualInterface.GreenColor("Your appointment has been successfully reserved.");
                    }
                    else
                    {
                        VisualInterface.RedColor("Sorry, the selected appointment time is unavailable.");
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
