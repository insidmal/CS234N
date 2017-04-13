using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClassLibrary
{
    public class BJHand : Hand
    {
        public BJHand() : base()
        {

        }

        public bool HasAce()
        {
            return HasCard(14);
        }

        public int Score
        {
            get
            {
                int v =0;
               foreach(Card c in hand)
                {
                    if (c.Value <= 9) v += c.Value;
                    else if (c.Value<=13) v += 10;
                    else v += 1;

                }
                if (HasAce() && v <= 11) v += 10;
                return v;
            }
        }

        public bool IsBusted()
        {
            if (Score > 21) return true;
            else return false;
        }

    }
}
