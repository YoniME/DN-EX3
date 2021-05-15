using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTank : EnergySource
    {

        private readonly eFuelType m_FuelType;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public FuelTank() : base()
        {
            m_FuelType = new eFuelType();
        }

        public FuelTank(float i_RemainingEnergy, float i_MaxEnergySourceCapacity, eFuelType i_FuelType)
            : base(i_RemainingEnergy, i_MaxEnergySourceCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }

        public void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            bool isEngineFlooded = RemainingEnergy + i_AmountOfFuelToAdd > MaxEnergySourceCapacity;

            try
            {
                isValidAmountOfEnergy(i_AmountOfFuelToAdd);
                fuelTypeIsMatch(i_FuelType);
            }
            catch (ArgumentException exception)
            {
                throw new ArgumentException(exception.Message);
            }

            if(isEngineFlooded)
            {
                // throw exception that is out of range
            }

            RemainingEnergy += i_AmountOfFuelToAdd;
        }

        private void fuelTypeIsMatch(eFuelType i_FuelType)
        {
            if (i_FuelType != FuelType)
            {
                throw new ArgumentException("Fuel type isn't match");
            }
        }

        public override string GetEnergySourceDetails()
        {
            StringBuilder fuelTankDetails = new StringBuilder();

            fuelTankDetails.AppendFormat(@"
                            Type of energy source: Fuel
                            Max amount of fuel in tank: {1}
                            Current amount of fuel in tank: {2}
                            Type of fuel: {3}",
                            MaxEnergySourceCapacity, RemainingEnergy, m_FuelType.ToString());

            return fuelTankDetails.ToString();
        }
    }
}
