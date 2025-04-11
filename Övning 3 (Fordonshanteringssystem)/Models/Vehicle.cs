using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem;

public abstract class Vehicle
{
    private string brand;
    private string model;
    private int year;
    private double weight;

    public Vehicle()
    {
        
    } 

    // Validation methods

    public string Brand
    {
        get { return brand; }
        set
        {
            brand = ValidateName(value);
        }
    } 

    public string Model
    {
        get { return model; }
        set 
        { 
            model = ValidateName(value);
        }
    }

    public int Year
    {
        get { return year; }
        set
        {
            DateTime dateOfToday = DateTime.Today;
            if (value >= 1886 && value <= dateOfToday.Year)
                year = value;
            else            
                throw new ArgumentException("Årtalet måste vara mellan 1886 och " + Convert.ToString(dateOfToday.Year));
            
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
                weight = value;
            else
                throw new ArgumentException("Vikten måste vara större än noll.");       
        }
    }

    private string ValidateName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("Inmatningsvärdet får inte vara null/tomt.");
        }

        if (value.Length < 2 || value.Length > 20)
        {
            throw new ArgumentException("Inmatningen måste vara mellan 2 - 20 karaktärer.");
        }

        return value;
    }

    public abstract void StartEngine();
    public abstract void Stats();   

}


