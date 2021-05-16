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
                action = m_UserInterface.


            }while(!userWantsToQuit)



        }



    }
}
