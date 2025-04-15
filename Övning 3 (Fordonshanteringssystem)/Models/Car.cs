using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class Car : Vehicle
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

        public override async void StartEngine()
        {     
            Console.Write("Sätter in nyckeln och vrider om.");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.WriteLine("Vroom! Bilmotorn är igång.");
            Console.WriteLine(Utils.continueText);      
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


    }
}
