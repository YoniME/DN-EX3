using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        /*Consts*/
        private const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 32;
        private const float k_MaxFuelTankCapacity = 45;
        private const float k_MaxBatteryChargeInHours = 3.2f;
        private const FuelTank.eFuelType k_FuelType = FuelTank.eFuelType.Octan95;

        /*Fields*/
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;


        public enum eCarColor
        {
            Red = 1,
            Silver,
            White,
            Black
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public Car(string i_Manufacturer, string i_PlateLicenseNumber, float i_RemainingEnergy,
            EnergySource.eEnergySourceType i_EnergyType, string i_WheelsManufacturName, float i_CurrentWheelsAirPressure) :
            base(i_Manufacturer, i_PlateLicenseNumber, i_RemainingEnergy, k_NumberOfWheels,
                k_MaxAirPressure, i_EnergyType, i_WheelsManufacturName, i_CurrentWheelsAirPressure)
        {
            m_CarColor = new eCarColor();
            m_NumberOfDoors = new eNumberOfDoors();
        }

        override public void SetSpecificDetails(params object[] i_Details)
        {
            m_CarColor = (eCarColor)i_Details[0];
            m_NumberOfDoors = (eNumberOfDoors)i_Details[1];
        }

        public eCarColor Color
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }


        public override string GetDetails()
        {
            StringBuilder carDetails = new StringBuilder();

            carDetails.AppendFormat("{0}", base.GetDetails());
            carDetails.AppendFormat("Color: {0}{1}", m_CarColor.ToString(), Environment.NewLine);
            carDetails.AppendFormat("Number of doors: {0}{1}", m_NumberOfDoors.ToString(), Environment.NewLine);
            carDetails.AppendFormat("{0}", EnergySource.GetEnergySourceDetails());

            return carDetails.ToString();
        }

        public override void setEnergySource(float i_RemainingEnergy)
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
            EnergySource.RemainingEnergy = i_RemainingEnergy;
        }
    }
}
