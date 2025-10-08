using Healt_Clinict.Models;

namespace Healt_Clinict.obj.Models
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string TypeDocument { get; set; }
        public string NumberDocument { get; set; }

        // Permite valores nulos para Email y PhoneNumber
        private string? Email { get; set; } = null;
        private string? PhoneNumber { get; set; } = null;
        

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void ShowInfoBasic()
        {
            Console.WriteLine($"{Name} {LastName} - Document: {TypeDocument} {NumberDocument}");
            Console.WriteLine($"--");

        }

        public void ShowFullInfo()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Customer Information:");
            Console.WriteLine($"Name: {Name} {LastName}");
            Console.WriteLine($"Last Name:  {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Document: {TypeDocument} {NumberDocument}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine("----------------------------------------");
        }

    }


}   
