using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTank
    {

        private float m_CurrentFuelTankCapacity;
        private readonly float m_MaxFuelTankCapacity;
        private readonly eFuelType m_FuelType;


        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
