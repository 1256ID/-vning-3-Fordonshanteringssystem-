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
                throw new ArgumentException("Vikten måste vara högre än noll.");       
        }
    } 

    private static string ValidateName(string value)
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
    public virtual void Stats()
    {
        Console.WriteLine
            (
                $"Märke: {Brand}\n" +
                $"Modell: {Model}\n" +
                $"Årtal: {Year}\n" +
                $"Vikt: {Weight}\n" 
            );
    }


    public virtual string StatsAsString(bool OnSameLine)
    {
        string newLine = "\n";

        if (OnSameLine)
            newLine = " ";


        return  $"Märke: {Brand}" + newLine +
                $"Modell: {Model}" + newLine +
                $"Årtal: {Year}" + newLine + 
                $"Vikt: {Weight}";
    }

    public virtual string[] StatsAsStringArray()
    {
        string[] array = new string[6];

        array[0] = $"Märke: {Brand}";
        array[1] = $"Modell: {Model}";
        array[2] = $"Årtal: {Year}";
        array[3] = $"Vikt: {Weight}";


        return array;
    }   
}

/*
     Fråga 4

    Vad är fördelarna med att använda ett interface här istället för arv?

    En klass kan enbart ärva en basklass medans den kan ärva flera interfaces. 
    Så ifall en klass enbart ärver från en basklass så måste alla metoder, variabler 
    ärvas från en klass medans ifall vi använder oss av interfaces så kan vi ärva från 
    flera och separera logik så att allt inte ligger på ett och samma ställe.
    
*/

public interface ICleanable
{
    void Clean();
       
}




