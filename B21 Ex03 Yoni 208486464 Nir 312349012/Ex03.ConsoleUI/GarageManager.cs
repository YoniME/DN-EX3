﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    class GarageManager
    {
        private readonly Garage r_Garage;
 
        public GarageManager()
        {
            r_Garage = new Garage();
        }

        public static void Main()
        {
            Class1.n();
        }

        public void OpenGarage()
        {
            UI.eGarageActions action;
            bool userWantsToQuit = false;
            
            do
            {
                action = UI.GetActionFromUser();
                switch(action)
                {
                    case UI.eGarageActions.InsertNewVehicle:
                        insertNewVehicleToGarage();
                        break;
                    case UI.eGarageActions.DisplayAllVehiclesInGarage:
                        displayVehiclesInGarage();
                        break;
                    case UI.eGarageActions.ChangeTheStatusOfCar:
                        changeTheStatusOfCar();
                        break;
                    case UI.eGarageActions.InflateTheWheels:
                        inflateTheWheels();
                        break;
                    case UI.eGarageActions.Refuel:
                        refuel();
                        break;
                    case UI.eGarageActions.ChargeTheBattery:
                        chargeTheBattery();
                        break;
                    case UI.eGarageActions.DisplayFullDetailsOfVehicle:
                        displayFullDetailsOfVehicle();
                        break;
                    case UI.eGarageActions.Quit:
                        userWantsToQuit = true;
                        break;

                }
            } 
            while (!userWantsToQuit);
        }

        private void insertNewVehicleToGarage()
        {

        }

        private void displayVehiclesInGarage()
        {
            StringBuilder stringToPrint = new StringBuilder();
            int userChoice = -1;
            List<string> vehiclesToDisplay = null;

            stringToPrint.Append(@"Do you want to display all cars in garage or to sort according to status?
                                   press 1 to display all cars, otherwise press 0...");
            UI.PrintString(stringToPrint.ToString());
            userChoice = UI.ReadIntFromUser();
            if (userChoice == 1)
            {
                vehiclesToDisplay = r_Garage.DisplayAllVehiclesInGarage(null);
            }
            else
            {

                Enum statusesInGarage = r_Garage.GetVehicleStatuses();
                //string[] handlingStatuses = Enum.GetNames(statusesInGarage.GetType());
                userChoice = UI.GetInputAccordingToEnum(statusesInGarage);

                VehicleFolder.eVehicleStatus statusFilter = (VehicleFolder.eVehicleStatus)userChoice;

                vehiclesToDisplay = r_Garage.DisplayAllVehiclesInGarage(statusFilter);
            }

            UI.PrintStringList(vehiclesToDisplay);
        }

        //private void displayAllVehiclesInGarage()
        //{
        //    string[] vehicles = r_Garage.Vehicles.Keys.ToArray();
        //    foreach(string vehicle in vehicles)
        //    {
        //        UI.PrintString(vehicle);
        //    }
        //}

        //private void displayVehiclesInSpecificStatus()
        //{
        //    Enum statusesInGarage = r_Garage.GetVehicleStatuses();
        //    //string[] handlingStatuses = Enum.GetNames(statusesInGarage.GetType());
        //    int userChoice = UI.GetInputAccordingToEnum(statusesInGarage);

           

        //}

        private void changeTheStatusOfCar()
        {
            StringBuilder stringToPrint = new StringBuilder();
            int userChoice;
            string carLicensePlate;

            stringToPrint.Append(@"Please enter the car number");
            UI.PrintString(stringToPrint.ToString());
            carLicensePlate = UI.ReadStringFromUser();
            Enum statusesInGarage = new VehicleFolder.eVehicleStatus();
            userChoice = UI.GetInputAccordingToEnum(statusesInGarage);
            r_Garage.ChangeTheStatusOfCar(carLicensePlate, (VehicleFolder.eVehicleStatus)userChoice);
        }

        private void inflateTheWheels()
        {
            StringBuilder stringToPrint = new StringBuilder();
            float airToAdd;
            string carLicensePlate;

            stringToPrint.Append(@"Please enter the car number");
            UI.PrintString(stringToPrint.ToString());
            carLicensePlate = UI.ReadStringFromUser();
            stringToPrint.Append(@"Please enter the amount of air you want to add");
            UI.PrintString(stringToPrint.ToString());
            airToAdd = UI.ReadFloatFromUser();
            try
            {
                r_Garage.InflateTheWheels(carLicensePlate, airToAdd);
            }
            catch(Exception ex)
            {
                UI.PrintString(ex.Message);
            }
        }

        private void refuel()
        {
            StringBuilder stringToPrint = new StringBuilder();
            float fuelToAdd;
            int userChoice;
            string carLicensePlate;
            
            stringToPrint.Append(@"Please enter the car number");
            UI.PrintString(stringToPrint.ToString());
            carLicensePlate = UI.ReadStringFromUser();

            stringToPrint.Append(@"Please enter the fuel type you want to add");
            UI.PrintString(stringToPrint.ToString());
            carLicensePlate = UI.ReadStringFromUser();
            Enum fuelTypes = new FuelTank.eFuelType();
            userChoice = UI.GetInputAccordingToEnum(fuelTypes);

            stringToPrint.Append(@"Please enter the amount of fuel you want to add");
            UI.PrintString(stringToPrint.ToString());
            fuelToAdd = UI.ReadFloatFromUser();
            try
            {
                r_Garage.Refuel(carLicensePlate, fuelToAdd,(FuelTank.eFuelType)userChoice);
            }
            catch (Exception ex)
            {
                UI.PrintString(ex.Message);
            }
        }

        private void chargeTheBattery()
        {
            StringBuilder stringToPrint = new StringBuilder();
            float batteryToAdd;
            string carLicensePlate;

            stringToPrint.Append(@"Please enter the car number");
            UI.PrintString(stringToPrint.ToString());
            carLicensePlate = UI.ReadStringFromUser();
            stringToPrint.Append(@"Please enter the amount of battery you want to add");
            UI.PrintString(stringToPrint.ToString());
            batteryToAdd = UI.ReadFloatFromUser();
            try
            {
                r_Garage.ChargeTheBattery(carLicensePlate, batteryToAdd);
            }
            catch (Exception ex)
            {
                UI.PrintString(ex.Message);
            }
        }

        private void displayFullDetailsOfVehicle()
        {
            StringBuilder stringToPrint = new StringBuilder();
            string carLicensePlate, vehicleFullDetails;

            stringToPrint.Append(@"Please enter the car number");
            UI.PrintString(stringToPrint.ToString());
            carLicensePlate = UI.ReadStringFromUser();
            try
            {
                vehicleFullDetails = r_Garage.DisplayFullDetailsOfVehicle(carLicensePlate);
                UI.PrintString(vehicleFullDetails);
            }
            catch (Exception ex)
            {
                UI.PrintString(ex.Message);
            }
           
        }
    }
}
