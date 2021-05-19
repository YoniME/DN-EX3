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

        public static void PrintString(string i_StringToPrint)
        {
            Console.WriteLine(i_StringToPrint);
        }

        public static string ReadString()
        {
            return Console.ReadLine();
        }

        public static void PrintStringList(List<string> i_StringList)
        {
            foreach (string str in i_StringList)
            {
                UI.PrintString(str);
            }
        }

        public static eGarageActions GetActionFromUser()
        {
            eGarageActions action = new eGarageActions();
            int userChoice = GetInputAccordingToEnum<eGarageActions>(action);

            return (eGarageActions)userChoice;
        }

        public static int GetInputAccordingToEnum<T>(T i_Enum)
        {
            string[] menu = Enum.GetNames(typeof(T));
            Array indexes = Enum.GetValues(typeof(T));
            int index = 1, userChoice;
            foreach (string str in menu)
            {
               PrintString(string.Format("{0}. {1}", index++, str));
            }

            userChoice = ReadActionFromUser<T>(i_Enum);
            return userChoice;
        }

        public static int ReadActionFromUser<T>(T i_Enum)
        {
            int actionNumber = 0, enumSize = Enum.GetNames(typeof(T)).Length;
            bool isValidAction = false, isFirstRound = true;

            do
            {
                try
                {
                    if (!isFirstRound)
                    {
                        PrintInvalidInputMessage();
                    }
                    isFirstRound = false;
                    actionNumber = ReadIntFromUser();
                    isValidAction = Enum.IsDefined(typeof(T), actionNumber);
                }
                catch
                {
                    PrintInvalidInputMessage();
                }
            }
            while (!isValidAction);

            return actionNumber;
        }

        public static void PrintInvalidInputMessage()
        {
           PrintString("Invalid input. Please try again");
        }

        public static int ReadIntFromUser()
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
                    PrintInvalidInputMessage();
                }
            }
            while (!isValidInt);

            return outputInt;
        }

        public static float ReadFloatFromUser()
        {
            bool isValidFloat = false;
            string userInput;
            float outputFloat = 0;

            do
            {
                try
                {
                    userInput = ReadString();
                    outputFloat = float.Parse(userInput);
                    isValidFloat = true;
                }
                catch (FormatException)
                {
                    PrintInvalidInputMessage();
                }
            }
            while (!isValidFloat);

            return outputFloat;
        }

        public static string ReadStringFromUser()
        {
            bool isValidString = false;
            string userInput = string.Empty;

            do
            {
                try
                {
                    userInput = ReadString();
                    isValidString = userInput.Trim().Length > 0;
                }
                catch (FormatException)
                {
                    PrintInvalidInputMessage();
                }
            }
            while (!isValidString);

            return userInput;
        }

        public static string ReadStringContainsNumbersOnlyFromUser()
        {
            bool isNumbersString = false;
            string userInput = string.Empty;

            do
            {
                try
                {
                    userInput = ReadStringFromUser();
                    long.Parse(userInput);
                    isNumbersString = true;
                }
                catch (FormatException)
                {
                    PrintInvalidInputMessage();
                }
            }
            while (!isNumbersString);

            return userInput;
        }

        public static string ReadYesOrNoFromUser()
        {
            bool isYesOrNoString = false, isFirstRun = true; ;
            string userInput = string.Empty, yes = "yes", no = "no";

            do
            {
                try
                {
                    if (!isFirstRun)
                    {
                        UI.PrintString("You can only answer yes / no. Please answer again");
                    }
                    isFirstRun = false;
                    userInput = ReadString();
                    isYesOrNoString = userInput.Trim().ToLower().Equals(yes) || userInput.Trim().ToLower().Equals(no);
                }
                catch (FormatException)
                {
                    PrintInvalidInputMessage();
                }
            }
            while (!isYesOrNoString);

            return userInput;
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }
    }
}
