using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.SystemError
{
    public abstract class SystemError
    {
        protected abstract void ErrorMessage();
        

        class EngineFailureError
        {

        }

        class BrakeFailureError
        {

        }

        class TransmissionError
        {

        }


    }
}
