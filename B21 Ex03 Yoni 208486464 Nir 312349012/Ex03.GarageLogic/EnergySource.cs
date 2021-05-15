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

        public EnergySource()
        {
            m_RemainingEnergy = 0;
            m_MaxEnergySourceCapacity = 0;
        }

        public EnergySource(float i_RemainingEnergy, float i_MaxEnergySourceCapacity)
        {
            m_RemainingEnergy = i_RemainingEnergy;
            m_MaxEnergySourceCapacity = i_MaxEnergySourceCapacity;
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


        public abstract string GetEnergySourceDetails();


        protected void isValidAmountOfEnergy(float i_AmountOfFuel)
        {
            if (i_AmountOfFuel < 0)
            {
                throw new ArgumentException("Cannot add negative amount to the energy source");
            }
        }


    }
}
