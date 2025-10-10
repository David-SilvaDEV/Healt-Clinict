using Healt_Clinict.Models;

namespace Healt_Clinict.Interfaces;

public interface IVeterinarianRepository
{

    void Register(Veterinarian NewVeterinarian);

    void Delete(Veterinarian veterinarian);
}
