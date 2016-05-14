using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Resources;

namespace Slots.Model
{
    class AppleSlotsModel : MatchThreeSlotModel
    { 
        public AppleSlotsModel()
        {
            //Set payouts for this game. 
            //NOTE - I did not do math to get sustainable numbers. Could easily have a %Edge take that automatically adjusted payouts to give house X% edge.
            //This could be read from another source rather than hardcoding.
            m_payouts.ImageOnePayoutMultiplier      = .75f;
            m_payouts.ImageTwoPayoutMultiplier      = 1.5f;
            m_payouts.ImageThreePayoutMultiplier    = 7.5f;
            m_payouts.ImageFourPayoutMultiplier     = 50f;

            //This should really go through a deticated file manager class that handles all loading/saving stuff.
            m_slotImages.ImageOne   = Slots.Properties.Resources.AppleSlots_Apple;
            m_slotImages.ImageTwo   = Slots.Properties.Resources.AppleSlots_Worm;
            m_slotImages.ImageThree = Slots.Properties.Resources.AppleSlots_Tree;
            m_slotImages.ImageFour  = Slots.Properties.Resources.AppleSlots_Pie;

            m_chancesToWin = new float[] {
                .22f,
                .12f,
                .08f,
                .03f
            };

            spinningImage = Slots.Properties.Resources.AppleSlots_SpinEffect;
        }
    }
}

/* Image credits:

    Apple   - http://weknowyourdreamz.com/images/apple/apple-02.jpg
    Worm    - http://www.clker.com/cliparts/8/6/d/9/1220545662890146AJ_Apple_Worm.svg.hi.png
    Tree    - http://www.clipartbest.com/cliparts/di6/xao/di6xaoei9.png
    Pie     - http://clipartcow.com/pie-clip-art-image-26965/
*/


