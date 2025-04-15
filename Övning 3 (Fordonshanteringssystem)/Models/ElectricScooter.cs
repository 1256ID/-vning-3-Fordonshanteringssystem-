using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class ElectricScooter : Vehicle
    {
        private int batteryRange;

        public ElectricScooter()
        {
        }

        public int BatteryRange
        {
            get { return batteryRange; }
            set 
            {
                if (batteryRange != value && batteryRange > 0)
                {
                    batteryRange = value;
                }
            }
        }

        public override void StartEngine()
        {                 
            Console.WriteLine("\n\nMjukt pip. Lamporna tänds. Klar för tyst färd.");
        }
        public override void Stats()
        {
            base.Stats();
            Console.WriteLine
                (
                    $"Batteritid: {BatteryRange}"
                );
        }    


        public override string StatsAsString(bool OnSameLine)
        {
            string newLine = "\n";
            if (OnSameLine)
                newLine = " ";
            string output = base.StatsAsString(OnSameLine);
            return output += newLine + $"Batteritid: {BatteryRange}";
        }


    }
}
