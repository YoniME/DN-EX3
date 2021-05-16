using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleFolder> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, VehicleFolder>();
        }

        public Dictionary<string,VehicleFolder> Vehicles
        {
            get { return m_Vehicles; }
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool vehicleInGarage = m_Vehicles.ContainsKey(i_LicenseNumber);

            return vehicleInGarage;
        }

        public VehicleFolder.eVehicleStatus GetVehicleStatuses()
        {
            return new VehicleFolder.eVehicleStatus();
        }

        public void InsertNewVehicleToGarage()
        {
            
        }

        private void DisplayAllVehiclesInGarage()
        {

        }

        private void ChangeTheStatusOfCar()
        {

        }

        public void InflateTheWheels(string i_LicenseNumber, float i_AmountToAdd)
        {

        }

        public void Refuel(string i_LicenseNumber, float i_AmountToAdd)
        {

        }

        public void ChargeTheBattery(string i_LicenseNumber, float i_AmountToAdd)
        {

        }

        private void DisplayFullDetailsOfVehicle()
        {

        }
    }
}
