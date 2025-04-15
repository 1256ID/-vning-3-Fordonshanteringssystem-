using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class Truck : Vehicle, ICleanable
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

        public override void StartEngine()
        {
            Console.WriteLine("\n\nLastbilsmotorn går igång med kraft.");
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

        void ICleanable.Clean()
        {                       
            Console.WriteLine("\nLastbilen är nu tvättad.");          
        }
     
    }
}
