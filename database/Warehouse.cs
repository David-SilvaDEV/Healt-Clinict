using Healt_Clinict.ClassesSupport;
using Healt_Clinict.database;
using Healt_Clinict.Models;
using Healt_Clinict.obj.Models;
using System;
using System.Collections.Generic;

namespace Healt_Clinict.database;

public static class Warehouse
{
    public static List<Veterinarian> veterinarians = [];
    public static List<Customer> customers =  [];

    public static List<Appointment> appointments = []; 

    static Warehouse()
    {
        // --- Clientes y Mascotas ---
        var customer1 = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Carlos",
            LastName = "Ramírez",
            Age = 28,
            TypeDocument = "CC",
            NumberDocument = "1002456789"
        };
        customer1.Pets = new List<Pet>
        {
            new Pet("Firulais", "Perro", "Macho", 3, "Marrón", "15kg", "Sano", customer1)
        };
        customers.Add(customer1);

        var customer2 = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Laura",
            LastName = "Gómez",
            Age = 34,
            TypeDocument = "CC",
            NumberDocument = "1003987654"
        };
        customer2.Pets = new List<Pet>
        {
            new Pet("Michi", "Gato", "Hembra", 2, "Blanco", "4kg", "Resfriado leve", customer2)
        };
        customers.Add(customer2);

        var customer3 = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Andrés",
            LastName = "Torres",
            Age = 22,
            TypeDocument = "TI",
            NumberDocument = "1122334455"
        };
        customer3.Pets = new List<Pet>
        {
            new Pet("Rex", "Perro", "Macho", 5, "Negro", "20kg", "Cojea", customer3)
        };
        customers.Add(customer3);

        var customer4 = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Valentina",
            LastName = "Martínez",
            Age = 29,
            TypeDocument = "CC",
            NumberDocument = "1005678912"
        };
        customer4.Pets = new List<Pet>
        {
            new Pet("Luna", "Conejo", "Hembra", 1, "Gris", "1.5kg", "Sano", customer4)
        };
        customers.Add(customer4);

        var customer5 = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Miguel",
            LastName = "Suárez",
            Age = 40,
            TypeDocument = "CE",
            NumberDocument = "890123456"
        };
        customer5.Pets = new List<Pet>
        {
            new Pet("Rocky", "Perro", "Macho", 7, "Café", "25kg", "Dolor en la pata", customer5)
        };
        customers.Add(customer5);

        // --- Veterinarios ---
        var vet1 = new Veterinarian
        {
            Id = Guid.NewGuid(),
            Name = "Ana",
            LastName = "Rodríguez",
            Age = 35,
            TypeDocument = "CC",
            NumberDocument = "1023456789"
        };
        vet1.SetEmail("ana.rodriguez@clinic.com");
        vet1.SetPhoneNumber("3001112233");

        var vet2 = new Veterinarian
        {
            Id = Guid.NewGuid(),
            Name = "Luis",
            LastName = "Fernández",
            Age = 42,
            TypeDocument = "CC",
            NumberDocument = "1034567890"
        };
        vet2.SetEmail("luis.fernandez@clinic.com");
        vet2.SetPhoneNumber("3012223344");

        var vet3 = new Veterinarian
        {
            Id = Guid.NewGuid(),
            Name = "María",
            LastName = "García",
            Age = 29,
            TypeDocument = "TI",
            NumberDocument = "1045678901"
        };
        vet3.SetEmail("maria.garcia@clinic.com");
        vet3.SetPhoneNumber("3023334455");

        veterinarians.Add(vet1);
        veterinarians.Add(vet2);
        veterinarians.Add(vet3);
    }
}
