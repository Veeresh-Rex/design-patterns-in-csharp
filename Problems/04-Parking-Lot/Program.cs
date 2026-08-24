using System;
using _04_Parking_Lot.Enums;
using _04_Parking_Lot.Models;
using _04_Parking_Lot.Strategies.FeeCalculation;
using _04_Parking_Lot.Strategies.ParkingFindStrategy;

namespace _04_Parking_Lot;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("   WELCOME TO PARKING LOT DEMO SYSTEM ");
        Console.WriteLine("======================================");
        Console.WriteLine();

        // 1. Get ParkingSystem Singleton Instance
        Console.WriteLine("[INFO] Initializing Parking System (Singleton)...");
        ParkingSystem parkingSystem = ParkingSystem.GetInstance();

        // 2. Set Strategies
        Console.WriteLine("[INFO] Configuring Search Strategy and Fee Calculation Strategy...");
        parkingSystem.SetParkingFindStrategy(new FirstAvailableSpotStrategy());
        parkingSystem.SetFeeCalculationStrategy(new FlatRateFeeCalculationStrategy());
        Console.WriteLine();

        // 3. Build Parking Lot Structure (Floors and Spots)
        Console.WriteLine("--- Setting up Parking Floors & Spots ---");
        
        ParkingFloor floor1 = new ParkingFloor("Floor-1");
        floor1.AddParkingSpot(new ParkingSpot("F1-S1-Small", VehicalSize.Small));
        floor1.AddParkingSpot(new ParkingSpot("F1-S2-Medium", VehicalSize.Medium));
        floor1.AddParkingSpot(new ParkingSpot("F1-S3-Large", VehicalSize.Large));

        ParkingFloor floor2 = new ParkingFloor("Floor-2");
        floor2.AddParkingSpot(new ParkingSpot("F2-S1-Small", VehicalSize.Small));
        floor2.AddParkingSpot(new ParkingSpot("F2-S2-Medium", VehicalSize.Medium));

        parkingSystem.AddParkingFloor(floor1);
        parkingSystem.AddParkingFloor(floor2);
        Console.WriteLine("[INFO] Parking Lot configured with 2 Floors.");
        Console.WriteLine("       - Floor-1: 1 Small, 1 Medium, 1 Large spot");
        Console.WriteLine("       - Floor-2: 1 Small, 1 Medium spot");
        Console.WriteLine();

        // 4. Simulate Parking Vehicles
        Console.WriteLine("--- Simulating Vehicle Parking ---");
        Vehical bike1 = new Bike("KA-01-HH-1234");
        Vehical car1 = new Car("KA-02-MH-5678");
        Vehical truck1 = new Truck("KA-03-TR-9999");
        Vehical car2 = new Car("KA-04-AB-4321");

        parkingSystem.ParkVehical(bike1);
        parkingSystem.ParkVehical(car1);
        parkingSystem.ParkVehical(truck1);
        parkingSystem.ParkVehical(car2);
        Console.WriteLine();

        // 5. Edge Case: Attempting to park when matching spots are full
        Console.WriteLine("--- Attempting to Park Vehicle when Lot/Spot is Full ---");
        Vehical truck2 = new Truck("KA-05-TR-8888"); // Needs Large spot, but F1-S3-Large is taken!
        parkingSystem.ParkVehical(truck2);
        Console.WriteLine();

        // 6. Unparking a Vehicle
        Console.WriteLine("--- Unparking Vehicle ---");
        parkingSystem.UnparkVehical(truck1); // Frees F1-S3-Large
        Console.WriteLine();

        // 7. Retrying Parking after spot becomes free
        Console.WriteLine("--- Retrying Parking after freeing up spot ---");
        parkingSystem.ParkVehical(truck2); // Now F1-S3-Large is free!
        Console.WriteLine();

        // 8. Attempting to unpark a non-parked vehicle
        Console.WriteLine("--- Edge Case: Unparking a Vehicle that is not parked ---");
        Vehical bike2 = new Bike("KA-99-XX-0000");
        parkingSystem.UnparkVehical(bike2);
        Console.WriteLine();

        Console.WriteLine("======================================");
        Console.WriteLine("        DEMO COMPLETED SUCCESSFULLY    ");
        Console.WriteLine("======================================");
    }
}
