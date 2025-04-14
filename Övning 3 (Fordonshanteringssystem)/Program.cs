using System;
using System.ComponentModel;
using System.Threading.Channels;
using Fordonshanteringssystem.Handler;
using Fordonshanteringssystem.Models;

namespace Fordonshanteringssystem;

internal class Program
{
    private VehicleHandler VehicleHandler = new();
    public static void Main()
    {
        
        int index = 0;
        bool programIsRunning = true;
        Program program = new();
        program.VehicleHandler.LoadSampleData();
        Random random = new Random();
        int randomValue = random.Next(1, 6);

        do
        {
            string[] vehicleArray = program.GetVehiclesAsArray();
            index = Menu.Display
            (
                "Hantera fordon, Vehicle Count = " + program.VehicleHandler.GetVehicleCount(),
                [
                    "Lägg till fordon",
                    "Hantera fordon",
                    "Avsluta programmet"
                ], index
            );

            switch (index)
            {
                case 0:
                    program.AddVehicle();
                    break;
                case 1:
                    program.ManangeVehicles();
                    break;
                case 2:
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

        do
        {

            Console.Clear();
            string brand = "";
            string model = "";
            int year = 0;
            double weight = 0; ;
            int uniqueVariable = 0;

            string[] vehicleTypes =
            {
                "Bil",
                "Motorcykel",
                "Lastbil",
                "El-scooter"
            };


            string[] uniqueVariableQuestion =
            {
                "Har bilen en taklucka?",
                "Har motorcyklen en siddel?",
                "hur många ton klarar lastbilen",
                "hur många batteri-timmar har el-scootern"
            };

            string[] creationText =
            {
                "Bilen är nu skapad",
                "Motorcykeln är nu skapad",
                "Lastbilen är nu skapad",
                "El-scootern är nu skapad"
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
                uniqueVariable = Menu.Display
                    (
                        uniqueVariableQuestion[selectedType],
                        [
                            "Ja",
                            "Nej"
                        ], uniqueVariable
                    );
            }

            else
            {
                uniqueVariable = Utils.PromptUserForNumericalInput(uniqueVariableQuestion[selectedType]);
            }

            Console.Clear();
            VehicleHandler.CreateVehicle(brand, model, year, weight, uniqueVariable, selectedType);
            Console.WriteLine(creationText[selectedType] + Utils.continueText);
            Console.ReadKey();
            addingVehicle = false;

        } while (addingVehicle);
    }

    public void ManangeVehicles()
    {
        int index = 0;
        int vehicleIndex = 0;
        int propIndex = 0;
        bool managingVehicles = true;     
        do
        {
            Console.Clear();
            string[] vehiclesArray = GetVehiclesAsArray();

            vehicleIndex = Menu.Display
           (
               "Fordon\n",
               vehiclesArray,
               vehicleIndex
           );

            if (vehicleIndex == vehiclesArray.Length - 1)
            {
                managingVehicles = false;
                break;
            }

            Vehicle selectedVehicle = VehicleHandler.Vehicles[vehicleIndex];
            bool selectingVehicle = true;

            while (selectingVehicle)
            {
                Console.Clear();
                string stats = selectedVehicle.StatsAsString(false);
                index = Menu.Display
                (
                      "Fordon\n\n" + stats + "\n\n",
                      [
                          "Starta fordonet",
                           "Ändra på fordonet",
                           "Ta bort fordonet",
                           "Gå tillbaka till förgående meny"
                      ], index
                );

                switch (index)
                {
                    case 0:

                        Console.Clear();
                        selectedVehicle.StartEngine();
                        Console.ReadKey();
                        break;

                    case 1:

                        string[] selectedVehicleArray = Utils.GetVehicleAsArray(selectedVehicle);
                        Console.Clear();
                        propIndex = Menu.Display
                        (
                            "Fordon\n\n",
                            selectedVehicleArray,
                            propIndex
                        );

                        if (propIndex != selectedVehicleArray.Length - 1)
                        {
                            selectedVehicle = GetUpdatedValue(selectedVehicle, propIndex);
                            VehicleHandler.Update(selectedVehicle, vehicleIndex);
                        }
                        
                        break;


                    case 2:

                        RemoveVehicle(index);
                        selectingVehicle = false;
                        break;

                    case 3:
                        selectingVehicle = false;
                        break;

                }               
            }       

        } while (managingVehicles);

    }


    public Vehicle GetUpdatedValue(Vehicle vehicle, int selectedVariable)
    {
        bool addingVehicle = true;

        do
        {
            Console.Clear();
            var type = vehicle.GetType();
            int vehicleType = 0;
            string typeName = type.Name;
            if (typeName == "Truck")
                vehicleType = 1;
            else if (typeName == "MotorCycle")
                vehicleType = 2;
            else if (typeName == "ElectricScooter")
                vehicleType = 3;

            var properties = type.GetProperties();
            int uniqueVariable = 0;
            var newValue = properties[selectedVariable].GetValue(vehicle);
            string[] relevantText = Utils.GetRelatedText(vehicleType, false);
            string selectedPropName = vehicle.GetType()
                .GetProperties()
                .ElementAt(selectedVariable)
                .Name;


            string[] vehicleTypes =
            {
                "Bil",
                "Motorcykel",
                "Lastbil",
                "El-scooter"
            };

            if (selectedPropName == "HasRoof" || selectedPropName == "HasSidecar")
            {
                uniqueVariable = Menu.Display
                (
                   relevantText[0],
                   [
                        "Ja",
                        "Nej"
                   ], uniqueVariable
                );

                if (uniqueVariable == 0)
                {
                    newValue = true;
                }

                else
                {
                    newValue = false;
                }
            }   

            else if (selectedPropName == "CargoCapacity" || selectedPropName == "BatteryRange")
            {
                newValue = Utils.PromptUserForNumericalInput(relevantText[0]);
            }

            else if (selectedPropName == "Brand" || selectedPropName == "Model")
            {
                newValue = Utils.PromptUserForTextInput("Ange märke för " + vehicleTypes[vehicleType] + ": ");
            }

            else if (selectedPropName == "Year")
            {
                newValue = Utils.PromptUserForNumericalInput("årstal");
            }

            else if (selectedPropName == "Weight")
            {
                newValue = Utils.PromptUserForNumericalInput("vikt");
            }

            Console.Clear();

            if (newValue != null && newValue != properties[selectedVariable].GetValue(vehicle))
            {
                properties[selectedVariable].SetValue(vehicle, newValue);
                Console.WriteLine(relevantText[1] + Utils.continueText);
            }
                
            else
            {
                Console.WriteLine("Ingen ändring har gjorts.");
            }
                    
            Console.ReadKey();
            addingVehicle = false;


        } while (addingVehicle);

        return vehicle;


    }



    public void RemoveVehicle(int index)
    {
        VehicleHandler.Remove(index);
        Console.Clear();
        Console.WriteLine("Fordonet har nu tagits bort");
        Console.ReadKey();
    }



    public string[] GetVehiclesAsArray()
    {
        string[] vehicleArray = new string[VehicleHandler.GetVehicleCount() + 1];
        int index = 0;

        foreach (Vehicle vehicle in VehicleHandler.Vehicles)
        {
            vehicleArray[index] = Utils.SavePropsToStringOnSameLine(vehicle);
            index++;
        }

        vehicleArray[index] = "Gå tillbaka till förgående meny";

        return vehicleArray;
    }


    public void ShowVehicles()
    {

        int index = 0;

        foreach (Vehicle vehicle in VehicleHandler.Vehicles)
        {
            Console.WriteLine("Fordon " + index + 1);
            
            index++;
        }
    }



}
