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

            electricBatteryDetails.AppendFormat("Type of energy source: Electric battery{0}", Environment.NewLine);
            electricBatteryDetails.AppendFormat("Max hours in one battery charge: {0}{1}", MaxEnergySourceCapacity, Environment.NewLine);
            electricBatteryDetails.AppendFormat("Current remaining hours in battery: {0}{1}", RemainingEnergy, Environment.NewLine);

            return electricBatteryDetails.ToString();
        }
    }
}
