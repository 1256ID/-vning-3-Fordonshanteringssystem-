using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.SystemError;

public abstract class SystemError
{
    protected abstract void ErrorMessage();
    

    class EngineFailureError
    {
        private string errorMessage = "Motorfel: Kontrollera motorstatus!";

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }

    class BrakeFailureError
    {
        private string errorMessage = "Bromsfel: Fordonet är osäkert att köra!";

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }


    class TransmissionError
    {
        private string errorMessage = "Växellådsproblem: Reparation krävs!";

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }

}

