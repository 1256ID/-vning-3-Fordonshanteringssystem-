using System.Threading.Channels;

namespace Fordonshanteringssystem;

internal class Program
{
    public static void Main()
    {
        int index = 0;
        bool programIsRunning = true;
        Program program = new();
        Random random = new Random();
        int randomValue = random.Next(1, 6);


        do
        {
            index = Menu.Display
            (
                "Hantera fordon",
                [
                    "Lägg till fordon",
                    "Ändra på fordon",
                    "Ta bort fordon",
                    "Visa fordon",
                    "Avsluta programmet"
                ], index
            );

            switch (index) 
            {
                case 0:
                    program.AddVehicle();
                    break;
                case 1:
                    program.EditVehicle();
                    break;
                case 2:
                    program.RemoveVehicle();
                    break;
                case 3:
                    program.ShowVehicles();
                    break;
                case 4:
                    programIsRunning = false;
                    break;             
            }
        } while (programIsRunning);

        Environment.Exit(0);

    }

    public void AddVehicle()
    {
        bool addingVehicle = true;

        do
        {
            try
            {

            }

            catch 
            {

            }
        } while (addingVehicle);
    }

    public void EditVehicle()
    {

    }

    public void RemoveVehicle()
    {

    }

    public void ShowVehicles()
    {

    }

}
