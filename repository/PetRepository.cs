
using Healt_Clinict.database;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
using Healt_Clinict.repository;
using Healt_Clinict.Utils;
using Healt_Clinict.Interfaces;



public class PetRepository : IPetRepository
{
    Customer customer = new Customer();


    public void Register(Pet newPet)
    {
        Warehouse.customers.ForEach(c => c.Pets.Add(newPet));

    }


    public void Delete(Pet petToRemove)
    {

        Warehouse.customers.ForEach(c => c.Pets.Remove(petToRemove));
    }
    //----------------------------------------------------------------------------------------------------------------------


}
