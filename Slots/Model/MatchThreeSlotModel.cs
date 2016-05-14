using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Slots.Model
{
    public abstract class MatchThreeSlotModel
    {
        //I realize making an abstract class and all that is a bit overkill for what this program does at the moment.
        //It will greatly simplify generating new slot games that are reskins with the same base logic
        //  if this project ever gets to that point.

        //All of this could be serialized and read in from external sources as well to prevent hardcoding.
        //So you could have a server that adjusted win rates / payouts depending on weekday/weekend, popularity of machine, etc.

        public float CurrentCredits = 0;
        public float CurrentBetAmount = 1; //Default to $1
        public float AmountWon = 0;
        public int lastWinner = -1;

        public Image spinningImage;

        public Image[] m_imagesToDisplay = new Image[] { null, null, null };

        public struct PAYOUTS
        {
            //These variable names seem not good TODO
            public float ImageOnePayoutMultiplier;
            public float ImageTwoPayoutMultiplier;
            public float ImageThreePayoutMultiplier;
            public float ImageFourPayoutMultiplier;
        };

        public PAYOUTS m_payouts;

        public struct SLOTIMAGES
        {
            public Image ImageOne;
            public Image ImageTwo;
            public Image ImageThree;
            public Image ImageFour;
        }

        public SLOTIMAGES m_slotImages;

        public float[] m_chancesToWin;
    }
}
