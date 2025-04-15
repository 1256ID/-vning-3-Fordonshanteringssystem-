using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class Truck : Vehicle
    {
        private int cargoCapacity = 1;

        public Truck()
        {

        }

        public int CargoCapacity
        {
            get { return cargoCapacity; }
            set 
            {
                if (cargoCapacity != value && cargoCapacity > 0)
                {
                    cargoCapacity = value;
                }

                else
                {
                    throw new ArgumentException("Värdet måste vara högre än 0.");
                }
            }
        }
        public override async void StartEngine()
        {
            Console.Write("Startar tändningen för tung last.");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.Write("\nDjupt mullrande.");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.WriteLine("\n\nLastbilsmotorn går igång med kraft.");
            Console.WriteLine(Utils.continueText);
        }

        public override void Stats()
        {
            base.Stats();
            Console.WriteLine
                (
                    $"Lastkapacitet: {CargoCapacity}"
                );
        }

        public override string StatsAsString(bool OnSameLine)
        {
            string newLine = "\n";
            if (OnSameLine)
                newLine = " ";
            string output = base.StatsAsString(OnSameLine);
            return output += newLine + $"Lastkapacitet: {CargoCapacity}";

        }
    }
}
