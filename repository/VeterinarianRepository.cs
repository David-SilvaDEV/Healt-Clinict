namespace Healt_Clinict.repository;

using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Healt_Clinict.Models;

using Healt_Clinict.database;



public class VeterinarianRepository
{
    public static void Register(Veterinarian NewVeterinarian)
    {
        Warehouse.veterinarians.Add(NewVeterinarian);
    }
    //----------------------------------------------------------------------    
    public static void Delete(Veterinarian veterinarian)
    {
        Warehouse.veterinarians.Remove(veterinarian);
    }
    //--------------------------------------------------------------------------

    
}


