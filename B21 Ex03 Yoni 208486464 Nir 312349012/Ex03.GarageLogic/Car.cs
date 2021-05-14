using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        eCarColor m_CarColor;
        readonly eNumberOfDoors m_NumberOfDoors;


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




    }
}
