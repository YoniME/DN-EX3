﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturName;
        private float m_AirPressure;
        private readonly float r_MaxAirPressure;


        public Wheel(string i_ManufacturName, float i_AirPressure, float i_MaxAirPressure)
        {
            m_ManufacturName = i_ManufacturName;
            m_AirPressure = i_AirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }


        public string ManufactorNamer
        {
            get { return m_ManufacturName; }
            set { m_ManufacturName = value; }
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }


        public void InflateWheel(float i_AirPressureToAdd)
        {
            bool isAirPressureToAddIsNegative = i_AirPressureToAdd < 0;
            bool isAboveMaxAirPressure = m_AirPressure + i_AirPressureToAdd > r_MaxAirPressure;

            if (isAirPressureToAddIsNegative)
            {
                throw new ArgumentException("Cannot lower the air pressure!");
            }
            else if (isAboveMaxAirPressure)
            {
                throw new ArgumentException("Cannot add more air then the maximum airpressure of the wheel!");
            }
            
            m_AirPressure += i_AirPressureToAdd;
        }
    }
}
