using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Car car = new Car(101, "Toyota", 100, 5);
        Motorcycle motorcycle = new Motorcycle(102, "Yamaha", 50, 150);

        List<Vehicle> vehicles = new List<Vehicle>();

        vehicles.Add(car);
        vehicles.Add(motorcycle);

        Console.WriteLine("Vehicle Rental Costs");

        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.displayInfo();
            Console.WriteLine($" -> Cost for 3 days: ${vehicle.calculateRentalCost(3):F2}");
        }

        Console.WriteLine();

        Customer customer = new Customer("Alice", "AB1234");

        customer.rentVehicle(car);
        customer.printRentalSummary(5);
    }
}

class Vehicle
{
    protected int vehicleId;
    protected  string brand;
    protected  double dailyRate;

    public Vehicle(int vehicleId, string brand, double dailyRate)
    {
        this.vehicleId = vehicleId;
        this.brand = brand;
        this.dailyRate = dailyRate;
    }

    public virtual double calculateRentalCost(int days)
    {
        return dailyRate * days;
    }

    public virtual void displayInfo()
    {
        Console.WriteLine($"Vehicle ID={vehicleId}, Brand={brand}");
    }
}

class Car : Vehicle
{
    int numSeats;

    public Car(int vehicleId, string brand, double dailyRate, int numSeats)
        : base(vehicleId, brand, dailyRate)
    {
        this.numSeats = numSeats;
    }

    public override double calculateRentalCost(int days)
    {
        return dailyRate * days * 1.10;
    }

    public override void displayInfo()
    {
        Console.WriteLine($"Car ID={vehicleId}, Brand={brand}, Seats={numSeats}");
    }
}

class Motorcycle : Vehicle
{
    int engineCapacity;

    public Motorcycle(int vehicleId, string brand, double dailyRate, int engineCapacity)
        : base(vehicleId, brand, dailyRate)
    {
        this.engineCapacity = engineCapacity;
    }

    public override double calculateRentalCost(int days)
    {
        return dailyRate * days * 0.95;
    }

    public override void displayInfo()
    {
        Console.WriteLine($"Motorcycle ID={vehicleId}, Brand={brand}, CC={engineCapacity}");
    }
}

class Customer
{
    string name;
    string licenseNumber;
    Vehicle rentedVehicle;

    public Customer(string name, string licenseNumber)
    {
        this.name = name;
        this.licenseNumber = licenseNumber;
        rentedVehicle = null;
    }

    public void rentVehicle(Vehicle vehicle)
    {
        rentedVehicle = vehicle;
    }

    public void returnVehicle()
    {
        rentedVehicle = null;
    }

    public void printRentalSummary(int days)
    {
        Console.WriteLine("Customer Rental Summary---");
        Console.WriteLine($"Customer: {name} (License: {licenseNumber})");
        Console.WriteLine();

        if (rentedVehicle != null)
        {
            rentedVehicle.displayInfo();
            Console.WriteLine($"Total Cost for {days} days: ${rentedVehicle.calculateRentalCost(days):F2}");
        }
        else
        {
            Console.WriteLine("No vehicle currently rented.");
        }
    }
}


