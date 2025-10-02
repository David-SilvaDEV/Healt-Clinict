namespace Healt_Clinict.obj.Models
{
    public abstract class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string TypeDocument { get; set; }

        public  String NumberDocument { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; } 
        
        
    }
}