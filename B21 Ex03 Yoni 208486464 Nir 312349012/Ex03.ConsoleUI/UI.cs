using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UI
    {

        public enum eGarageActions
        {
            InsertNewVehicle = 1,
            DisplayAllVehiclesInGarage,
            ChangeTheStatusOfCar,
            InflateTheWheels,
            Refuel,
            ChargeTheBattery,
            DisplayFullDetailsOfVehicle,
            Quit
        }

        public void PrintString(string i_StringToPrint)
        {
            Console.WriteLine(i_StringToPrint);
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        public eGarageActions GetActionFromUser()
        {
            eGarageActions action = new eGarageActions();
            int userChoice = GetInputAccordingToEnum(action);



            return (eGarageActions)userChoice;

        }

        public int GetInputAccordingToEnum<T>(T i_Enum)
        {
            string[] menu = Enum.GetNames(typeof(T));
            Array indexes = Enum.GetValues(typeof(T));
            int index = 1;
            foreach(string str in menu)
            {
                Console.WriteLine(string.Format("{0}. {1}{2}", index++, str, Environment.NewLine));
            }
            // check the input
            return Console.Read();
        }

    }
}
