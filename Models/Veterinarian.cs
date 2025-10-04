using Healt_Clinict.obj.Models;
using Healt_Clinict.Thing_Models;
namespace Healt_Clinict.Models;

public class Veterinarian : Person
{
    private List<MedicalConsultations> Consultations  { get; set; }
}
