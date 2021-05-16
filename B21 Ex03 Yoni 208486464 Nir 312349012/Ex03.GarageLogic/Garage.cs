using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleOwner> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, VehicleOwner>();
        }

        public Dictionary<string,VehicleOwner> Vehicles
        {
            get { return m_Vehicles; }
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool vehicleInGarage = m_Vehicles.ContainsKey(i_LicenseNumber);

            return vehicleInGarage;
        }

        public void InsertVehicleToGarage()
        {

        }

        public void InflateTheWheels(string i_LicenseNumber)
        {

        }

        public void RefuelVehicle(string i_LicenseNumber)
        {

        }

        public void ChargeVehicleBattery(string i_LicenseNumber)
        {

        }

        public void ChangeStatusOfVehicle(string i_LicenseNumber)
        {

        }
    }
}
