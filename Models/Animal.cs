namespace Healt_Clinict.Models;
using Healt_Clinict.Thing_Models;


public abstract class Animal
{
    MedicalConsultations medicalConsultation = new MedicalConsultations();
    public string Name { get; set; }
    public string TypeAnimal { get; set; }
    public string Sex { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public string Weight { get; set; }
    public string Symptoms { get; set; }

    private List<MedicalConsultations> medicalConsultations { get; set; } 

    private  List  <MedicalConsultations>MedicalHistory { get; set; } 




}

