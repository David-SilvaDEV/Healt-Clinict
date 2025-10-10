using Healt_Clinict.Utils;
using Healt_Clinict.Services;
using Healt_Clinict.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Healt_Clinict.database;
using Healt_Clinict.obj.Models;


namespace Healt_Clinict.ClassesSupport
{
    public class AppointmentSystem
    {
       
        public AppointmentSystem()
        {
            
        }

        
        public void GenerateAppointments(int month, int year)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                for (int hour = 8; hour <= 17; hour++)  // De 8 AM a 5 PM
                {
                    for (int minute = 0; minute < 60; minute += 30)  // Intervalos de 30 minutos
                    {
                        DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);

                        // Solo agregar si no existe ya en la "base de datos"
                        bool exists = Warehouse.appointments.Any(a => a.DateAndTime == dateTime);
                        if (!exists)
                        {
                            Warehouse.appointments.Add(new Appointment(dateTime));
                            // Aquí si usas DB real, insertarlo ahí también
                        }
                    }
                }
            }
        }

        // Reservar una cita y actualizar la base de datos
        public bool ReserveAppointment(DateTime dateTime, Customer customer, Pet pet, Veterinarian veterinarian)
        {
            var appointment = Warehouse.appointments.FirstOrDefault(a => a.DateAndTime == dateTime);

            if (appointment != null && !appointment.IsReserved)
            {
                appointment.Reserve();
                appointment.customer = customer;
                appointment.pet = pet;
                appointment.veterinarian = veterinarian;


                return true;
            }

            return false;
        }

        // Obtener citas reservadas
        public List<Appointment> GetReservedAppointments()
        {
            return Warehouse.appointments.Where(a => a.IsReserved).ToList();
        }

        // Obtener citas disponibles en un día específico
        public List<Appointment> GetAvailableAppointments(DateTime date)
        {
            return Warehouse.appointments.Where(a => a.DateAndTime.Date == date.Date && !a.IsReserved).ToList();
        }
    }
}
