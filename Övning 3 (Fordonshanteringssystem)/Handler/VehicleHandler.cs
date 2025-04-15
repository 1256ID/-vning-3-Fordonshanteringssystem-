﻿using System;
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
        public List<Vehicle> Vehicles { get; private set; } = [];

        

        public VehicleHandler() 
        { 
            
        }

        public void LoadSampleData()
        {
            Vehicles.AddRange(SampleData.GetSampleVehicles());
        }

        /*
        public void AddCarToMotorcycleList()
        {

            Fråga 1 - 2
           
            List<Motorcycle> motorcycles = [];
            Car vehicle = new Car();
            motorcycles.Add(vehicle);
                                  
                Jag får följande error när jag försöker lägga till class:en <Car> i en motorcykel lista:

                CS1503: Argument 1: cannot convert from 'Fordonshanteringssystem.Car' to 'Fordonshanteringssystem.Motorcycle'

                Detta sker pga att en lista med typ <Motorcycle> enbart kan ta emot objekt av samma typ.

                Det enda sättet att kringå detta är genom att lägga till dem i en List<Vehicle> då både 
                klasserna ärver <Vehicle> och kan därav vara med i samma list så länge den listan är av typ <Vehicle>.

                Detta appliceras även för alla samtliga klasser.
      
        }
        */

        public void test()
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
            Vehicles.Add(vehicle);          
        }

        public void Update(Vehicle vehicle, int index)
        {
            if (index >= 0 && index < Vehicles.Count)    
                Vehicles[index] = vehicle;            
        }  
        
        public void Remove(int index)
        {
            Vehicles.RemoveAt(index);
        }

        public int GetVehicleCount()
        {
            return Vehicles.Count;
        }

    }
}
