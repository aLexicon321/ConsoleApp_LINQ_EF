using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ConsoleApp_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from LINQ and EF");

            VehicleContext db = new VehicleContext();

            /*
            MotorCompany new_Company = new MotorCompany("LexiCars AB");
            
            Car new_Volvo = new Car("Volvo", "XC90", 2020, 190);
            Car new_Saab = new Car("Saab", "9000", 2002, 170);

            List<Car> new_Cars = new List<Car>();
            new_Cars.Add(new_Volvo);
            new_Cars.Add(new_Saab);

            new_Company.Cars = new_Cars;
            db.Companies.Add(new_Company);
            db.SaveChanges();
            Console.WriteLine("SaveChanges - Done, Check DB...");
            */


            // LINQ Find - This give us same result
            Car carWithId = db.Cars.Where(car => car.Id == 1).Include(car => car.Company).FirstOrDefault();
            Car carWithCompanyAndId = db.Cars.Where(car => car.Id == 1).Include("Company").FirstOrDefault();

            // Addning new company
            MotorCompany my_Company = new MotorCompany("ALexi CarsAndBikes AB");

            //Adding a Motorcycle to company
            List<Motorcycle> company_motorcycles = new List<Motorcycle>();
            Motorcycle new_Motorcycle = new Motorcycle("Yamaha", "VMax", 2017, 320);
            company_motorcycles.Add(new_Motorcycle);

            my_Company.Motorcycles = company_motorcycles;
            db.Companies.Add(my_Company);
            
            // uncomment [db.SaveChanges] to save data to database
            //db.SaveChanges();

            Console.ReadLine();
        }
    }

    class MotorCompany
    {
        public MotorCompany(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
        public List<Motorcycle> Motorcycles { get; set; }
    }

    class Vehicle
    {
        public Vehicle(string brand, string model, int year, int speed)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Speed = speed;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Speed { get; set; }
        public int MotorCompanyId { get; set; }
        public MotorCompany Company { get; set; }
    }

    class Car : Vehicle
    {
        public Car(string brand, string model, int year, int speed) : base(brand, model, year, speed)
        {
        }
    }

    class Motorcycle : Vehicle
    {
        public Motorcycle(string brand, string model, int year, int speed) : base(brand, model, year, speed)
        {
        }
    }

    class VehicleContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<MotorCompany> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Vehicle_LINQ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

}