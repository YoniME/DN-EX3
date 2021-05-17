using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        /*Fields*/
        private readonly Dictionary<string, VehicleFolder> r_Vehicles;

        public Garage()
        {
            r_Vehicles = new Dictionary<string, VehicleFolder>();
        }

        public Dictionary<string,VehicleFolder> Vehicles
        {
            get { return r_Vehicles; }
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool vehicleInGarage = r_Vehicles.ContainsKey(i_LicenseNumber);

            return vehicleInGarage;
        }

        public VehicleFolder.eVehicleStatus GetVehicleStatuses()
        {
            return new VehicleFolder.eVehicleStatus();
        }

        public void InsertNewVehicleToGarage()
        {
            
        }

        public List<string> DisplayAllVehiclesInGarage(VehicleFolder.eVehicleStatus? i_VehicleStatusFilter)
        {
            List<string> vehiclesDetails = new List<string>();

            foreach (VehicleFolder vehicle in r_Vehicles.Values)
            {
                if (i_VehicleStatusFilter.HasValue)
                {
                    if (vehicle.Status == i_VehicleStatusFilter)
                    {
                        vehiclesDetails.Add(vehicle.Vehicle.PlateLicenseNumber);
                    }
                }
                else
                {
                    vehiclesDetails.Add(vehicle.Vehicle.PlateLicenseNumber);
                }
            }

            return vehiclesDetails;
        }

        private void ChangeTheStatusOfCar(string i_LicenseNumber, VehicleFolder.eVehicleStatus i_NewStatus)
        {
            checkIfVehicleInGarage(i_LicenseNumber);
            r_Vehicles[i_LicenseNumber].Status = i_NewStatus;
        }

        public void InflateTheWheels(string i_LicenseNumber, float i_AmountToAdd)
        {
            checkIfVehicleInGarage(i_LicenseNumber);
            foreach (Wheel wheel in r_Vehicles[i_LicenseNumber].Vehicle.Wheels)
            {
                wheel.InflateWheel(i_AmountToAdd);
            }
        }

        public void Refuel(string i_LicenseNumber, float i_AmountToAdd, FuelTank.eFuelType i_FuelType)
        {
            EnergySource.eEnergySourceType energyType = EnergySource.eEnergySourceType.Fuel;
            
            checkIfVehicleInGarage(i_LicenseNumber);
            checkIfFillEnergyActionSuitableToEnergySource(i_LicenseNumber, energyType);

            (r_Vehicles[i_LicenseNumber].Vehicle.EnergySource as FuelTank).Refuel(i_AmountToAdd, i_FuelType);
        }

        public void ChargeTheBattery(string i_LicenseNumber, float i_AmountToAdd)
        {
            EnergySource.eEnergySourceType energyType = EnergySource.eEnergySourceType.Electricbattery;

            checkIfVehicleInGarage(i_LicenseNumber);
            checkIfFillEnergyActionSuitableToEnergySource(i_LicenseNumber, energyType);

            (r_Vehicles[i_LicenseNumber].Vehicle.EnergySource as ElectricBattery).Charge(i_AmountToAdd);
        }

        public string DisplayFullDetailsOfVehicle(string i_LicenseNumber)
        {
            checkIfVehicleInGarage(i_LicenseNumber);

            return r_Vehicles[i_LicenseNumber].Vehicle.GetDetails();
        }

        private void checkIfVehicleInGarage(string i_LicenseNumber)
        {
            bool vehicleInGarage = IsVehicleInGarage(i_LicenseNumber);

            if (!vehicleInGarage)
            {
                throw new ArgumentException(
                    string.Format("There is no vehicle with license number: {0} in the Garrage", i_LicenseNumber));
            }
        }

        private void checkIfFillEnergyActionSuitableToEnergySource(string i_LicenseNumber, EnergySource.eEnergySourceType i_TypeOfRequest)
        {
            bool isSuitableAction, isFuelVehicle;

            isFuelVehicle = r_Vehicles[i_LicenseNumber].Vehicle.EnergySource is FuelTank;

            if (i_TypeOfRequest == EnergySource.eEnergySourceType.Fuel)
            {
                isSuitableAction = isFuelVehicle;
            }
            else
            {
                isSuitableAction = !isFuelVehicle;
            }

            if (!isSuitableAction)
            {
                string errorMessage;
                if (isFuelVehicle)
                {
                    errorMessage = "Cannot Charge vehicle with fuel tank";
                }
                else
                {
                    errorMessage = "Cannot fuel vehicle with electric battery";
                }
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
