namespace Healt_Clinict.repository;

using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Healt_Clinict.Models;
using Healt_Clinict.Interfaces;
using Healt_Clinict.database;



public class VeterinarianRepository: IVeterinarianRepository
{
    public  void Register(Veterinarian NewVeterinarian)
    {
        Warehouse.veterinarians.Add(NewVeterinarian);
    }
    //----------------------------------------------------------------------    
    public  void Delete(Veterinarian veterinarian)
    {
        Warehouse.veterinarians.Remove(veterinarian);
    }
    //--------------------------------------------------------------------------

    
}


