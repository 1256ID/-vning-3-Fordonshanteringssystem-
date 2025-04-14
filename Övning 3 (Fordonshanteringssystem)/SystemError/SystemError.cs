using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem;

public abstract class SystemError
{
    public abstract string ErrorMessage();
       
}

class EngineFailureError : SystemError
{
    private string errorMessage = "Motorfel: Kontrollera motorstatus!";


    public EngineFailureError()
    {

    }


    public override string ErrorMessage()
    {
        return errorMessage;
    }
}

class BrakeFailureError : SystemError
{
    private string errorMessage = "Bromsfel: Fordonet är osäkert att köra!";

    public BrakeFailureError()
    {

    }
    public override string ErrorMessage()
    {
        return errorMessage;
    }
}


class TransmissionError : SystemError
{
    private string errorMessage = "Växellådsproblem: Reparation krävs!";

    public TransmissionError()
    {

    }

    public override string ErrorMessage()
    {
        return errorMessage;
    }
}

