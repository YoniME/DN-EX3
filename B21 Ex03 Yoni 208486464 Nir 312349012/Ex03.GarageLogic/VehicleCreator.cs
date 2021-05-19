using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle CreateTheVehicle(Vehicle.eVehicleType i_VehicleType, string i_ManufacturName,
			string i_LicenseNumber, float i_RemainingEnergy, EnergySource.eEnergySourceType i_SourceType,
			string i_WheelsManufacturName, float i_WheelsCurrentAirPressurePrecentage)
        {
            Vehicle vehicleToCreate = null;

			// Check the vehicle type, and create a new instance of it
			switch (i_VehicleType)
			{
				case Vehicle.eVehicleType.Car:
					vehicleToCreate = new Car(i_ManufacturName, i_LicenseNumber, i_RemainingEnergy, i_SourceType, i_WheelsManufacturName, i_WheelsCurrentAirPressurePrecentage);
					break;
				case Vehicle.eVehicleType.MotorCycle:
					vehicleToCreate = new Motorcycle(i_ManufacturName, i_LicenseNumber, i_RemainingEnergy, i_SourceType, i_WheelsManufacturName, i_WheelsCurrentAirPressurePrecentage);
					break;
				case Vehicle.eVehicleType.Truck:
					vehicleToCreate = new Truck(i_ManufacturName, i_LicenseNumber, i_RemainingEnergy, i_SourceType, i_WheelsManufacturName, i_WheelsCurrentAirPressurePrecentage);
					break;
			}

			return vehicleToCreate;
        }
    }
}
