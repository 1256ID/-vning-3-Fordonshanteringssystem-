using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Engine
{
    internal abstract class Vehicle : Fordonshanteringssystem.Vehicle
    {      
        public Vehicle(string brand, string model, int year, double weight)
        {
            
        }
      

        public virtual void StartEngine()
        {
            
        }

        public void Stats()
        {

        }

        class Car : Vehicle
        {
            public Car()
            {
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
        }

        class Truck : Vehicle
        {
            private int CargoCapacity;

            public Truck()
            {
            }

            public override void StartEngine()
            {
                Console.Write("Startar tändningen för tung last.");
                Task.Delay(1000);
                Console.Write(".");
                Task.Delay(1000);
                Console.Write(".");
                Task.Delay(1000);
                Console.WriteLine("Djupt mullrande.");
                Task.Delay(1000);
                Console.Write(".");
                Task.Delay(1000);
                Console.Write(".");
                Task.Delay(1000);
                Console.Write(" Lastbilsmotorn går igång med kraft.");
            }


        }

        class Motercycle : Vehicle
        {
            private bool HasSidecar;

            public Motercycle()
            {
            }

            public override void StartEngine()
            {
                Console.WriteLine("Slår på huvudströmbrytaren och trycker på startknappen.");
                Task.Delay(800);
                Console.Write(".");
                Task.Delay(800);
                Console.Write(".");
                Task.Delay(800);
                Console.WriteLine("Brrrmm! Motorcykeln är redo att köra.");
            }
        }

        class ElectricScooter : Vehicle
        {
            private string BatteryRang;

            public ElectricScooter()
            {
            }

            public override void StartEngine()
            {
                Console.WriteLine("Trycker på strömknappen...");
                Task.Delay(500);
                Console.WriteLine("Mjukt pip. Lamporna tänds. Klar för tyst färd.");
            }
        }

    }
}
