using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
		private readonly int r_NumOfWheels = 0;

		private string m_ManufacturName;
		private string m_PlateLicenseNumber;
		private float m_RemainingEnergy;
		private List<Wheel> m_Wheels;
		//private EnergySource m_EnergySource;

		public string ManufacturName
        {
            get { return m_ManufacturName; }
			set { m_ManufacturName = value; }
		}

		public string PlateLicenseNumber
        { 
			get { return m_PlateLicenseNumber; }
			set { m_PlateLicenseNumber = value; }
		}

		public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
			set { m_RemainingEnergy = value; }
		}
		
		public List<Wheel> Wheels
        {
			get { return m_Wheels; }
			set { m_Wheels = value; }
		}




	}
}
