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

        public bool HasDomino(int pipValue)
        {
            foreach (Domino d in handOfDominos)
            {
                if (d.Side1 == pipValue || d.Side2 == pipValue) return true;
            }
            return false;
        }


        public Domino GetDomino(int pipValue)
        {
            if (HasDomino(pipValue))
            {
                foreach (Domino d in handOfDominos)
                {
                    if (d.Side1 == pipValue || d.Side2 == pipValue) return d;
                }
                return null;
            }
            else return null;
        }

        public int IndexOfDomino(int pipValue)
        {
            if (HasDomino(pipValue))
            {
                int i = 0;
                foreach (Domino d in handOfDominos)
                {
                    if (d.Side1 == pipValue || d.Side2 == pipValue) return i;
                    i++;
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }


        public bool HasDoubleDomino(int pipValue)
        {
            foreach (Domino d in handOfDominos)
            {
                if (d.Side1 == pipValue && d.Side2 == pipValue) return true;
            }
            return false;
        }



        public Domino GetDoubleDomino(int pipValue)
        {
            if (HasDoubleDomino(pipValue)) {
                foreach (Domino d in handOfDominos)
                {
                    if (d.Side1 == d.Side2 && d.Side1 == pipValue) return d;
                }
                return null;
            }
            else return null;
        }







        public int IndexOfDoubleDomino (int pipValue)
        {
            if (HasDoubleDomino(pipValue))
            {
                int i = 0;
                foreach (Domino d in handOfDominos)
                {
                    if (d.Side1 == d.Side2 && d.Side1 == pipValue) return i;
                    i++;
                }
                return -1;
            }
            else return -1;
        }

        public int IndexOfHighDouble()
        {
            int h = -1;
            int i = 0;
           foreach(Domino d in handOfDominos)
            {
                if (d.Side1 == d.Side2 && d.Side1 > h) h = d.Side1;
                i++;
            }
            if (h >= 0) return IndexOfDoubleDomino(h);
            else return h;
        
        }

        public void Play(Domino d, Train t)
        {
            handOfDominos.Remove(d);
            t.Add(d);
        }

        public void Play(int i, Train t)
        {
            handOfDominos.RemoveAt(i);
            t.Add(handOfDominos[i]);
        }

        public void Play(Train t)
        {
            //??????
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
