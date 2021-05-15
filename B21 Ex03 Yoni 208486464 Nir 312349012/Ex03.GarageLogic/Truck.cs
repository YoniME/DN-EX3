using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly float r_MaxCarryingWeight;
        private bool m_IsCarryingHazardousMaterials;
        //private FuelTank m_FuelTank;

        public Truck(float i_MaxCarryingWeight, bool i_IsCarryingHazardousMaterials, string i_Manufacturer, string i_PlateLicenseNumber, float i_RemainingEnergy, int i_NumberOfWheels)
            : base(i_Manufacturer, i_PlateLicenseNumber, i_RemainingEnergy, i_NumberOfWheels)
        {
            r_MaxCarryingWeight = i_MaxCarryingWeight;
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_FuelTank = new FuelTank(i_RemainingEnergy, k_MaxFuelTankCapacity, k_FuelType);
        }

        public float MaxCarryingWeight
        {
            get { return r_MaxCarryingWeight; }
        }

        public bool IsCarryingHazardousMaterials
        {
            get { return m_IsCarryingHazardousMaterials; }
            set { m_IsCarryingHazardousMaterials = value; }
        }

        public override string GetDetails()
        {
            StringBuilder truckDetails = new StringBuilder();

            truckDetails.AppendFormat(@"
                        Is carrying hazardous materials: {0}
                        Max carrying weight: {1}
                        {3}"
                        ,m_IsCarryingHazardousMaterials.ToString(),
                        r_MaxCarryingWeight.ToString(),
                        m_FuelTank.GetEnergySourceDetails().ToString());

            return truckDetails.ToString();
        }
    }
}
