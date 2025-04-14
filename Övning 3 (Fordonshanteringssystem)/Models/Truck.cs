using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class Truck : Vehicle
    {
        private int cargoCapacity;

        public Truck()
        {
           
        }

        public int CargoCapacity
        {
            get { return cargoCapacity; }
            set { cargoCapacity = value; }
        }
        public override void StartEngine()
        {
            Console.Clear();
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
            Console.ReadKey();
            Console.WriteLine(Utils.continueText);
        }

        public override void Stats()
        {
            base.Stats();
            Console.WriteLine
                (
                    $"Lastkapacitet: {cargoCapacity}"
                );
        }

    }
}
