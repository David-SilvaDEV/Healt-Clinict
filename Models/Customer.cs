namespace Healt_Clinict.obj.Models;

public class Customer : Person
{

    public List<Pet> Pets { get; set; } = new List<Pet>();


    //  public Customer(Guid id, string name, string lastName, int age, string typeDocument, string numberDocument, string email, string phoneNumber)
    //     {
    //         Id = id;
    //         Name = name;
    //         LastName = lastName;
    //         Age = age;
    //         TypeDocument = typeDocument;
    //         NumberDocument = numberDocument;
    //         Email = email;
    //         PhoneNumber = phoneNumber;
    //     }
}
