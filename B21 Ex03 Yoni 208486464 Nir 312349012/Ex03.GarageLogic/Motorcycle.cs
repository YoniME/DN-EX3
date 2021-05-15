using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        /*Consts*/
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 30;
        private const float k_MaxFuelTankCapacity = 6;
        private const float k_MaxBatteryChargeInHours = 1.8f;
        private const FuelTank.eFuelType k_FuelType = FuelTank.eFuelType.Octan98;

        /*Fields*/
        private int m_EngineDisplacement;
        private eLicenseType m_LicenseType;
        

        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }

        public Motorcycle(int i_EngineDisplacement, eLicenseType i_LicenseType,
            string i_Manufacturer, string i_PlateLicenseNumber, float i_RemainingEnergy) : 
            base(i_Manufacturer, i_PlateLicenseNumber, i_RemainingEnergy, k_NumberOfWheels)
        {
            m_EngineDisplacement = i_EngineDisplacement;
            m_LicenseType = i_LicenseType;
            // to see how to create the type of energy source
        }
    }
}
