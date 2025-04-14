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

        public override async void StartEngine()
        {
            Console.Write("Slår på huvudströmbrytaren och trycker på startknappen.");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.Write(".");
            await Task.Delay(2000);
            Console.WriteLine("\n\nBrrrmm! Motorcykeln är redo att köra.");
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

        public override string StatsAsString(bool OnSameLine)
        {
            string newLine = "\n";
            if (OnSameLine)
                newLine = " ";
            string output = base.StatsAsString(OnSameLine);
            return output += newLine + $"Har siddel: {HasSidecar}";

        }
        
    }
}
