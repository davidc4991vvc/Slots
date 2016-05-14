using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slots.Model.Utility
{
    public static class RandomSelection
    {
        //Returns the position+1 of the winner in the array of passed in winPercents.
        //Returns 0 if total% is less than 1.0 and none of the passed in %s won.
        //Returns -1 if %s are over 1.0 or any other errors occur. 
        public static int SelectWinner(float[] winPercents )
        {
            float totalPercent = 0;

            for (int i = 0; i < winPercents[i]; i++)
            {
                totalPercent += winPercents[i];

                if (totalPercent > 1)
                {
                    return -1;
                }
            }

            int randomSeed = ((((DateTime.UtcNow.Millisecond) * 2) + 9) * 8);

            Random rand = new Random(randomSeed); //I am aware this is probably not up to most slot machine standards.

            double selection = rand.NextDouble();

            totalPercent = 1;

            for (int i = 0; i < winPercents.Length; i++)
            {
                //Match found
                if (selection >= totalPercent - winPercents[i])
                {
                    return i+1;
                }

                //Look at next value
                else
                {
                    totalPercent -= winPercents[i];
                }
            }
            //No matches found - return 0;
            return 0;
        }

        public static int GetRandomInt(int minVal, int maxVal)
        {
            int randomSeed = ((((DateTime.UtcNow.Millisecond) * 6) + 2) * 3);

            Random rand = new Random(randomSeed);

            return rand.Next(minVal, maxVal);
        }
    }
}
