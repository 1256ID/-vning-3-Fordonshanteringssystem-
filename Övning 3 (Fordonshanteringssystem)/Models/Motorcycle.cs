﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    class Motercycle : Vehicle
    {
        private bool hasSidecar;

        public Motercycle()
        {
        }

        public bool HasSidecar
        {
            get { return hasSidecar; }
            set { hasSidecar = value; }
        }

        public override void StartEngine()
        {
            Console.WriteLine("Slår på huvudströmbrytaren och trycker på startknappen.");
            Task.Delay(800);
            Console.Write(".");
            Task.Delay(800);
            Console.Write(".");
            Task.Delay(800);
            Console.WriteLine("Brrrmm! Motorcykeln är redo att köra.");
        }
        public override void Stats()
        {

        }
    }
}
