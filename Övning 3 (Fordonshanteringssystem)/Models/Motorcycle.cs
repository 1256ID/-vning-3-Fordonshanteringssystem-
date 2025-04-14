using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class Motorcycle : Vehicle
    {
        private bool hasSidecar;

        public Motorcycle()
        {
        }

        public bool HasSidecar
        {
            get { return hasSidecar; }
            set { hasSidecar = value; }
        }

        public override void StartEngine()
        {
            Console.Clear();
            Console.WriteLine("Slår på huvudströmbrytaren och trycker på startknappen.");
            Task.Delay(800);
            Console.Write(".");
            Task.Delay(800);
            Console.Write(".");
            Task.Delay(800);
            Console.WriteLine("Brrrmm! Motorcykeln är redo att köra.");
            Console.ReadKey();
            Console.WriteLine(Utils.continueText);
        }

        public override void Stats()
        {
            base.Stats();
            Console.WriteLine
                (
                    $"Har siddel: {HasSidecar}"
                );
        }

    }
}
