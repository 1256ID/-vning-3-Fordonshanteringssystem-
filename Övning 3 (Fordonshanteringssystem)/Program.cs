using System.Threading.Channels;
using Fordonshanteringssystem.Handler;

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
        int selectedType = 0;
        VehicleHandler vehicleHandler = new();

        do
        {
                  
            string brand = "";
            string model = "";
            int year = 0;
            double weight = 0;
            int boolAnswer = 0;
            bool boolValue = false;
            int intAnswer = 0;

            string[] vehicleTypes =
            {
                "Bil",              
                "Motorcykel",
                "Lastbil",
                "El-scooter",
                "Gå tillbaka till förgående meny"
            };
            string[] uniqueVariableQuestion =
            {
                "Har bilen en taklucka?",
                "Har motorcyklen en siddel?",
                "hur många ton klarar lastbilen",
                "hur många batteri-timmar har el-scootern"
            };
           

            Console.WriteLine("Välj vilket typ av fordon du vill skapa");

            selectedType = Menu.Display
                (
                    "Välj typ av fordon",
                    vehicleTypes,
                    selectedType
                );

            brand = Utils.PromptUserForTextInput("Ange märke för " + vehicleTypes[selectedType] + ": ");
            model = Utils.PromptUserForTextInput("Ange model för " + vehicleTypes[selectedType] + ": ");
            year = Utils.PromptUserForNumericalInput("årstal");
            weight = Utils.PromptUserForNumericalInput("vikt");

            if (selectedType == 0 || selectedType == 1)
            {
                boolAnswer = Menu.Display
                    (
                        uniqueVariableQuestion[selectedType],
                        [
                            "Ja",
                            "Nej"
                        ], boolAnswer
                    );

                if (boolAnswer == 0)
                {
                    boolValue = true;
                }
                
            }

            else if (selectedType == 2 || selectedType == 3)
            {
                intAnswer = Utils.PromptUserForNumericalInput(uniqueVariableQuestion[selectedType]);
            }

            if (selectedType == 0)
            {
                vehicleHandler.CreateCar(brand, model, year, weight, boolValue);
                Console.WriteLine("Bilen är nu skapad" + Utils.continueText);
                Console.ReadKey();
                addingVehicle = false;
            }

            else if (selectedType == 1)
            {
                vehicleHandler.CreateMotorCycle(brand, model, year, weight, boolValue);
                Console.WriteLine("Motorcykeln är nu skapad" + Utils.continueText);
                Console.ReadKey();
                addingVehicle = false;
            }

            else if (selectedType == 2)
            {
                vehicleHandler.CreateTruck(brand, model, year, weight, intAnswer);
                Console.WriteLine("Lastbilen är nu skapad" + Utils.continueText);
                Console.ReadKey();
                addingVehicle = false;

            }

            else if (selectedType == 3)
            {
                vehicleHandler.CreateElectricScooter(brand, model, year, weight, intAnswer);
                Console.WriteLine("El-scootern är nu skapad" + Utils.continueText);
                Console.ReadKey();
                addingVehicle = false;
            }

            else if (selectedType == 4)
            {
                addingVehicle = false;
            }

        } while (addingVehicle);
    }

    public void EditVehicle()
    {
        string brand = "";
        string model = "";
        int year = 0;
        double weight = 0;
        int boolAnswer = 0;
        bool boolValue = false;
        int intAnswer = 0;

        ShowVehicles();
        int index = Utils.PromptUserForNumericalInput("nummer på fordonet");


    }

    public void RemoveVehicle()
    {

    }

    public void ShowVehicles()
    {
        VehicleHandler vehicleHandler = new();
        int index = 0;

        foreach (Vehicle vehicle in vehicleHandler.Vehicles)
        {
            Console.WriteLine("Fordon " + index + 1);
            Utils.PrintAllProperties(vehicle);
            index++;
        }   
    }

}
