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
            A = 1,
            B1,
            AA,
            BB
        }

        public Motorcycle(string i_Manufacturer, string i_PlateLicenseNumber, float i_RemainingEnergy,
            EnergySource.eEnergySourceType i_EnergyType, string i_WheelsManufacturName, float i_CurrentWheelsAirPressure) : 
            base(i_Manufacturer, i_PlateLicenseNumber, i_RemainingEnergy, k_NumberOfWheels,
                k_MaxAirPressure, i_EnergyType, i_WheelsManufacturName, i_CurrentWheelsAirPressure)
        {
            m_EngineDisplacement = 0;
            m_LicenseType = new eLicenseType();
        }

        override public void SetSpecificDetails(params object[] i_Details)
        {
            m_EngineDisplacement = (int)i_Details[0];
            m_LicenseType = (eLicenseType)i_Details[1];
        }

        public override string GetDetails()
        {
            StringBuilder motorcycleDetails = new StringBuilder();

            motorcycleDetails.AppendFormat("{0}", base.GetDetails());
            motorcycleDetails.AppendFormat("License type: {0}{1}", m_LicenseType.ToString(), Environment.NewLine);
            motorcycleDetails.AppendFormat("Engine displacement: {0}{1}",m_EngineDisplacement.ToString(), Environment.NewLine);
            motorcycleDetails.AppendFormat("{0}", EnergySource.GetEnergySourceDetails());

            return motorcycleDetails.ToString();
        }

        public override void setEnergySource(float i_RemainingEnergyPrecentage)
        {
            float maxCapacity;

            if (EnergySource is FuelTank)
            {
                maxCapacity = k_MaxFuelTankCapacity;
                (EnergySource as FuelTank).FuelType = k_FuelType;
            }
            else
            {
                maxCapacity = k_MaxBatteryChargeInHours;
            }

            EnergySource.MaxEnergySourceCapacity = maxCapacity;
            EnergySource.RemainingEnergy = maxCapacity * i_RemainingEnergyPrecentage / 100;
        }


    }
}
