using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class ElectricScooter : Vehicle
    {
        private int batteryRang;

        public ElectricScooter()
        {
        }

        public int BatteryRang
        {
            get { return batteryRang; }
            set { batteryRang = value; }
        }

        public override void StartEngine()
        {
            Console.WriteLine("Trycker på strömknappen...");
            Task.Delay(500);
            Console.WriteLine("Mjukt pip. Lamporna tänds. Klar för tyst färd.");
        }

        public override void Stats()
        {

        }
    }
}
