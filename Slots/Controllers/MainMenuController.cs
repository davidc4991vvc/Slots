using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slots.Forms;

namespace Slots.Controllers
{
    class MainMenuController
    {
        private frmMainMenu m_MainMenu = null;

        private MainMenuController()
        {
            // no implementation, use overriden only
        }

        public MainMenuController(frmMainMenu mainMenu)
        {
            m_MainMenu = mainMenu;
        }

        public void requestOpenAppleSlots()
        {
            m_MainMenu.showAppleSlotsForm();

        }

        public void requestOpenOrangeSlots()
        {
            m_MainMenu.showOrangeSlotsForm();

        }




    }
}
