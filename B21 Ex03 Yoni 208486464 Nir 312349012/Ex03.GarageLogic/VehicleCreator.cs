using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public Vehicle CreateTheVehicle(Vehicle.eVehicleType i_VehicleType, string i_ManufacturName, string i_LicenseNumber, float i_RemainingEnergy, EnergySource.eTypeOfSource i_SourceType)
        {
            Vehicle vehicleToCreate = null;

			// Check the vehicle type, and create a new instance of it
			switch (i_VehicleType)
			{
				case Vehicle.eVehicleType.Car:
					vehicleToCreate = new Car();
					break;
				case Vehicle.eVehicleType.MotorCycle:
					vehicleToCreate = new Motorcycle();
					break;
				case Vehicle.eVehicleType.Truck:
					vehicleToCreate = new Truck();
					break;
			}

			return vehicleToCreate;
        }
    }
}
