using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        private string m_VehicleOwnerName;
        private string m_PhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public enum eVehicleStatus
        {
            InCare,
            Fixed,
            Paid
        }

        public VehicleOwner()
        {
            
        }

        public string Name
        {
            get { return m_VehicleOwnerName; }
            set { m_VehicleOwnerName = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public eVehicleStatus Status
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

    }
}
