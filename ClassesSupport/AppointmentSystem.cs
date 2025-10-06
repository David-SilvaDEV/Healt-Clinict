using System;
using System.Collections.Generic;
using System.Globalization;
namespace Healt_Clinict.ClassesSupport;

public class AppointmentSystem
    
{
    private List<Appointment> appointments;

    public AppointmentSystem()
    {
        appointments = new List<Appointment>();
    }

    // Método para generar citas para un mes y año específicos
    public void GenerateAppointments(int month, int year)
    {
        // Limpiar las citas existentes
        appointments.Clear();

        // Empezamos desde el primer día del mes
        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        int daysInMonth = DateTime.DaysInMonth(year, month);

        // Crear citas con intervalos de 20 minutos
        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime dateDay = new DateTime(year, month, day);
            for (int hour = 9; hour <= 17; hour++)  // Horario de 9:00 AM a 5:00 PM
            {
                for (int minute = 0; minute < 60; minute += 20)  // Citas cada 20 minutos
                {
                    DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);
                    appointments.Add(new Appointment(dateTime));
                }
            }
        }
    }

    // Mostrar las citas disponibles
    public void ShowAvailableAppointments()
    {
        Console.WriteLine("Available Appointments:");
        foreach (var appointment in appointments)
        {
            if (!appointment.ThisReserved)
            {
                Console.ForegroundColor = ConsoleColor.Green;  // Mostrar citas disponibles en verde
                Console.WriteLine(appointment.DateAndTime.ToString("dd/MM/yyyy HH:mm"));
            }
        }
        Console.ResetColor();
    }

    // Reservar una cita
    public bool ReserveAppointment(DateTime dateTime)
    {
        var appointment = appointments.Find(a => a.DateAndTime == dateTime);
        if (appointment != null && !appointment.ThisReserved)
        {
            appointment.Reserve();
            Console.WriteLine("Appointment successfully reserved for: " + dateTime.ToString("dd/MM/yyyy HH:mm"));
            return true;
        }
        else
        {
            Console.WriteLine("The appointment is not available.");
            return false;
        }
    }

    // Mostrar las citas reservadas
    public void ShowReservedAppointments()
    {
        Console.WriteLine("Reserved Appointments:");
        foreach (var appointment in appointments)
        {
            if (appointment.ThisReserved)
            {
                Console.ForegroundColor = ConsoleColor.Red;  // Mostrar citas reservadas en rojo
                Console.WriteLine(appointment.DateAndTime.ToString("dd/MM/yyyy HH:mm"));
            }
        }
        Console.ResetColor();
    }
}
