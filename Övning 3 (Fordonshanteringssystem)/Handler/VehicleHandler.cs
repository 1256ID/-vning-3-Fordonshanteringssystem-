using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Handler
{
    class VehicleHandler
    {
        private readonly List<Vehicle> _vehicles;


        public VehicleHandler() 
        { 
        
        }
        
        
        
        public void Create_Vehicle(string brand, string model, int year, double weight)
        {    
            Vehicle vehicle = new(brand, model, year, weight);
            _vehicles.Add(vehicle);
            
        }

        public void Edit_Vehicle(Vehicle vehicle)
        {

        }
        
        public void List_Vehicles()
        {

            
                
        }
        
    }
}
