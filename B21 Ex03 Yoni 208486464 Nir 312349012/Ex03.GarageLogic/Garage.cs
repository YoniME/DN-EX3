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

        public void InsertNewVehicleToGarage()
        {

        }

        private void DisplayAllVehiclesInGarage()
        {

        }

        private void ChangeTheStatusOfCar()
        {

        }

        private void InflateTheWheels(string i_LicenseNumber, float i_AmountToAdd)
        {

        }

        private void Refuel(string i_LicenseNumber, float i_AmountToAdd)
        {

        }

        private void ChargeTheBattery(string i_LicenseNumber, float i_AmountToAdd)
        {

        }

        private void DisplayFullDetailsOfVehicle()
        {

        }
    }
}
