using System;
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
        //private UI m_UserInterface;

        public GarageManager()
        {
            r_Garage = new Garage();
           // m_UserInterface = new UI();
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
            string licenseNumber = UI.ReadStringFromUser();
            bool isAlreadyInGarage = r_Garage.IsVehicleInGarage(licenseNumber);
            Vehicle newVehicle;
            
            if (isAlreadyInGarage)
            {
                r_Garage.ChangeTheStatusOfCar(licenseNumber, VehicleFolder.eVehicleStatus.InHandling);
            }
            else
            {
                newVehicle = setNewVehicle(licenseNumber);
                string ownerName = getOwnerName();
                string ownerPhoneNumber = getOwnerPhoneNumber();
                //set specific detail
                //add to dictionary
            }

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

        private void changeTheStatusOfCar()
        {
            StringBuilder stringToPrint = new StringBuilder();
            int userChoice;
            string carLicensePlate;
            Enum statusesInGarage = new VehicleFolder.eVehicleStatus();

            stringToPrint.Append(@"Please enter the car number");
            UI.PrintString(stringToPrint.ToString());
            carLicensePlate = UI.ReadStringFromUser();
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
                r_Garage.Refuel(carLicensePlate, fuelToAdd, (FuelTank.eFuelType)userChoice);
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

        private Vehicle setNewVehicle(string i_LicenseNumber)
        {
            string vehicleManufacturName, wheelsManufacturName;
            Vehicle.eVehicleType vehicleType;
            EnergySource.eEnergySourceType energyType;
            float remainingEnergy, wheelsCurrentAirPressure;
            Vehicle newVehicle;

            vehicleType = getVehicleType();
            energyType = getEnergySource(vehicleType);
            vehicleManufacturName = getVehicleManufacturName();
            remainingEnergy = getRemainingEnergy();
            wheelsManufacturName = getWheelsManufacturName();
            wheelsCurrentAirPressure = getWheelsCurrentAirPressure();

            newVehicle = VehicleCreator.CreateTheVehicle(vehicleType, vehicleManufacturName, i_LicenseNumber, remainingEnergy,
                energyType, wheelsManufacturName, wheelsCurrentAirPressure);

            return newVehicle;
        }

        private void setSpecificDetailsForVehicle(Vehicle i_NewVehicle, Vehicle.eVehicleType i_TypeOfVehicle)
        {
            switch(i_TypeOfVehicle)
            {
                case Vehicle.eVehicleType.Car:
                    setCarDetails(i_NewVehicle);
                    break;

                case Vehicle.eVehicleType.MotorCycle:
                    setMotorcycleDetails(i_NewVehicle);
                    break;

                case Vehicle.eVehicleType.Truck:
                    setTruckDetails(i_NewVehicle);
                    break;
            }
        }

        private void setCarDetails(Vehicle i_NewVehicle)
        {
            i_NewVehicle.SetSpecificDetails();
        }

        private void setTruckDetails(Vehicle i_NewVehicle)
        {
            i_NewVehicle.SetSpecificDetails();
        }

        private void setMotorcycleDetails(Vehicle i_NewVehicle)
        {
            i_NewVehicle.SetSpecificDetails();
        }


        private Vehicle.eVehicleType getVehicleType()
        {
            Vehicle.eVehicleType userChoice = new Vehicle.eVehicleType();
            string stringToPrint = "Please choose type of vehicle:";

            UI.PrintString(stringToPrint);
            userChoice = (Vehicle.eVehicleType)UI.GetInputAccordingToEnum(userChoice);

            return userChoice;
        }

        private EnergySource.eEnergySourceType getEnergySource(Vehicle.eVehicleType i_TypeOfVehicle)
        {
            bool isTruck = i_TypeOfVehicle == Vehicle.eVehicleType.Truck;
            string stringToPrint;
            EnergySource.eEnergySourceType energyType = new EnergySource.eEnergySourceType();

            if (!isTruck)
            {
                stringToPrint = "Please choose the energy source:";
                UI.PrintString(stringToPrint);
                energyType = (EnergySource.eEnergySourceType)UI.GetInputAccordingToEnum(energyType);
            }
            else
            {
                energyType = EnergySource.eEnergySourceType.Fuel;
            }

            return energyType;
        }

        private string getVehicleManufacturName()
        {
            string vehicleManufacturName, stringToPrint = "Please enter the vehicle manufactur name:";
            
            UI.PrintString(stringToPrint);
            vehicleManufacturName = UI.ReadStringFromUser();
            
            return vehicleManufacturName;
        }

        private float getRemainingEnergy()
        {
            string stringToPrint = "Please enter the vehicle manufactur name:";
            float remainingEnergy;

            UI.PrintString(stringToPrint);
            remainingEnergy = UI.ReadFloatFromUser();

            return remainingEnergy;
        }

        private string getWheelsManufacturName()
        {
            string wheelsManufacturName, stringToPrint = "Please enter the wheels manufactur name:";

            UI.PrintString(stringToPrint);
            wheelsManufacturName = UI.ReadStringFromUser();

            return wheelsManufacturName;
        }

        private float getWheelsCurrentAirPressure()
        {
            string stringToPrint = "Please enter the current wheels air pressure:";
            float wheelsCurrentAirPressure;

            UI.PrintString(stringToPrint);
            wheelsCurrentAirPressure = UI.ReadFloatFromUser();

            return wheelsCurrentAirPressure;
        }

        private string getOwnerName()
        {
            string ownerName, stringToPrint = "Please enter the owner name:";

            UI.PrintString(stringToPrint);
            ownerName = UI.ReadStringFromUser();

            return ownerName;
        }

        private string getOwnerPhoneNumber()
        {
            string ownerPhoneNumber, stringToPrint = "Please enter the owner phone number:";

            UI.PrintString(stringToPrint);
            ownerPhoneNumber = UI.ReadStringContainsNumbersOnlyFromUser();

            return ownerPhoneNumber;
        }
    }
}
