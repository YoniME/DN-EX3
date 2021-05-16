using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;


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

        public string ReadString()
        {
            return Console.ReadLine();
        }

        public eGarageActions GetActionFromUser()
        {
            eGarageActions action = new eGarageActions();
            int userChoice = GetInputAccordingToEnum<eGarageActions>(action);

            return (eGarageActions)userChoice;

        }

        public int GetInputAccordingToEnum<T>(T i_Enum)
        {
            string[] menu = Enum.GetNames(typeof(T));
            Array indexes = Enum.GetValues(typeof(T));
            int index = 1, userChoice;
            foreach(string str in menu)
            {
                Console.WriteLine(string.Format("{0}. {1}{2}", index++, str, Environment.NewLine));
            }

            userChoice = readActionFromUser<T>(i_Enum);
            return userChoice;
        }

        private int readActionFromUser<T>(T i_Enum)
        {
            int actionNumber = 0, enumSize = Enum.GetNames(typeof(T)).Length;
            bool isValidAction = false;

            do
            {
                try
                {
                    actionNumber = readIntFromUser();
                    isValidAction = Enum.IsDefined(typeof(T), actionNumber);
                }
                catch (ArgumentException)
                {
                    printInvalidInputMessage();
                }
            }
            while (!isValidAction);

            return actionNumber;
        }

        private void printInvalidInputMessage()
        {
           PrintString("Invalid input. Please try again");
        }

        private int readIntFromUser()
        {
            bool isValidInt = false;
            string userInput;
            int outputInt = 0;

            do
            {
                try
                {
                    userInput = ReadString();
                    outputInt = int.Parse(userInput);
                    isValidInt = true;
                }

                catch (FormatException)
                {
                    printInvalidInputMessage();
                }
            }
            while (!isValidInt);

            return outputInt;
        }

        private float readFloatFromUser()
        {
            bool isValidFloat = false;
            string userInput;
            float outputFloat = 0;

            do
            {
                try
                {
                    userInput =ReadString();
                    outputFloat = float.Parse(userInput);
                    isValidFloat = true;
                }

                catch (FormatException)
                {
                    printInvalidInputMessage();
                }
            }
            while (!isValidFloat);

            return outputFloat;
        }

        private string readStringFromUser(int? i_Length)
        {
            bool isValidString = false;
            string userInput = String.Empty;

            do
            {
                try
                {
                    userInput = ReadString();
                    isValidString = userInput.Trim().Length > 0;
                    if (i_Length.HasValue)
                    {
                        isValidString &= userInput.Trim().Length == i_Length;
                    }
                }
                catch (FormatException)
                {
                    printInvalidInputMessage();
                }
            }
            while (!isValidString);

            return userInput;
        }

    }
}
