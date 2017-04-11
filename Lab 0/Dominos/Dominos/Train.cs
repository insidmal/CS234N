using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTDClasses;


namespace Dominos
{
    class Train
    {
        private List<Domino> dominos;
        private int engineValue;

        public Train()
        {
            engineValue = 1;
        }

        public Train(int engineVal)
        {
            engineValue = engineVal;
        }

        #region properties

        public int Count
        { get { return dominos.Count; } }

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
            get { return dominos[dominos.Count - 1]; }
        }

        public int PlayableValue
        {
            //I'm not familiar with the game so don't know what the playable value is supposed to be, I assumed it was a side of last played domino but that was just a guess
            get { return LastDomino.Side2; }
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
            //i don't know the rules of the game so am just guessing assumption that my IsPlayable is correct, and also going to make an assumption that if it is side1 they don't need to flip, and if it is side2 that they do? also assuming they can only play on the last domino in the train
            if (LastDomino.Side1 == d.Side1) { mustFlip = false; return true; }
            else if (LastDomino.Side2 == d.Side2) { mustFlip = true; return true; }
            else return false;

        }

        public void Play(Domino d)
        {
            //not sure what playing a domino is, but assuming when one is played it is added on to the train?
            dominos.Add(d);
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
                r += d + "; ";
                
            }
        }

    }
}
