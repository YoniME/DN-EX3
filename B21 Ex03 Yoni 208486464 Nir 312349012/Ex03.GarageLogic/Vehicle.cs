using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
		private string m_ManufacturName;
		private string m_PlateLicenseNumber;
		private List<Wheel> m_Wheels;
		private EnergySource m_EnergySource;

		public enum eVehicleType
        {
			Car = 1,
			MotorCycle,
			Truck
        }

		
		protected Vehicle(string i_Manufacturer, string i_PlateLicenseNumber,float i_RemainingEnergyPrecentage,
			int i_NumberOfWheels, float i_MaxAirPressure, EnergySource.eEnergySourceType i_EnergyType,
			string i_WheelsManufacturName, float i_WheelsCurrentAirPressurePrecentage)
        {
			m_ManufacturName = i_Manufacturer;
			m_PlateLicenseNumber = i_PlateLicenseNumber;
			m_Wheels = new List<Wheel>(i_NumberOfWheels);
			setWheels(i_WheelsManufacturName, i_WheelsCurrentAirPressurePrecentage, i_MaxAirPressure, i_NumberOfWheels);
			if (i_EnergyType == EnergySource.eEnergySourceType.Fuel)
            {
				m_EnergySource = new FuelTank();
            }
			else
            {
				m_EnergySource = new ElectricBattery();
            }
			setEnergySource(i_RemainingEnergyPrecentage);
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
            get { return m_EnergySource.RemainingEnergy; }
			set { m_EnergySource.RemainingEnergy = value; }
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

			vehicleDetails.AppendFormat("Plate License Number: {0}{1}", m_PlateLicenseNumber,Environment.NewLine);
			vehicleDetails.AppendFormat("Manufactur Name: {0}{1}", m_ManufacturName, Environment.NewLine);

			return vehicleDetails.ToString();
        }

		private void setWheels(string i_WheelManufacturName, float i_WheelsCurrentAirPressurePrecentage,
			float i_MaxAirPressure, int i_NumberOfWheels)
        {
			Wheel newWheel;
			float currentAirPressure = i_MaxAirPressure * i_WheelsCurrentAirPressurePrecentage / 100;

			for (int i = 0; i < i_NumberOfWheels; i++)
			{
				newWheel = new Wheel(i_WheelManufacturName, currentAirPressure, i_MaxAirPressure);
				Wheels.Add(newWheel);
			}
		}

		public abstract void setEnergySource(float i_RemainingEnergy);

		public abstract void SetSpecificDetails(params object[] i_Details);

		public abstract Dictionary<string, MethodInfo> GetSpecificParameters();

		public string GetWheelsDetails()
        {
			int index = 1 ;
			StringBuilder wheelsDetails = new StringBuilder();

			wheelsDetails.AppendFormat("Number of wheels: {0}{1}", Wheels.Count.ToString(), Environment.NewLine);
			foreach (Wheel wheel in m_Wheels)
			{ 
				wheelsDetails.AppendFormat("{0}.{1}{2}{3}", index.ToString(), Environment.NewLine, wheel.GetDetails() , Environment.NewLine);
				index++;
			}

			return wheelsDetails.ToString();
		}
	}
}
