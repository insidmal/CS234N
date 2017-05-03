using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class PrivateTrain : Train
    {
        private Hand hand;
        private bool isOpen;

        public PrivateTrain(Hand h) : base()
    {
        hand = h;
            isOpen = false;
    }

        public PrivateTrain(Hand h, int ev) : base(ev)
        {
            hand = h;
            isOpen = false;
        }

        public bool IsOpen
        {
            get { return isOpen; } 
        }

        public void Open()
        {
            isOpen = true;
        }

        public void Close()
        {
            isOpen = false;
        }

        public bool IsPlayable(Domino d, out bool mustFlip, Hand h)
        {
            if (h == hand)
            {
                return base.IsPlayable(d, out mustFlip);
            }
            else {
                if (isOpen == true)
                {
                    return base.IsPlayable(d, out mustFlip);
                }
                else
                {
                    mustFlip = false;
                    return false;
                }

            }
        }
        public void Play(Domino d, Hand h)
        {
            bool mustFlip;
            if (IsPlayable(d, out mustFlip, h))
            {
                if (mustFlip == true) d.Flip();
                base.Play(d);
                Add(d);
            }
            else throw new ArgumentException("Domino " + d + " cannot be played.");

        }
    }
}
