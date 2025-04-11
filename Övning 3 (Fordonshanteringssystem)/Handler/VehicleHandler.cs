using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fordonshanteringssystem.Models;

namespace Fordonshanteringssystem.Handler
{
    class VehicleHandler
    {
        private readonly List<Fordonshanteringssystem.Vehicle> _vehicles = [];

        public VehicleHandler() 
        { 
            
        }

        public void CreateCar(string brand, string model, int year, double weight, bool hasRoof)
        {
            Vehicle newCar = new Car
            {
                Brand = brand,
                Model = model,
                Year = year,
                Weight = weight,
                HasRoof = hasRoof
            };          

            Add(newCar);   
        }

        public void CreateTruck(string brand, string model, int year, double weight, int cargoCapacity)
        {
            Vehicle newTruck = new Truck
            {
                Brand = brand,
                Model = model,
                Year = year,
                Weight = weight,
                CargoCapacity = cargoCapacity
            };

            Add(newTruck);
        }

        public void CreateMotorCycle(string brand, string model, int year, double weight, bool hasSideCar)
        {
            Vehicle newMotorcycle = new Motercycle 
            { 
                Brand = brand,
                Model = model,
                Year = year,
                Weight = weight,
                HasSidecar = hasSideCar
            };

            Add(newMotorcycle);
        }

        public void CreateElectricScooter(string brand, string model, int year, double weight, int batteryRang)
        {
            Vehicle newElectricScooter = new ElectricScooter
            {
                Brand = brand,
                Model = model,
                Year = year,
                Weight = weight,
                BatteryRang = batteryRang
            };

            Add(newElectricScooter);
        }

        public void Add(Fordonshanteringssystem.Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void Edit(Vehicle vehicle, int index)
        {           
            _vehicles[index] = vehicle;
        }  
        
        public void Remove(Vehicle vehicle, int index)
        {
            _vehicles.RemoveAt(index);
        }

        public IReadOnlyList<Fordonshanteringssystem.Vehicle> Vehicles => _vehicles;

    }

   
}
