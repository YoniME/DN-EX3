﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFolder
    {
        private string m_VehicleOwnerName;
        private string m_PhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public enum eVehicleStatus
        {
            InHandling = 1,
            Fixed,
            Paid
        }

        public VehicleFolder()
        {
            
        }

        public VehicleFolder(Vehicle i_Vehicle ,string i_VehicleOwnerName, string i_VehicleownerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_PhoneNumber = i_VehicleownerPhoneNumber;
            m_VehicleStatus = new eVehicleStatus();
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

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

    }
}
