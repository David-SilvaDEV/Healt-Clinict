namespace Healt_Clinict.Models
{
    public static class Services
    {
        public void RegisterCustomer()
        {
            Console.Clear();
            Console.WriteLine("-[section of Register Customer ]-");
            Console.WriteLine("");

            Console.WriteLine("Write the ID number:");
            int id = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Write the patient's name:");
            string name = Console.ReadLine() ?? "";

            int age = -1; // Inicializamos en un valor negativo para entrar en el ciclo

            // Validación de la edad
            while (age < 0)
            {
                try
                {
                    Console.WriteLine("Write patient age:");
                    age = int.Parse(Console.ReadLine() ?? "");

                    if (age < 0)
                    {
                        Console.WriteLine("Age must be a positive number. Please enter a valid age.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }

            Console.WriteLine("Write the patient's symptoms:");
            string symptoms = Console.ReadLine() ?? "";

            Patient newPatient = new Patient(id, name, age, symptoms);
            Patients.Add(newPatient);

            Console.WriteLine($"The patient {newPatient.Name} has been added successfully.");
            RegisterPet();
        }
    }
}