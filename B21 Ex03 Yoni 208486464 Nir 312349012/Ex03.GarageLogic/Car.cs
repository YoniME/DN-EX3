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
        private const FuelTank.eFuelType k_TypeOfFuel = FuelTank.eFuelType.Octan95;

        /*Fields*/
        private eCarColor m_CarColor;
        private readonly eNumberOfDoors r_NumberOfDoors;


        public enum eCarColor
        {
            Red,
            Silver,
            White,
            Black
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        public override string GetDetails()
        {
            StringBuilder carDetails = new StringBuilder();

            carDetails.AppendFormat(@"
                        {0}
                        Color: {1}
                        Number of doors: {2}"
                        , base.GetDetails(), m_CarColor.ToString(), r_NumberOfDoors.ToString());

            return carDetails.ToString();
        }


    }
}
