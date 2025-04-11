using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Handler
{
    class VehicleHandler
    {
        private readonly List<Fordonshanteringssystem.Vehicle> _vehicles = [];

        public VehicleHandler() 
        { 
            
        }

        public void Create(string brand, string model, int year, double weight)
        {                      
            Fordonshanteringssystem.Vehicle vehicle = new(brand, model, year, weight);                    
            Add(vehicle);   
        }

        public void Add(Fordonshanteringssystem.Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void Edit(Vehicle vehicle)
        {
            _vehicles.FirstOrDefault(c => c.Equals (vehicle));
        }          

        public IReadOnlyList<Fordonshanteringssystem.Vehicle> Vehicles => _vehicles;

    }

   
}
