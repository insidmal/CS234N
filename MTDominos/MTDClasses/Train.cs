using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MTDClasses
{
    public class Train
    {
        private List<Domino> dominos = new List<Domino>();
        private int engineValue;

        public Train()
        {
            engineValue = 6;
        }

        public Train(int engineVal)
        {
            engineValue = engineVal;
        }

        #region properties

        public int EngineValue
        {
            get { return engineValue; }
            set { engineValue = value; }
        }

        public bool IsEmpty
        {
            get
            {
                if (dominos.Count < 1) return true;
                else return false;
            }
        }

        public Domino LastDomino
        {

            get { if (dominos.Count == 0)
                {
                    Domino d1 = new Domino(EngineValue, EngineValue);
                    return d1;
                }
                else return dominos[dominos.Count - 1]; }
        }

        public int PlayableValue
        {
            //assuming side2 of the last dominos is the one on the open end of the train
            get { if (IsEmpty) return EngineValue;
                else return LastDomino.Side2; }
        }

        public Domino this[int i]
        {
            get { return dominos[i]; }
        }

        #endregion

        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        public bool IsPlayable(Domino d, out bool mustFlip)
        {
            //I'm assuming that side 2 is the end right side and side 1 is left and that we're moving right so side 1 of played domino connects to side 2 of dominos on train
                if (LastDomino.Side2 == d.Side1) { mustFlip = false; return true; }
                else if (LastDomino.Side2 == d.Side2) { mustFlip = true; return true; }
                else { mustFlip = false; return false; }
            }


        public void Play(Domino d)
        {
            bool flip;
            if (IsPlayable(d, out flip))
            {
                if (flip) d.Flip();
                Add(d);
            }
        }

        public string Show(int number)
        {
            //i have no idea what this is supposed to do
            return "noidea_string";
        }

        

        public override string ToString()
        {
            string r = "";
            foreach(Domino d in dominos)
            {
                r += d + "/n";
                
            }
            return r;
        }

    }
}
