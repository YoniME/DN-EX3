using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        /*Consts*/
        private const int k_NumberOfWheels = 16;
        private const float k_MaxAirPressure = 26;
        private const float k_MaxFuelTankCapacity = 120;
        private const FuelTank.eFuelType k_FuelType = FuelTank.eFuelType.Soler;

        /*Fields*/
        private float m_MaxCarryingWeight;
        private bool m_IsCarryingHazardousMaterials;

        
        public Truck(string i_Manufacturer, string i_PlateLicenseNumber, float i_RemainingEnergy,
            EnergySource.eEnergySourceType i_EnergyType, string i_WheelsManufacturName, float i_CurrentWheelsAirPressure) :
            base(i_Manufacturer, i_PlateLicenseNumber, i_RemainingEnergy, k_NumberOfWheels,
                k_MaxAirPressure, i_EnergyType, i_WheelsManufacturName, i_CurrentWheelsAirPressure)
        {
            m_MaxCarryingWeight = 0;
            m_IsCarryingHazardousMaterials = false;
        }

        override public void SetSpecificDetails(params object[] i_Details)
        {
            m_MaxCarryingWeight = (float)i_Details[0];
            m_IsCarryingHazardousMaterials = (bool)i_Details[1];
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
            set { m_MaxCarryingWeight = value; }
        }

        public bool IsCarryingHazardousMaterials
        {
            get { return m_IsCarryingHazardousMaterials; }
            set { m_IsCarryingHazardousMaterials = value; }
        }

        public override string GetDetails()
        {
            StringBuilder truckDetails = new StringBuilder();

            truckDetails.AppendFormat("{0}", base.GetDetails());
            truckDetails.AppendFormat("Is carrying hazardous materials: {0}{1}", m_IsCarryingHazardousMaterials.ToString(), Environment.NewLine);
            truckDetails.AppendFormat("Max carrying weight: {0}{1}", m_MaxCarryingWeight.ToString(), Environment.NewLine);
            truckDetails.AppendFormat("{0}{1}", EnergySource.GetEnergySourceDetails(), Environment.NewLine);
            truckDetails.AppendFormat("{0}", GetWheelsDetails());

            return truckDetails.ToString();
        }

        public override void setEnergySource(float i_RemainingEnergyPrecentage)
        {
            (EnergySource as FuelTank).FuelType = k_FuelType;
            EnergySource.MaxEnergySourceCapacity = k_MaxFuelTankCapacity;
            EnergySource.RemainingEnergy = k_MaxFuelTankCapacity * i_RemainingEnergyPrecentage / 100;
        }

        public override Dictionary<string, MethodInfo> GetSpecificParameters()
        {
            Dictionary<string, MethodInfo> specificParametersForCar = new Dictionary<string, MethodInfo>();
            specificParametersForCar.Add(@"Please enter the max cariage weight of the truck:", GetType().GetMethod("SetMaxCarryingWeight"));
            specificParametersForCar.Add(@"Please enter 'true' if the truck is carrying hazardous materials.
Otherwise enter 'false':", GetType().GetMethod("SetIsCarryingHazardousMaterials"));

            return specificParametersForCar;

        }

        public void SetMaxCarryingWeight(string i_UserInput)
        {
            float maxWeight;
            bool isValidInput;

            isValidInput = float.TryParse(i_UserInput, out maxWeight);
            if (!isValidInput)
            {
                throw new ArgumentException("Invalid input " + i_UserInput);
            }
            else
            {
                m_MaxCarryingWeight = maxWeight;
            }
        }

        public void SetIsCarryingHazardousMaterials(string i_UserInput)
        {
            bool IsCarryingHazardous;
            bool isValidInput;

            isValidInput = bool.TryParse(i_UserInput, out IsCarryingHazardous);
            if (!isValidInput)
            {
                throw new ArgumentException("Invalid input "+i_UserInput);
            }
            else
            {
                m_IsCarryingHazardousMaterials = IsCarryingHazardous;
            }
        }


    }
}
