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


		protected Vehicle(string i_Manufacturer, string i_PlateLicenseNumber,float i_RemainingEnergy,
			int i_NumberOfWheels, float i_MaxAirPressure, EnergySource.eEnergySourceType i_EnergyType,
			string i_WheelsManufacturName, float i_CurrentWheelsAirPressure)
        {
			m_ManufacturName = i_Manufacturer;
			m_PlateLicenseNumber = i_PlateLicenseNumber;
			m_RemainingEnergy = i_RemainingEnergy;
			m_Wheels = new List<Wheel>();
			setWheels(i_WheelsManufacturName, i_CurrentWheelsAirPressure, i_MaxAirPressure, i_NumberOfWheels);
			if (i_EnergyType == EnergySource.eEnergySourceType.Fuel)
            {
				m_EnergySource = new FuelTank();
            }
			else
            {
				m_EnergySource = new ElectricBattery();
            }
			setEnergySource(i_RemainingEnergy);
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

		public EnergySource EnergySource
        {
			get { return m_EnergySource; }
        }

		public virtual string GetDetails()
        {
			StringBuilder vehicleDetails = new StringBuilder();

			vehicleDetails.AppendFormat("Plate License Number{0}{1}", m_PlateLicenseNumber,Environment.NewLine);
			vehicleDetails.AppendFormat("Manufactur Name: {0}{1}", m_ManufacturName, Environment.NewLine);

			return vehicleDetails.ToString();
        }

		private void setWheels(string i_WheelManufacturName, float i_CurrentWheelsAirPressure,
			float i_MaxAirPressure, int i_NumberOfWheels)
        {
			Wheel newWheel;

			for (int i = 0; i < i_NumberOfWheels; i++)
			{
				newWheel = new Wheel(i_WheelManufacturName, i_CurrentWheelsAirPressure, i_MaxAirPressure);
				Wheels.Add(newWheel);
			}
		}

		public abstract void setEnergySource(float i_RemainingEnergy);



	}
}
