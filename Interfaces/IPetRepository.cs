using Healt_Clinict.obj.Models;

namespace Healt_Clinict.Interfaces;

public interface IPetRepository
{

    void Delete(Pet petToRemove);
}
