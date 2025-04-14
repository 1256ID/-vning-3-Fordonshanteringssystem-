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

        public override void StartEngine()
        {
            Console.Clear();
            Console.WriteLine("Trycker på strömknappen...");
            Task.Delay(500);
            Console.WriteLine("Mjukt pip. Lamporna tänds. Klar för tyst färd.");
            Console.ReadKey();
            Console.WriteLine(Utils.continueText);
        }
        public override void Stats()
        {
            base.Stats();
            Console.WriteLine
                (
                    $"Batteritid: {batteryRange}"
                );
        }


    }
}
