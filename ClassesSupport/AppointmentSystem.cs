namespace Healt_Clinict.ClassesSupport
{
    public class AppointmentSystem
    {
        private List<Appointment> appointments = new List<Appointment>();

        // Método para generar citas para un mes y año específicos
        public void GenerateAppointments(int month, int year)
        {
            DateTime startDate = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Rango de horas: 8 AM a 5 PM con intervalos de 30 minutos
            for (int day = 1; day <= daysInMonth; day++)
            {
                for (int hour = 8; hour <= 17; hour++)  // De 8 AM a 5 PM
                {
                    for (int minute = 0; minute < 60; minute += 30)  // Intervalos de 30 minutos
                    {
                        DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);
                        appointments.Add(new Appointment(dateTime));
                    }
                }
            }
        }

        // Método para reservar una cita
        public bool ReserveAppointment(DateTime dateTime)
        {
            var appointment = appointments.FirstOrDefault(a => a.DateAndTime == dateTime);
            if (appointment != null && !appointment.IsReserved)
            {
                appointment.Reserve();
                return true;
            }
            return false;
        }

        // Método para obtener todas las citas reservadas
        public List<Appointment> GetReservedAppointments()
        {
            return appointments.Where(a => a.IsReserved).ToList();
        }

        // Método para obtener todas las citas disponibles en un día específico
        public List<Appointment> GetAvailableAppointments(DateTime date)
        {
            return appointments.Where(a => a.DateAndTime.Date == date.Date && !a.IsReserved).ToList();
        }

        public AppointmentSystem()
        {
            // Inicialización del sistema de citas
        }
    }
}
