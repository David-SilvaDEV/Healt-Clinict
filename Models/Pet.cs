using System.Buffers;
using Healt_Clinict.Models;

namespace Healt_Clinict.obj.Models
{
    public class Pet : Animal
    {   
        
        public Customer Owner { get; set; }

        // Constructor dentro de la clase
        public Pet(string name, string typeAnimal, string sex, int age, string color, string weight, string symptoms, Customer owner)
        {
            Name = name;
            TypeAnimal = typeAnimal;
            Sex = sex;
            Age = age;
            Color = color;
            Weight = weight;
            Symptoms = symptoms;
            Owner = owner; 
        }
        public Pet() { }

        public Pet(string name, string typeAnimal, string sex, int age, string color, string weight, string symptoms)
        {
            Name = name;
            TypeAnimal = typeAnimal;
            Sex = sex;
            Age = age;
            Color = color;
            Weight = weight;
            Symptoms = symptoms;
        }
    }
}

