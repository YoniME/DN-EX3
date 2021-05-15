using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricBattery : EnergySource
    {
        private const float k_MaxBatteryChargeInHours = 3.2f;

        public override string GetEnergySourceDetails()
        {
            StringBuilder electricBatteryDetails = new StringBuilder();

            electricBatteryDetails.AppendFormat(@"
                            Type of energy source: Electric battery
                            Max hours in one battery charge: {1}
                            Current remaining hours in battery: {2}",
                            MaxEnergySourceCapacity, RemainingEnergy);

            return electricBatteryDetails.ToString();
        }
    }
}
