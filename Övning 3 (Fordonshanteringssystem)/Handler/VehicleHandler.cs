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
        public List<Vehicle> _vehicles =
        [
            new Car
            {
                Brand = "Volvo",
                Model = "XC90",
                Year = 2021,
                Weight = 2000,
                HasRoof = true
            },
            new Car
            {
                Brand = "Mazda",
                Model = "MX-5",
                Year = 2020,
                Weight = 1300,
                HasRoof = false
            },
            new Truck
            {
                Brand = "Scania",
                Model = "R450",
                Year = 2019,
                Weight = 8000,
                CargoCapacity = 20000
            },
            new Truck
            {
                Brand = "Volvo",
                Model = "FH16",
                Year = 2022,
                Weight = 8500,
                CargoCapacity = 25000
            },
            new Motorcycle
            {
                Brand = "Harley-Davidson",
                Model = "Street 750",
                Year = 2018,
                Weight = 220,
                HasSidecar = false
            },
            new Motorcycle
            {
                Brand = "Ural",
                Model = "Gear Up",
                Year = 2021,
                Weight = 320,
                HasSidecar = true
            },
            new ElectricScooter
            {
                Brand = "Xiaomi",
                Model = "Mi Scooter Pro 2",
                Year = 2022,
                Weight = 12.5,
                BatteryRange = 45
            },
            new ElectricScooter
            {
                Brand = "E-Wheels",
                Model = "E2S V2",
                Year = 2023,
                Weight = 11.8,
                BatteryRange = 40
            }
        ];

        public VehicleHandler() 
        { 
            
        }

        public void CreateVehicle(string brand, string model, int year, double weight, int uniqueVariable, int selectedType)
        {

            Vehicle vehicle = new Car();
            bool boolValue = false;

            if (selectedType == 0 || selectedType == 2)
                if (uniqueVariable == 0)
                    boolValue = true;

            if (selectedType == 0)
            {

                vehicle = new Car
                {
                    Brand = brand,
                    Model = model,
                    Year = year,
                    Weight = weight,
                    HasRoof = boolValue
                };
            }

            else if (selectedType == 1)
            {
                Vehicle newTruck = new Truck
                {
                    Brand = brand,
                    Model = model,
                    Year = year,
                    Weight = weight,
                    CargoCapacity = uniqueVariable
                };
            }

            else if (selectedType == 2)
            {
                Vehicle newMotorcycle = new Motorcycle
                {
                    Brand = brand,
                    Model = model,
                    Year = year,
                    Weight = weight,
                    HasSidecar = boolValue
                };
            }

            else if (selectedType == 3) 
            {
                Vehicle newElectricScooter = new ElectricScooter
                {
                    Brand = brand,
                    Model = model,
                    Year = year,
                    Weight = weight,
                    BatteryRange = uniqueVariable
                };

            }

                Add(vehicle);

        }

        public void Add(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);          
        }

        public void Update(Vehicle vehicle, int index)
        {           
            _vehicles[index] = vehicle;
        }  
        
        public void Remove(int index)
        {
            _vehicles.RemoveAt(index);
        }

        public int GetVehicleCount()
        {
            return _vehicles.Count();
        }

    }

    interface ICleanable
    {
        void Clean();
    }

   
}
