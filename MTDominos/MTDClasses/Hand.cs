using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{

    public class Hand : IEnumerable
    {
        private List<Domino> handOfDominos = new List<Domino>();


        public Hand() {
            BoneYard by = new BoneYard(12);
            for (int i = 0; i < 15; i++) handOfDominos.Add(by.Draw());
        }

        public Hand(BoneYard by, int numPlayers) {
            int max = 15;
            if (numPlayers > 7) max = 10;
            else if (numPlayers > 5) max = 12;
            for (int i = 0; i < max; i++) handOfDominos.Add(by.Draw());
        }


        public int Count
        {
            get { return handOfDominos.Count(); }
        }

        public bool IsEmpty
        { get { if (Count < 1) return true; else return false; } }

        public int Score
        {
            get
            {
                int score = 0;
                foreach (Domino d in handOfDominos)
                {
                    score += d.Score;
                }
                return score;
            }
        }

        public Domino this[int i] {
            get { return handOfDominos[i];  }
        }

        public void Add(Domino d)
        {
            handOfDominos.Add(d);
        }

        public void Draw(BoneYard by)
        {
            Domino d = by.Draw();
            Add(d);
        }





        public int IndexOfDomino(int pipValue)
        {
                int i = 0;
                foreach (Domino d in handOfDominos)
                {
                    if (d.Side1 == pipValue || d.Side2 == pipValue) return i;
                    i++;
                }
                return -1;
        }


        public bool HasDomino(int pipValue)
        {
            if (IndexOfDomino(pipValue) <0) return false;
            return true;
        }


        public Domino GetDomino(int pipValue)
        {
            int i = IndexOfDomino(pipValue);
            if (i < 0) throw new Exception("Domino not in hand");
            else
            {
                Domino d = handOfDominos[i];
                RemoveAt(i);
                return d;
            }
        }




        public int IndexOfDoubleDomino(int pipValue)
        {

            int i = 0;
            foreach (Domino d in handOfDominos)
            {
                if (d.Side1 == d.Side2 && d.Side1 == pipValue) return i;
                i++;
            }
            return -1;
        }

        public List<int> IndexesOfDoubles()
        {
            List<int> i = new List<int>();
            int ind = 0;
            foreach (Domino d in handOfDominos)
            {
                if (d.Side1 == d.Side2) i.Add(ind);
                ind ++;
            }
            return i;

        }

        public int IndexOfHighDouble()
        {
            int h = -1;

            foreach (int ind in IndexesOfDoubles())
            {
                if (handOfDominos[ind].Side1> h) h = handOfDominos[ind].Side1;
            }
            if (h >= 0) return IndexOfDoubleDomino(h);
            else return h;

        }





        public bool HasDoubleDomino(int pipValue)
        {
            if (IndexOfDoubleDomino(pipValue) <0) return false;
            return true;
        }


        public Domino GetDoubleDomino(int pipValue)
        {
            int i = IndexOfDoubleDomino(pipValue);
            if (i < 0)
                throw new Exception("No Double Domino With Value of " + pipValue);
            else {
                Domino d = handOfDominos[i];
                RemoveAt(i);
                return d;
            }
        
        }






        public void Play(int i, Train t)
        {
            Domino d = handOfDominos[i];
            bool mustFlip = false;
            if (t is PrivateTrain)
            {
                PrivateTrain pt = (PrivateTrain)t;
                if (pt.IsPlayable(d, out mustFlip, this))
                    handOfDominos.RemoveAt(i);
                if (mustFlip) d.Flip();
                pt.Play(d, this);
            }
            else throw new Exception("Domino " + d.ToString() + " does not match the train.");

            handOfDominos.RemoveAt(i);
            t.Add(handOfDominos[i]);
        }

        public void Play(Domino d, Train t)
        {
            int i = handOfDominos.IndexOf(d);
            if (i != -1)
            {
                Play(i, t);
            }
            else throw new Exception("Domino " + d + " not in hand.");
            handOfDominos.Remove(d);
            t.Add(d);
        }

        public Domino Play(Train t)
        {
            //computers turn, going to take in train and then find a domino for it from this hand
            int pv = t.PlayableValue;
            int i = IndexOfDomino(pv);
            if (i != -1)
            {
                Domino d = this[i];
                Play(i, t);
                return d;
                //raise event so ui knows to draw?
            }
            else
            {
                throw new Exception("No playable Domino");
            }
        }

        public void RemoveAt(int i)
        {
            handOfDominos.RemoveAt(i);

        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Domino d in handOfDominos)
            {
                yield return d;
            }
        }
    }
}
