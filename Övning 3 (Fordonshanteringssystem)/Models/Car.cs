using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    internal class Car : Vehicle
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
            Console.Write("Sätter in nyckeln och vrider om.");
            Task.Delay(1000);
            Console.Write(".");
            Task.Delay(1000);
            Console.Write(".");
            Task.Delay(1000);
            Console.WriteLine("Vroom! Bilmotorn är igång.");
        }

        public override void Stats()
        {

        }
    }
}
