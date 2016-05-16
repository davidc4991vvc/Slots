using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Slots.Forms;
using Slots.Model;
using Slots.Model.Utility;


namespace Slots.Controllers
{
    class AppleSlotsController
    {
        frmAppleSlots m_AppleSlotsForm = null;
        AppleSlotsModel m_model = null;


        private AppleSlotsController()
        {
            //Don't use default
        }
         
        public AppleSlotsController(frmAppleSlots appleSlotsForm)
        {
            m_AppleSlotsForm = appleSlotsForm;

            //Theoretically this should never not be null, but stranger things have happened. Avoid potential data loss.
            //If models are ever shared between games or saved/loaded they will need to be made static and initialized elsewhere.
            if (m_model == null)
            {
                m_model = new AppleSlotsModel();
            }
        }

        //Current Credits
        public float requestGetCurrentCredits()
        {
            return m_model.CurrentCredits;
        }

        //Returns true if amount was successfully changed. False if credits have gone negative.
        public bool requestChangeCurrentCredits(float amount)
        {
            m_model.CurrentCredits += amount;

            if (m_model.CurrentCredits <= 0)
            {
                m_model.CurrentCredits = 0;
                return false;
            }

            return true;
        }

        public void requestSetCurrentCredits(float amount)
        {
            m_model.CurrentCredits = amount;
        }

        //CurrentBetAmount
        public float requestGetCurrentBetAmount()
        {
            return m_model.CurrentBetAmount;
        }

        public void requestSetCurrentBetAmount(float amount)
        {
            m_model.CurrentBetAmount = amount;

        }

        //Images
        public Image requestImage(int imgNum)
        {
            switch (imgNum)
            {
                case 1:
                    return m_model.m_slotImages.ImageOne;

                case 2:
                    return m_model.m_slotImages.ImageTwo;

                case 3:
                    return m_model.m_slotImages.ImageThree;

                case 4:
                    return m_model.m_slotImages.ImageFour;
            }

            return null;
        }

        //Payouts - iffy variable names TODO
        public float requestPayoutMultiplier(int imgNum)
        {
            switch (imgNum)
            {
                case 1:
                    return m_model.m_payouts.ImageOnePayoutMultiplier;

                case 2:
                    return m_model.m_payouts.ImageTwoPayoutMultiplier;

                case 3:
                    return m_model.m_payouts.ImageThreePayoutMultiplier;

                case 4:
                    return m_model.m_payouts.ImageFourPayoutMultiplier;
            }

            return 0;
        }

        //Amount won
        public float requestAmountWon()
        {
            return m_model.AmountWon;
        }

        //Spin
        public void requestSpin()
        {
            m_model.lastWinner = RandomSelection.SelectWinner(m_model.m_chancesToWin);

            requestChangeCurrentCredits(-1 * m_model.CurrentBetAmount);

            calculateImagesForLastSpin();

            calculatePayoutForLastSpin();
        }

        private void calculatePayoutForLastSpin()
        {
            switch (m_model.lastWinner)
            {
                case 1:
                    m_model.AmountWon = m_model.m_payouts.ImageOnePayoutMultiplier * m_model.CurrentBetAmount;
                    break;

                case 2:
                    m_model.AmountWon = m_model.m_payouts.ImageTwoPayoutMultiplier * m_model.CurrentBetAmount;
                    break;

                case 3:
                    m_model.AmountWon = m_model.m_payouts.ImageThreePayoutMultiplier * m_model.CurrentBetAmount;
                    break;

                case 4:
                    m_model.AmountWon = m_model.m_payouts.ImageFourPayoutMultiplier * m_model.CurrentBetAmount;
                    break;

                default:
                    m_model.AmountWon = 0;
                    break;
            }

            requestChangeCurrentCredits(m_model.AmountWon);

        }

        private void calculateImagesForLastSpin()
        {
            switch (m_model.lastWinner)
            {
                case 0:
                    //no winner - no 3 of kind
                    //Iffy way of doing this
                    for (int i = 0; i < 3; i++)
                    {
                        switch (RandomSelection.GetRandomInt(1, 5))
                        {
                            case 1:
                                m_model.m_imagesToDisplay[i] = m_model.m_slotImages.ImageOne;
                                break;

                            case 2:
                                m_model.m_imagesToDisplay[i] = m_model.m_slotImages.ImageTwo;
                                break;

                            case 3:
                                m_model.m_imagesToDisplay[i] = m_model.m_slotImages.ImageThree;
                                break;

                            case 4:
                                m_model.m_imagesToDisplay[i] = m_model.m_slotImages.ImageFour;
                                break;
                        }

                        //All 3 match, reroll the last one. Should be ok to compare since they are references
                        if (m_model.m_imagesToDisplay[0].Equals(m_model.m_imagesToDisplay[1]) && m_model.m_imagesToDisplay[0].Equals(m_model.m_imagesToDisplay[2]))
                        {
                            i--;
                        }
                    }
                    break;

                case 1:
                    //Image 1 won - 3 of kind
                    m_model.m_imagesToDisplay[0] = m_model.m_slotImages.ImageOne;
                    m_model.m_imagesToDisplay[1] = m_model.m_slotImages.ImageOne;
                    m_model.m_imagesToDisplay[2] = m_model.m_slotImages.ImageOne;
                    break;

                case 2:
                    //Image 2 won - 3 of kind
                    m_model.m_imagesToDisplay[0] = m_model.m_slotImages.ImageTwo;
                    m_model.m_imagesToDisplay[1] = m_model.m_slotImages.ImageTwo;
                    m_model.m_imagesToDisplay[2] = m_model.m_slotImages.ImageTwo;
                    break;

                case 3:
                    //Image 3 won - 3 of kind
                    m_model.m_imagesToDisplay[0] = m_model.m_slotImages.ImageThree;
                    m_model.m_imagesToDisplay[1] = m_model.m_slotImages.ImageThree;
                    m_model.m_imagesToDisplay[2] = m_model.m_slotImages.ImageThree;
                    break;

                case 4:
                    //Image 4 won - 3 of kind
                    m_model.m_imagesToDisplay[0] = m_model.m_slotImages.ImageFour;
                    m_model.m_imagesToDisplay[1] = m_model.m_slotImages.ImageFour;
                    m_model.m_imagesToDisplay[2] = m_model.m_slotImages.ImageFour;
                    break;
            }
        }

        public Image requestGetImageFromLastSpin(int imgPosition)
        {
            return m_model.m_imagesToDisplay[imgPosition];
        }

        public Image requestSpinningImage()
        {
            return m_model.spinningImage;
        }
    }
}
