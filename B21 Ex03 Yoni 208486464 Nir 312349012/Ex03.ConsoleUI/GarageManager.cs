using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class GarageManager
    {
        //private readonly Garage mr_Garage
        private UI m_UserInterface;

        public GarageManager()
        {
            m_UserInterface = new UI();
        }

        public void OpenGarage()
        {
            UI.eGarageActions action;
            bool userWantsToQuit = false;

            do
            {
                action = m_UserInterface.GetActionFromUser();
                switch(action)
                {
                    case UI.eGarageActions.InsertNewVehicle:
                        insertNewVehicleToGarage();
                        break;
                    case UI.eGarageActions.DisplayAllVehiclesInGarage:
                        displayAllVehiclesInGarage();
                        break;
                    case UI.eGarageActions.ChangeTheStatusOfCar:
                        changeTheStatusOfCar();
                        break;
                    case UI.eGarageActions.InflateTheWheels:
                        inflateTheWheels();
                        break;
                    case UI.eGarageActions.Refuel:
                        refuel();
                        break;
                    case UI.eGarageActions.ChargeTheBattery:
                        chargeTheBattery();
                        break;
                    case UI.eGarageActions.DisplayFullDetailsOfVehicle:
                        displayFullDetailsOfVehicle();
                        break;
                    case UI.eGarageActions.Quit:
                        userWantsToQuit = true;
                        break;

                }
            } 
            while (!userWantsToQuit);
        }

        private void insertNewVehicleToGarage()
        {

        }

        private void displayAllVehiclesInGarage()
        {

        }

        private void changeTheStatusOfCar()
        {

        }

        private void inflateTheWheels()
        {

        }

        private void refuel()
        {

        }

        private void chargeTheBattery()
        {

        }

        private void displayFullDetailsOfVehicle()
        {

        }
    }
}
