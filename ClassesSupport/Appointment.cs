using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;

namespace Healt_Clinict.ClassesSupport
{
    public class Appointment
    {
        public DateTime DateAndTime { get; set; }
        public bool IsReserved { get; set; }

        public Customer customer { get; set; }

        public Pet pet  { get; set;}

        public Veterinarian veterinarian {get; set;} 

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
