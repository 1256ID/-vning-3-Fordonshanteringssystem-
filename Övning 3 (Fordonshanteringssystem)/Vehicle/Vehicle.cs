using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem;

class Vehicle
{
    private string Brand;
    private string Model;
    private int Year;
    private double Weight;

    public Vehicle(string brand, string model, int year, double weight)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
    }

    public List<Vehicle> Vehicles()
    {
        return new List<Vehicle>();
    }

    // Validation methods

    public Vehicle Get
    {
        get { return this; }        
    }

    public string ValidateBrand
    {
        get { return Brand; }
        private set
        {
            Brand = ValidateName(value, nameof(Brand));
        }
    } 

    public string ValidateModel
    {
        get { return Model; }
        private set 
        { 
            Model = ValidateName(value, nameof(Model));
        }
    }

    public int ValidateYear
    {
        get { return Year; }
        private set
        {
            DateTime dateOfToday = DateTime.Today;
            if (value >= 1886 && value <= dateOfToday.Year)
                Year = value;
            else            
                throw new ArgumentException($"{nameof(Year)}: {value}");
            
        }
    }

    public double ValidateWeight
    {
        get { return Weight; }
        private set
        {
            if (value > 0)
                Weight = value;
            else
                throw new ArgumentException("");       
        }
    }

    private string ValidateName(string value, string propName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < 2 || value.Length > 20)
        {
            throw new ArgumentException("");
        }

        return value;
    }

}
