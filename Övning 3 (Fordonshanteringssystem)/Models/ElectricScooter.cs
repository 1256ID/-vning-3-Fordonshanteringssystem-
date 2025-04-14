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
            set { batteryRange = value; }
        }

        public override async void StartEngine()
        {
            Console.Write("Trycker på strömknappen.");
            await Task.Delay(1000);
            Console.Write(".");
            await Task.Delay(1000);
            Console.Write(".");
            await Task.Delay(1000);
            Console.WriteLine("\n\nMjukt pip. Lamporna tänds. Klar för tyst färd.");
            Console.WriteLine(Utils.continueText);
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
