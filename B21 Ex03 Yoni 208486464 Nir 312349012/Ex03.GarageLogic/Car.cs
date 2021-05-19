using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
            specificParametersForCar.Add(
@"Please enter the number of the color you want for your car:
1. Red
2. Silver
3. White
4. Black", GetType().GetMethod("SetColorOfCar"));
            specificParametersForCar.Add(
@"Please enter the number of doors you want for your car:
1. Two
2. Three
3. Four
4. Five", GetType().GetMethod("SetNumberOfDoors"));

            return specificParametersForCar;

        }


        public void SetColorOfCar(string i_NumerOfEnumColor)
        {
            int actionNumber;
            bool isValidAction;

            actionNumber = int.Parse(i_NumerOfEnumColor);
            isValidAction = Enum.IsDefined(typeof(eCarColor), actionNumber);
            if (!isValidAction)
            {
                throw new ArgumentException("Invalid input " + i_NumerOfEnumColor);
            }
            else
            {
                m_CarColor = (eCarColor)actionNumber;
            }
        }
        

        public void SetNumberOfDoors(string i_NumerOfEnumDoors)
        {
            int actionNumber;
            bool isValidAction;

            actionNumber = int.Parse(i_NumerOfEnumDoors);
            isValidAction = Enum.IsDefined(typeof(eNumberOfDoors), actionNumber);
            if (!isValidAction)
            {
                throw new ArgumentException("Invalid input");
            }
            else
            {
                m_NumberOfDoors = (eNumberOfDoors)actionNumber;
            }
        }


    }
}
