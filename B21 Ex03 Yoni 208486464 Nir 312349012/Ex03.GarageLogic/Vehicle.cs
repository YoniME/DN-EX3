using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
		private string m_ManufacturName;
		private string m_PlateLicenseNumber;
		private float m_RemainingEnergy;
		private List<Wheel> m_Wheels;
		private EnergySource m_EnergySource;

		public enum eVehicleType
        {
			Car,
			MotorCycle,
			Truck
        }


		protected Vehicle(string i_Manufacturer, string i_PlateLicenseNumber, float i_RemainingEnergy,int i_NumberOfWheels)
        {
			m_ManufacturName = i_Manufacturer;
			m_PlateLicenseNumber = i_PlateLicenseNumber;
			m_RemainingEnergy = i_RemainingEnergy;
			m_Wheels = null;
		}

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

		public virtual string GetDetails()
        {
			StringBuilder vehicleDetails = new StringBuilder();

			vehicleDetails.AppendFormat(@"
							Plate License Number: {0}
							Manufactur Name: {1}
							", m_PlateLicenseNumber, m_ManufacturName);

			return vehicleDetails.ToString();
        }


	}
}
