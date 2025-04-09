using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Vehicle;

class Vehicle
{
    private string Brand { get; set; }
    private string Model { get; set; }
    private int Year { get; set; }
    private double Weight { get; set; }

    public Vehicle()
    {
        
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

    private string ValidateName(string value, string propName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("");
        }

        if (value.Length < 2 || value.Length > 20)
        {
            throw new ArgumentException("");
        }

        return value;
    }

    public int ValidateYear
    {
        get { return Year; }
        private set
        {
            DateTime dateOfToday = DateTime.Today;
            if (value >= 1886 && value <= dateOfToday.Year)
                Year = value;
        }
    }

    public double ValidateWeight
    {
        get { return Weight; }
        private set
        {
            if (value > 0) 
                Weight = value;
        }
    }

}
