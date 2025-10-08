using System.Buffers;
using Healt_Clinict.database;
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

public void ShowAllAnimals()
{
    // Comprobamos si Owner es null
    string ownerInfo = Owner != null
        ? $"{Owner.Name} {Owner.NumberDocument}"  // Si tiene dueño, mostramos el nombre y número de documento
        : "No owner assigned";  // Si no tiene dueño, mostramos un mensaje alternativo

    // Mostramos la información de la mascota
    Console.WriteLine($"- Name: {Name} | Type: ({TypeAnimal}), Age: ({Age} years old), Owner: {ownerInfo}");
}

    }
}

