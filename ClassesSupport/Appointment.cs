namespace Healt_Clinict.ClassesSupport
{
    public class Appointment
    {
        public DateTime DateAndTime { get; set; }
        public bool IsReserved { get; set; }

        public Appointment(DateTime dateAndTime)
        {
            DateAndTime = dateAndTime;
            IsReserved = false;
        }

        public void Reserve()
        {
            IsReserved = true;
        }

        public void Cancel()
        {
            IsReserved = false;
        }
    }
}
