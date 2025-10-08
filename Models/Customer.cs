using Healt_Clinict.Utils;

namespace Healt_Clinict.obj.Models;

public class Customer : Person
{

    public List<Pet> Pets { get; set; } = new List<Pet>();



    public void ShowMyPets(string specificClient)
    {

        if (NumberDocument.Equals(specificClient))
        {
            Console.Clear();
            Console.WriteLine($"Pets of {Name} {LastName}:");
            VisualInterface.RedColor("[x] No pets available.");
            if (Pets == null || Pets.Count == 0)
            {
                VisualInterface.RedColor("No pets registered for this customer.");
            }
            else
            {
                Pets
            .Select(pet =>
            {
                // Aquí se está ejecutando la acción de imprimir en consola para cada pet
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Type: {pet.TypeAnimal} | Name: {pet.Name} | Age: {pet.Age} | Symptoms: {pet.Symptoms}");
                Console.WriteLine("----------------------------------------");

                return pet;  // Necesitamos devolver algo, por lo que retornamos la mascota
            })
            .ToList(); // Ejecuta la secuencia
            }
        }


        return;
    }






}
