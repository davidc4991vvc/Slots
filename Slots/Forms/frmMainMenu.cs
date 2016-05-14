using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Slots.Controllers;

namespace Slots.Forms
{
    public partial class frmMainMenu : Form
    {
        //Define forms for all slot games
        private frmAppleSlots m_frmAppleSlots = null;
        private frmOrangeSlots m_frmOrangeSlots = null;

        //Define controllers
        private MainMenuController m_MainMenuController = null;
        //private AppleSlotsController m_AppleSlotsController = null;


        public frmMainMenu()
        {
            Thread thread = Thread.CurrentThread;
            thread.Priority = ThreadPriority.Highest;

            InitializeComponent();

            m_MainMenuController = new MainMenuController(this);
        }

        #region BUTTON_HANDLERS

        private void btn_AppleSlots_Click(object sender, EventArgs e)
        {
            m_MainMenuController.requestOpenAppleSlots();
        }

        private void btn_OrangeSlots_Click(object sender, EventArgs e)
        {
            m_MainMenuController.requestOpenOrangeSlots();
        }

        #endregion

        #region SHOW_FORM_METHODS

        public void showAppleSlotsForm()
        {
            if (m_frmAppleSlots == null)
            {
                m_frmAppleSlots = new frmAppleSlots();
                m_frmAppleSlots.FormClosed += new FormClosedEventHandler(onAppleSlotsFormClosed);
                m_frmAppleSlots.Show();
            }

            else
            {
                //Already running a copy, attempt to make window visable
                m_frmAppleSlots.BringToFront();
            }
        }

        public void showOrangeSlotsForm()
        {
            if (m_frmOrangeSlots == null)
            {
                m_frmOrangeSlots = new frmOrangeSlots();
                m_frmOrangeSlots.FormClosed += new FormClosedEventHandler(onOrangeSlotsFormClosed);
                m_frmOrangeSlots.Show();
            }

            else
            {
                //Already running a copy, attempt to make window visable
                m_frmOrangeSlots.BringToFront();
            }
        }

        #endregion

        #region FORM_CLOSE_HANDLERS

        private void onMainMenuClosed(Object sender, FormClosingEventArgs e)
        {
            if (this != null)
            {
                if (MessageBox.Show("Are you Sure you want to Exit. Click Yes to Confirm and No to continue", "WinForm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Exit program normally
                    e.Cancel = false;
                }

                else
                {
                    //user does not want to exit program - cancel process
                    e.Cancel = true;
                }
            }
        }

        private void onAppleSlotsFormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_frmAppleSlots != null)
            {
                //TODO save off stats or credits, etc.

                m_frmAppleSlots.Dispose();
                m_frmAppleSlots = null;
            }
        }

        private void onOrangeSlotsFormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_frmOrangeSlots != null)
            {
                //TODO save off stats or credits, etc.

                m_frmOrangeSlots.Dispose();
                m_frmOrangeSlots = null;
            }
        }

        #endregion


    }
}
