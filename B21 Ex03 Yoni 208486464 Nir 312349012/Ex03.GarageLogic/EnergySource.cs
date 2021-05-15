using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_RemainingEnergy;
        private readonly float m_MaxEnergySourceCapacity;
        private eTypeOfEnergySource m_TypeOfEnergy;

        public enum eTypeOfEnergySource
        {
            Fuel,
            ElectricBattery
        }

        public EnergySource()
        {
            m_RemainingEnergy = 0;
            m_MaxEnergySourceCapacity = 0;
            m_TypeOfEnergy = new eTypeOfEnergySource();
        }

        public EnergySource(float i_RemainingEnergy, float i_MaxEnergySourceCapacity, eTypeOfEnergySource i_TypeOfEnergy)
        {
            m_RemainingEnergy = i_RemainingEnergy;
            m_MaxEnergySourceCapacity = i_MaxEnergySourceCapacity;
            m_TypeOfEnergy = i_TypeOfEnergy;
        }

        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
        }

        public float MaxEnergySourceCapacity
        {
            get { return m_MaxEnergySourceCapacity; }
        }

        public eTypeOfEnergySource TypeOfEnergySource
        {
            get { return m_TypeOfEnergy; }
            set { m_TypeOfEnergy = value; }
        }

        public virtual string GetEnergySourceDetails()
        {
            StringBuilder energySourceDetails = new StringBuilder();

            energySourceDetails.AppendFormat(@"
                                Type of energy source: {0}", m_TypeOfEnergy.ToString());

            return energySourceDetails.ToString();
        }

        protected void isValidAmountOfEnergy(float i_AmountOfFuel)
        {
            if (i_AmountOfFuel < 0)
            {
                throw new ArgumentException("Cannot add negative amount to the energy source");
            }
        }


    }
}
