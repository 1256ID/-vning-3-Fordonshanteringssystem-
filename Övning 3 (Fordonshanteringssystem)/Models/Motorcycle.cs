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
            Console.WriteLine("\n\nBrrrmm! Motorcykeln är redo att köra.");    
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
