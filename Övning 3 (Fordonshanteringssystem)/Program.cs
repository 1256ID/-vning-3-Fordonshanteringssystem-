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

    public Vehicle GetUpdatedValue(Vehicle vehicle, int selectedVariable)
    {
        bool addingVehicle = true;

        do
        {
            Console.Clear();
            var type = vehicle.GetType();
            int selectedType = 0;
            string typeName = type.Name;
            if (typeName == "Truck")
                selectedType = 1;
            else if (typeName == "MotorCycle")
                selectedType = 2;
            else if (typeName == "ElectricScooter")
                selectedType = 3;

            var properties = type.GetProperties();
            string stringValue;
            int year;
            double weight;
            int uniqueVariable = 0;
            int count = 0;
            object? newValue = null;



            string[] vehicleTypes =
            {
                "Bil",
                "Motorcykel",
                "Lastbil",
                "El-scooter"
            };

            string[] relevantText = Utils.GetRelatedText(selectedType, false);
            string propName = "";

            foreach (var prop in properties)
            {
                if (count == selectedVariable)
                {
                    propName = prop.Name;
                    newValue = prop.GetValue(vehicle);
                }

                count++;
            }

            if (propName == "HasRoof" || propName == "HasSidecar")
            {
                uniqueVariable = Menu.Display
                (
                   relevantText[0],
                   [
                        "Ja",
                        "Nej"
                   ], uniqueVariable
                );
            }



            else if (propName == "CargoCapacity" || propName == "BatteryRange")
            {
                uniqueVariable = Utils.PromptUserForNumericalInput(relevantText[0]);
            }

            else if (propName == "Brand" || propName == "Model")
            {
                stringValue = Utils.PromptUserForTextInput("Ange märke för " + vehicleTypes[selectedType] + ": ");
            }

            else if (propName == "Year")
            {
                year = Utils.PromptUserForNumericalInput("årstal");
            }

            else if (propName == "Weight")
            {
                weight = Utils.PromptUserForNumericalInput("vikt");
            }

            foreach (var prop in properties)
            {
                if (prop.Name == propName)
                {
                    prop.SetValue(vehicle, newValue);

                }
            }

            Console.Clear();
            Console.WriteLine(relevantText[1] + Utils.continueText);
            Console.ReadKey();
            addingVehicle = false;


        } while (addingVehicle);

        return vehicle;


    }



    public void ManangeVehicles()
    {
        int index = 0;
        int vehicleIndex = 0;
        int propIndex = 0;
        bool editingVehicle = true;


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
                editingVehicle = false;
                break;
            }

            Vehicle selectedVehicle = VehicleHandler._vehicles[vehicleIndex];
            string selectedVehicleAsString = Utils.SavePropsToString(selectedVehicle);

            index = Menu.Display
            (
               "Fordon\n\n" + selectedVehicleAsString + "\n\n",
               [
                   "Ändra på fordonet",
                   "Ta bort fordonet",
                   "Gå tillbaka till förgående meny"
               ], index
            );

            switch (index)
            {
                case 0:

                    string[] selectedVehicleArray = Utils.GetVehicleAsArray(selectedVehicle);
                    Console.Clear();
                    propIndex = Menu.Display
                    (
                        "Fordon\n\n" + selectedVehicleAsString + "\n\n",
                        selectedVehicleArray,
                        propIndex
                    );

                    if (propIndex != selectedVehicleArray.Length - 1)
                    {
                        selectedVehicle = GetUpdatedValue(selectedVehicle, propIndex);
                        VehicleHandler.Update(selectedVehicle, vehicleIndex);
                    }

                    editingVehicle = false;
                    break;


                case 1:

                    RemoveVehicle(index);
                    editingVehicle = false;
                    break;

                case 2:
                    editingVehicle = false;
                    break;



            }

        } while (editingVehicle);

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

        foreach (Vehicle vehicle in VehicleHandler._vehicles)
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

        foreach (Vehicle vehicle in VehicleHandler._vehicles)
        {
            Console.WriteLine("Fordon " + index + 1);
            Utils.PrintAllProperties(vehicle);
            index++;
        }
    }



}
