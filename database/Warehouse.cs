
using Healt_Clinict.database;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
namespace Healt_Clinict.database;

public static class Warehouse
{
    public static List<Veterinarian> veterinarians = [];
    public static List<Customer> customers = [];
    
        // new Customer
        // {
        //     Id = Guid.NewGuid(),
        //     Name = "Carlos",
        //     LastName = "Ramírez",
        //     Age = 28,
        //     TypeDocument = "CC",
        //     NumberDocument = "1002456789",
        //     //Email = "carlos.ramirez@example.com",
        //     //PhoneNumber = "3004567890",
        //     Pets = new List<Pet>()
        //     {
        //         new Pet("Firulais", "Perro", "Macho", 3, "Marrón", "15kg", "Sano", null!)
        //     }
        // },
        // new Customer
        // {
        //     Id = Guid.NewGuid(),
        //     Name = "Laura",
        //     LastName = "Gómez",
        //     Age = 34,
        //     TypeDocument = "CC",
        //     NumberDocument = "1003987654",
        //     //Email = "laura.gomez@example.com",
        //     // PhoneNumber = "3019876543",
        //     Pets = new List<Pet>()
        //     {
        //         new Pet("Michi", "Gato", "Hembra", 2, "Blanco", "4kg", "Resfriado leve", null!)
        //     }
        // },
        // new Customer
        // {
        //     Id = Guid.NewGuid(),
        //     Name = "Andrés",
        //     LastName = "Torres",
        //     Age = 22,
        //     TypeDocument = "TI",
        //     NumberDocument = "1122334455",
        //     //Email = "andres.torres@example.com",
        //     //PhoneNumber = "3021234567",
        //     Pets = new List<Pet>()
        //     {
        //         new Pet("Rex", "Perro", "Macho", 5, "Negro", "20kg", "Cojea", null!)
        //     }
        // },
        // new Customer
        // {
        //     Id = Guid.NewGuid(),
        //     Name = "Valentina",
        //     LastName = "Martínez",
        //     Age = 29,
        //     TypeDocument = "CC",
        //     NumberDocument = "1005678912",
        //     //Email = "valentina.martinez@example.com",
        //     //PhoneNumber = "3156789123",
        //     Pets = new List<Pet>()
        //     {
        //         new Pet("Luna", "Conejo", "Hembra", 1, "Gris", "1.5kg", "Sano", null!)
        //     }
        // },
        // new Customer
        // {
        //     Id = Guid.NewGuid(),
        //     Name = "Miguel",
        //     LastName = "Suárez",
        //     Age = 40,
        //     TypeDocument = "CE",
        //     NumberDocument = "890123456",
        //     //Email = "miguel.suarez@example.com",
        //     //PhoneNumber = "3168901234",
        //     Pets = new List<Pet>()
        //     {
        //         new Pet("Rocky", "Perro", "Macho", 7, "Café", "25kg", "Dolor en la pata", null!)
        //     }
        // }


    

    static Warehouse()
    {
        var cliente1 = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Carlos",
            LastName = "Ramírez",
            Age = 28,
            TypeDocument = "CC",
            NumberDocument = "1002456789",
            //Email = "carlos.ramirez@example.com",
            //PhoneNumber = "3004567890",
            Pets = []
        };


        var mascota1 = new Pet("Firulais", "Perro", "Macho", 3, "Marrón", "15kg", "Sano", cliente1);

        var cliente2 = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Laura",
            LastName = "Gómez",
            Age = 34,
            TypeDocument = "CC",
            NumberDocument = "1003987654",
            //Email = "laura.gomez@example.com",
            // PhoneNumber = "3019876543",
            Pets = []

        };

        var mascota2 = new Pet("Michi", "Gato", "Hembra", 2, "Blanco", "4kg", "Resfriado leve", cliente2);
    }

}