using Healt_Clinict.ClassesSupport;
using Healt_Clinict.obj.Models;
using Healt_Clinict.Services;

namespace Healt_Clinict.Models
{
    public class Veterinarian : Person
    {
        public List<Appointment> appointments { get; set; }
    }
}
