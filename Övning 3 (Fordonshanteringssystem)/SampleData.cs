using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fordonshanteringssystem.Models;

namespace Fordonshanteringssystem;

public class SampleData
{
    public static List<Vehicle> GetSampleVehicles()
    {
        return
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

    }
}
