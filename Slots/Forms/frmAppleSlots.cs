using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Slots.Controllers;


namespace Slots.Forms
{
    public partial class frmAppleSlots : Form
    {
        private AppleSlotsController m_AppleSlotsController = null;

        private int spinTime = 350;

        public frmAppleSlots()
        {
            InitializeComponent();

            m_AppleSlotsController = new AppleSlotsController(this);

            m_AppleSlotsController.requestSetCurrentBetAmount(1);

            LoadStartDataFromModel();
        }

        //This does not really do anything. In the future it can load user data. We do not have "Users" at the moment though. TODO
        private void LoadStartDataFromModel()
        {
            lb_AmountWon.Text = m_AppleSlotsController.requestAmountWon().ToString();
            lb_CurrentBetAmt.Text = m_AppleSlotsController.requestGetCurrentBetAmount().ToString();
            lb_CurrentCreditAmt.Text = m_AppleSlotsController.requestGetCurrentCredits().ToString();
        }

        private void updatePayoutInfo()
        {
            lb_payout_1.Text = (m_AppleSlotsController.requestPayoutMultiplier(1) * m_AppleSlotsController.requestGetCurrentBetAmount()).ToString();
            lb_payout_2.Text = (m_AppleSlotsController.requestPayoutMultiplier(2) * m_AppleSlotsController.requestGetCurrentBetAmount()).ToString();
            lb_payout_3.Text = (m_AppleSlotsController.requestPayoutMultiplier(3) * m_AppleSlotsController.requestGetCurrentBetAmount()).ToString();
            lb_payout_4.Text = (m_AppleSlotsController.requestPayoutMultiplier(4) * m_AppleSlotsController.requestGetCurrentBetAmount()).ToString();
        }

        private void rb_BetAmt1_CheckedChanged(object sender, EventArgs e)
        {
            m_AppleSlotsController.requestSetCurrentBetAmount(1f);
        }

        private void rb_BetAmt2_CheckedChanged(object sender, EventArgs e)
        {
            m_AppleSlotsController.requestSetCurrentBetAmount(5f);
        }

        private void rb_BetAmt3_CheckedChanged(object sender, EventArgs e)
        {
            m_AppleSlotsController.requestSetCurrentBetAmount(10f);
        }

        private void rb_BetAmt4_CheckedChanged(object sender, EventArgs e)
        {
            m_AppleSlotsController.requestSetCurrentBetAmount(25f);
        }

        private void nud_BetAmount_ValueChanged(object sender, EventArgs e)
        {
            m_AppleSlotsController.requestSetCurrentBetAmount((float)nud_BetAmount.Value);
            lb_CurrentBetAmt.Text = nud_BetAmount.Value.ToString();
            updatePayoutInfo();
        }

        private void btn_Spin_Click(object sender, EventArgs e)
        {
            m_AppleSlotsController.requestSpin();

            //Should really be using a timer here instead of sleeping
            pb_LeftSlot.Image = m_AppleSlotsController.requestSpinningImage();
            pb_LeftSlot.Refresh();
            Thread.Sleep(spinTime);

            pb_MiddleSlot.Image = m_AppleSlotsController.requestSpinningImage();
            pb_MiddleSlot.Refresh();
            Thread.Sleep(spinTime);

            pb_RightSlot.Image = m_AppleSlotsController.requestSpinningImage();
            pb_RightSlot.Refresh();
            Thread.Sleep(spinTime);

            Thread.Sleep(spinTime);

            pb_LeftSlot.Image = m_AppleSlotsController.requestGetImageFromLastSpin(0);
            pb_LeftSlot.Refresh();
            Thread.Sleep(spinTime);

            pb_MiddleSlot.Image = m_AppleSlotsController.requestGetImageFromLastSpin(1);
            pb_MiddleSlot.Refresh();
            Thread.Sleep(spinTime);

            pb_RightSlot.Image = m_AppleSlotsController.requestGetImageFromLastSpin(2);
            pb_RightSlot.Refresh();
            Thread.Sleep(spinTime);

            lb_AmountWon.Text = m_AppleSlotsController.requestAmountWon().ToString();
            lb_CurrentCreditAmt.Text = m_AppleSlotsController.requestGetCurrentCredits().ToString();
        }

        private void btn_DepositCredits_Click(object sender, EventArgs e)
        {
            m_AppleSlotsController.requestSetCurrentCredits(100);
            lb_CurrentCreditAmt.Text = m_AppleSlotsController.requestGetCurrentCredits().ToString();
        }
    }
}
