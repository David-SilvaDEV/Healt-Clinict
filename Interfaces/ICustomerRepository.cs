using Healt_Clinict.obj.Models;

namespace Healt_Clinict.Interfaces
{
    public interface ICustomerRepository
    {
        void Register(Customer newCustomer);  
        void Delete(Customer customer);       
    }
}
