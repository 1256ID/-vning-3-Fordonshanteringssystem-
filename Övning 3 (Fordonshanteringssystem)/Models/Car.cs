using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class Car : Vehicle, ICleanable
    {
        private bool hasRoof;

        public Car()
        {
        }

        public bool HasRoof
        {
            get { return hasRoof; }
            set {  hasRoof = value; }                
        }       

        public override void StartEngine()
        {                
            Console.WriteLine("\nVroom! Bilmotorn är igång.");             
        }

        public override void Stats()
        {
            base.Stats();
            Console.WriteLine
                (
                    $"Bilen har ett tak: {HasRoof}"
                );
        }

        public override string StatsAsString(bool OnSameLine)
        {
            string newLine = "\n";
            if (OnSameLine)
                newLine = " ";
            string output = base.StatsAsString(OnSameLine);
            return output += newLine + $"Biltak: {HasRoof}";
            
        }

        public override string[] StatsAsStringArray()
        {
            string[] array = base.StatsAsStringArray();
            array[4] = $"Biltak: {HasRoof}";
            array[5] = "Gå tillbaka till förgående meny";

            return array;
        }

        public void Clean()
        {
            Console.WriteLine("\nBilen är nu tvättad.");
            
        }
    }
}
