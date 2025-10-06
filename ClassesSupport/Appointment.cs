

namespace Healt_Clinict.ClassesSupport;

public class Appointment
{
    public DateTime DateAndTime { get; set; }
    public bool ThisReserved { get; set; }

    public Appointment(DateTime dateAndTime)
    {
        DateAndTime = dateAndTime;
        ThisReserved = false;
    }

    public void Reserve()
    {
        ThisReserved = true;
    }

    public void Cancel()
    {
        ThisReserved = false;
    }
}
