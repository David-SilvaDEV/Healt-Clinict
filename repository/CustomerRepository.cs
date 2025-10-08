
namespace Healt_Clinict.repository;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
using Healt_Clinict.database;
using Healt_Clinict.Services;
using Healt_Clinict.Interfaces;
using Microsoft.VisualBasic;
using Healt_Clinict.Utils;

public class CustomerRepository : ICustomerRepository
    {   
        
   


    public  void Register(Customer NewCustomer)
    {


        Warehouse.customers.Add(NewCustomer);
        

    }


    //--------------------------------------------------------------------------
    public  void Delete(Customer customer)
    {
        Warehouse.customers.Remove(customer);
    }
    


   

   
    //--------------------------------------------------------------------------

    
}
    
