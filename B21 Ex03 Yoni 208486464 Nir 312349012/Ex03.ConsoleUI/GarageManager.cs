using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using System.Reflection;


namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private readonly Garage r_Garage;

        public GarageManager()
        {
            r_Garage = new Garage();
        }

        public void OpenGarage()
        {
            UI.eGarageActions action;
            bool userWantsToQuit = false;
            string openString = "Please choose an action:";
            
            do
            {
                UI.PrintString(openString);
                action = UI.GetActionFromUser();
                UI.ClearScreen();
                switch(action)
                {
                    case UI.eGarageActions.InsertNewVehicle:
                        insertNewVehicleToGarage();
                        break;
                    case UI.eGarageActions.DisplayAllVehiclesInGarage:
                        displayVehiclesInGarage();
                        break;
                    case UI.eGarageActions.ChangeTheStatusOfCar:
                        changeTheStatusOfVehicle();
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
            string licenseNumber = getLicenseNumber();
            bool isAlreadyInGarage = r_Garage.IsVehicleInGarage(licenseNumber);
            Vehicle newVehicle;
            Vehicle.eVehicleType vehicleType = new Vehicle.eVehicleType();
            VehicleFolder.eVehicleStatus newStatus = VehicleFolder.eVehicleStatus.InHandling;


            if (isAlreadyInGarage)
            {
                StringBuilder vehicleInGarage = new StringBuilder();

                r_Garage.ChangeTheStatusOfCar(licenseNumber, newStatus);
                vehicleInGarage.AppendFormat("The vehicle already in the garage. Its Status changed to: {0}", newStatus.ToString());
                UI.PrintString(vehicleInGarage.ToString());
            }
            else
            {
                newVehicle = setNewVehicle(licenseNumber, ref vehicleType);
                string ownerName = getOwnerName();
                string ownerPhoneNumber = getOwnerPhoneNumber();
                setSpecificVehicleParameters(newVehicle);
                r_Garage.InsertNewVehicleToGarage(newVehicle, ownerName, ownerPhoneNumber);
            }
        }

        private void displayVehiclesInGarage()
        {
            string stringToPrint;
            int userChoice = -1, allVehicles = 1;
            List<string> vehiclesToDisplay = null;

            stringToPrint = "Press 0 to display vehicles sorted according to status, and 1 to display all vehicles in the garage: ";
            UI.PrintString(stringToPrint.ToString());
            userChoice = UI.ReadIntFromUser();
            if (userChoice == allVehicles)
            {
                vehiclesToDisplay = r_Garage.DisplayAllVehiclesInGarage(null);
            }
            else
            {
                VehicleFolder.eVehicleStatus statusesInGarage = new VehicleFolder.eVehicleStatus();
                //VehicleFolder.eVehicleStatus statusesInGarage = r_Garage.GetVehicleStatuses();
                userChoice = UI.GetInputAccordingToEnum(statusesInGarage);
                VehicleFolder.eVehicleStatus statusFilter = (VehicleFolder.eVehicleStatus)userChoice;
                vehiclesToDisplay = r_Garage.DisplayAllVehiclesInGarage(statusFilter);
            }

            UI.PrintStringList(vehiclesToDisplay);
        }

        private void changeTheStatusOfVehicle()
        {
            string stringToPrint;
            int userChoice;
            string licenseNumber;
            VehicleFolder.eVehicleStatus statusesInGarage = new VehicleFolder.eVehicleStatus();

            stringToPrint = "Please enter the vehicle number";
            UI.PrintString(stringToPrint);
            licenseNumber = UI.ReadStringFromUser();
            userChoice = UI.GetInputAccordingToEnum(statusesInGarage);
            try
            {
                r_Garage.ChangeTheStatusOfCar(licenseNumber, (VehicleFolder.eVehicleStatus)userChoice);
            }
            catch (ArgumentException exception)
            {
                UI.PrintString(exception.Message); 
            }
        }

        private void inflateTheWheels()
        {
            StringBuilder stringToPrint = new StringBuilder();
            float airToAdd;
            string licenseNumber;

            stringToPrint.Append(@"Please enter the vehicle number");
            UI.PrintString(stringToPrint.ToString());
            licenseNumber = UI.ReadStringFromUser();
            stringToPrint.Append(@"Please enter the amount of air you want to add");
            UI.PrintString(stringToPrint.ToString());
            airToAdd = UI.ReadFloatFromUser();
            try
            {
                r_Garage.InflateTheWheels(licenseNumber, airToAdd);
            }
            catch (Exception exception)
            {
                UI.PrintString(exception.Message);
            }
        }

        private void refuel()
        {
            string stringToPrint;
            float amountOfFuelToAdd;
            FuelTank.eFuelType fuelType = new FuelTank.eFuelType();
            string licenseNumber;
            
            stringToPrint = "Please enter the vehicle number";
            UI.PrintString(stringToPrint.ToString());
            licenseNumber = UI.ReadStringFromUser();

            stringToPrint = "Please enter the fuel type you want to add";
            UI.PrintString(stringToPrint.ToString());

            fuelType = (FuelTank.eFuelType)UI.GetInputAccordingToEnum(fuelType);

            stringToPrint = "Please enter the amount of fuel you want to add";
            UI.PrintString(stringToPrint.ToString());
            amountOfFuelToAdd = UI.ReadFloatFromUser();
            try
            {
                r_Garage.Refuel(licenseNumber, amountOfFuelToAdd, fuelType);
            }
            catch (Exception exception)
            {
                UI.PrintString(exception.Message);
            }
        }

        private void chargeTheBattery()
        {
            string stringToPrint;
            float batteryToAdd;
            string licenseNumber;

            stringToPrint = "Please enter the vehicle number";
            UI.PrintString(stringToPrint.ToString());
            licenseNumber = UI.ReadStringFromUser();

            stringToPrint = "Please enter the amount of battery you want to add";
            UI.PrintString(stringToPrint.ToString());
            batteryToAdd = UI.ReadFloatFromUser();
            try
            {
                r_Garage.ChargeTheBattery(licenseNumber, batteryToAdd);
            }
            catch (Exception exception)
            {
                UI.PrintString(exception.Message);
            }
        }

        private void displayFullDetailsOfVehicle()
        {
            string stringToPrint;
            string licenseNumber, vehicleFullDetails;

            stringToPrint = "Please enter the car number";
            UI.PrintString(stringToPrint.ToString());
            licenseNumber = UI.ReadStringFromUser();
            try
            {
                vehicleFullDetails = r_Garage.DisplayFullDetailsOfVehicle(licenseNumber);
                UI.PrintString(vehicleFullDetails);
            }
            catch (Exception exception)
            {
                UI.PrintString(exception.Message);
            }
           
        }

        private Vehicle setNewVehicle(string i_LicenseNumber, ref Vehicle.eVehicleType io_VehicleType)
        {
            string vehicleManufacturName, wheelsManufacturName;
            EnergySource.eEnergySourceType energyType;
            float remainingEnergy, wheelsCurrentAirPressure;
            Vehicle newVehicle;

            io_VehicleType = getVehicleType();
            energyType = getEnergySource(io_VehicleType);
            vehicleManufacturName = getVehicleManufacturName();
            remainingEnergy = getRemainingEnergy();
            wheelsManufacturName = getWheelsManufacturName();
            wheelsCurrentAirPressure = getWheelsCurrentAirPressure();

            newVehicle = VehicleCreator.CreateTheVehicle(io_VehicleType, vehicleManufacturName, i_LicenseNumber, remainingEnergy,
                energyType, wheelsManufacturName, wheelsCurrentAirPressure);

            return newVehicle;
        }

        //private void setSpecificDetailsForVehicle(Vehicle i_NewVehicle, Vehicle.eVehicleType i_TypeOfVehicle)
        //{
        //    switch(i_TypeOfVehicle)
        //    {
        //        case Vehicle.eVehicleType.Car:
        //            //setCarDetails(i_NewVehicle);
        //            setSpecificVehicleParameters(i_NewVehicle);
        //            break;

        //        case Vehicle.eVehicleType.MotorCycle:
        //            //setMotorcycleDetails(i_NewVehicle);
        //            setSpecificVehicleParameters(i_NewVehicle);
        //            break;

        //        case Vehicle.eVehicleType.Truck:
        //            //setTruckDetails(i_NewVehicle);
        //            setSpecificVehicleParameters(i_NewVehicle);
        //            break;
        //    }
        //}

        private void setSpecificVehicleParameters(Vehicle i_NewVehicle)
        {
            string userInput, finalStateToPrint = "Vehicle entered the garage successfully";
            bool isSetsucceeded = false;
            Dictionary<string, MethodInfo> specificParameters = i_NewVehicle.GetSpecificParameters();

            foreach (KeyValuePair<string, MethodInfo> specificProperty in specificParameters)
            {
                do
                {
                    try
                    {
                        UI.PrintString(specificProperty.Key);
                        userInput = UI.ReadString();
                        specificProperty.Value.Invoke(i_NewVehicle, new object[] { userInput });
                        isSetsucceeded = true;
                    }
                    catch
                    {
                        UI.PrintInvalidInputMessage();
                        isSetsucceeded = false;
                    }

                } while (!isSetsucceeded);
            }   

            UI.ClearScreen();
            UI.PrintString(finalStateToPrint);
        }

        //private void setCarDetails(Vehicle i_NewVehicle)
        //{
        //    Car.eCarColor carColor = getCarColor();
        //    Car.eNumberOfDoors carNumberOfDoors = getCarNumberOfDoors();

        //    i_NewVehicle.SetSpecificDetails(carColor, carNumberOfDoors);
        //}

        //private void setTruckDetails(Vehicle i_NewVehicle)
        //{
        //    float maxCarryingWeight = getTruckMaxCarryingWeight();
        //    bool isCarryingHazardousMaterials = getIfTruckIsCarryingHazardousMaterials();

        //    i_NewVehicle.SetSpecificDetails(maxCarryingWeight, isCarryingHazardousMaterials);
        //}

        //private void setMotorcycleDetails(Vehicle i_NewVehicle)
        //{
        //    int engineDisplacement = getMotorcycleEngineDisplacement();
        //    Motorcycle.eLicenseType licenseType = getMotorcycleLicenseType();

        //    i_NewVehicle.SetSpecificDetails(engineDisplacement, licenseType);
        //}


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
            string stringToPrint = "Please enter the precentage amount of remaining energy (0-100 %):";
            bool isValidPrecent = false, isFirstRun = true; ;
            float remainingEnergy, precentMinRange = 0, precentMaxRange = 100;

            do
            {
                if (!isFirstRun)
                {
                    UI.PrintInvalidInputMessage();
                }
                isFirstRun = false;
                UI.PrintString(stringToPrint);
                remainingEnergy = UI.ReadFloatFromUser();
                isValidPrecent = isNumberInRange(remainingEnergy, precentMinRange, precentMaxRange);
            }
            while (!isValidPrecent);

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
            string stringToPrint = "Please enter the precentage amount of current air pressure (0-100 %):";
            bool isValidPrecent = false, isFirstRun = true; ;
            float wheelsCurrentAirPressurePrecentage, precentMinRange = 0, precentMaxRange = 100;

            do
            {
                if (!isFirstRun)
                {
                    UI.PrintInvalidInputMessage();
                }
                isFirstRun = false;
                UI.PrintString(stringToPrint);
                wheelsCurrentAirPressurePrecentage = UI.ReadFloatFromUser();
                isValidPrecent = isNumberInRange(wheelsCurrentAirPressurePrecentage, precentMinRange, precentMaxRange);
            }
            while (!isValidPrecent);

            return wheelsCurrentAirPressurePrecentage;
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

        //private Car.eCarColor getCarColor()
        //{
        //    Car.eCarColor userChoice = new Car.eCarColor();
        //    string stringToPrint = "Please choose color:";

        //    UI.PrintString(stringToPrint);
        //    userChoice = (Car.eCarColor)UI.GetInputAccordingToEnum(userChoice);

        //    return userChoice;
        //}

        //private Car.eNumberOfDoors getCarNumberOfDoors()
        //{
        //    Car.eNumberOfDoors userChoice = new Car.eNumberOfDoors();
        //    string stringToPrint = "Please choose number of doors:";

        //    UI.PrintString(stringToPrint);
        //    userChoice = (Car.eNumberOfDoors)UI.GetInputAccordingToEnum(userChoice);

        //    return userChoice;
        //}


        //private int getMotorcycleEngineDisplacement()
        //{
        //    int userChoice;
        //    string stringToPrint = "Please choose the engine displacement:";

        //    UI.PrintString(stringToPrint);
        //    userChoice = UI.ReadIntFromUser();

        //    return userChoice;
        //}

        //private Motorcycle.eLicenseType getMotorcycleLicenseType()
        //{
        //    Motorcycle.eLicenseType userChoice = new Motorcycle.eLicenseType();
        //    string stringToPrint = "Please choose the lisence type:";

        //    UI.PrintString(stringToPrint);
        //    userChoice = (Motorcycle.eLicenseType)UI.GetInputAccordingToEnum(userChoice);

        //    return userChoice;
        //}

        //private float getTruckMaxCarryingWeight()
        //{
        //    float userChoice;
        //    string stringToPrint = "Please choose the max carrying weight:";

        //    UI.PrintString(stringToPrint);
        //    userChoice = UI.ReadFloatFromUser();

        //    return userChoice;
        //}

        //private bool getIfTruckIsCarryingHazardousMaterials()
        //{
        //    bool isCarryingHazardousMaterials;
        //    string stringToPrint = "Does the truck can carry hazardous materials? yes/no";
        //    string userChoice, yes = "yes";

        //    UI.PrintString(stringToPrint);
        //    userChoice = UI.ReadYesOrNoFromUser();
        //    isCarryingHazardousMaterials = userChoice.Equals(yes);

        //    return isCarryingHazardousMaterials;
        //}

        private string getLicenseNumber()
        {
            string licenseNumber, stringToPrint = "Please enter license number:";

            UI.PrintString(stringToPrint);
            licenseNumber = UI.ReadStringFromUser();

            return licenseNumber;
        }

        private bool isNumberInRange(float i_Number, float i_Min, float i_Max)
        {
            return i_Number >= i_Min && i_Number <= i_Max;
        }
        
    }
}
