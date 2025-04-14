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

        public override void StartEngine()
        {
            Console.Clear();
            Console.Write("Sätter in nyckeln och vrider om.");
            Task.Delay(1000);
            Console.Write(".");
            Task.Delay(1000);
            Console.Write(".");
            Task.Delay(1000);
            Console.WriteLine("Vroom! Bilmotorn är igång.");
            Console.ReadKey();
            Console.WriteLine(Utils.continueText);
        }

        public override void Stats()
        {
            base.Stats();
            Console.WriteLine
                (
                    $"Bilen har ett tak: {hasRoof}"
                );
        } 
    }
}
