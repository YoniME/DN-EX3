using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

            motorcycleDetails.AppendFormat("Vehicle type: {0}{1}", this.GetType().Name, Environment.NewLine);
            motorcycleDetails.AppendFormat("{0}", base.GetDetails());
            motorcycleDetails.AppendFormat("License type: {0}{1}", m_LicenseType.ToString(), Environment.NewLine);
            motorcycleDetails.AppendFormat("Engine displacement: {0}{1}",m_EngineDisplacement.ToString(), Environment.NewLine);
            motorcycleDetails.AppendFormat("{0}{1}", EnergySource.GetEnergySourceDetails(), Environment.NewLine);
            motorcycleDetails.AppendFormat("{0}", GetWheelsDetails());

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


        public override Dictionary<string, MethodInfo> GetSpecificParameters()
        {
            Dictionary<string, MethodInfo> specificParametersForCar = new Dictionary<string, MethodInfo>();
            specificParametersForCar.Add(@"Please enter the motorcycle engine displacement:", GetType().GetMethod("SetEngineDisplacement"));
            specificParametersForCar.Add(
@"Please enter the license type of the motorcycle:
1. A
2. B1
3. AA
4. BB", GetType().GetMethod("SetLicenseType"));

            return specificParametersForCar;
        }

        public void SetEngineDisplacement(string i_UserInput)
        {
            int engineDisplacement;
            bool isValidInput;

            isValidInput = int.TryParse(i_UserInput, out engineDisplacement);
            if (!isValidInput)
            {
                throw new ArgumentException("Invalid input " + i_UserInput);
            }
            else
            {
                m_EngineDisplacement = engineDisplacement;
            }
        }

        public void SetLicenseType(string i_UserInput)
        {
            int actionNumber;
            bool isValidAction;

            actionNumber = int.Parse(i_UserInput);
            isValidAction = Enum.IsDefined(typeof(eLicenseType), actionNumber);
            if (!isValidAction)
            {
                throw new ArgumentException("Invalid input " + i_UserInput);
            }
            else
            {
                m_LicenseType = (eLicenseType)actionNumber;
            }
        }
    }
}
