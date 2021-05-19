using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricBattery : EnergySource
    {
        public override string GetEnergySourceDetails()
        {
            StringBuilder electricBatteryDetails = new StringBuilder();

            electricBatteryDetails.AppendFormat("Type of energy source: Electric battery{0}", Environment.NewLine);
            electricBatteryDetails.AppendFormat("Max hours in one battery charge: {0}{1}", MaxEnergySourceCapacity, Environment.NewLine);
            electricBatteryDetails.AppendFormat("Current remaining hours in battery: {0}{1}", RemainingEnergy, Environment.NewLine);

            return electricBatteryDetails.ToString();
        }

        public void Charge(float i_AmountOfEnergyToAdd)
        {
            bool isBatteryFlooded = RemainingEnergy + i_AmountOfEnergyToAdd > MaxEnergySourceCapacity;
            float currentMaxAmountOfEnergyToAdd = MaxEnergySourceCapacity - RemainingEnergy;

            try
            {
                isValidAmountOfEnergy(i_AmountOfEnergyToAdd);
            }
            catch (ArgumentException exception)
            {
                throw new ArgumentException(exception.Message);
            }

            if (isBatteryFlooded)
            {
                throw new ValueOutOfRangeException(0, currentMaxAmountOfEnergyToAdd);
            }

            RemainingEnergy += i_AmountOfEnergyToAdd;
        }
    }
}
