using Healt_Clinict.ClassesSupport;
using Healt_Clinict.database;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
using Healt_Clinict.Utils;
using System;
using System.Linq;

namespace Healt_Clinict.Services
{
    public class AppointmentServices
    {
        public AppointmentSystem AppointmentSystem { get; }

        public AppointmentServices(AppointmentSystem appointmentSystem)
        {
            AppointmentSystem = appointmentSystem;
        }

      

        public void CreateAppointmentMenu()
        {
            AppointmentSystem appointmentSystem = new AppointmentSystem();
            var reservationsSystem = new Healt_Clinict.ClassesSupport.ReservationsSystem();
         
            

            ServicesValidation.ReturnToMenu();
        }
    }
}
