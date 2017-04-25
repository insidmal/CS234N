using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClassLibrary
{
   public class Deck
    {

        //events for busted
        //events for blackjack
        //events

        private List<Card> cards;
        private static Random rnd = new Random();

        public delegate void EmptyHandler(Deck d);
        public event EmptyHandler Empty;

        public Deck()
        {
            cards = new List<Card>();
            for(int s = 1;s<=4; s++)
            {
                for(int v = 1; v<=14;v++)
                {
                    Card card = new Card(v, s);
                    cards.Add(card);

                }
            }
            Empty = new EmptyHandler(HandleEmpty);
        }

        public int NumCards
        {
            get { return cards.Count; }
        }

        public bool IsEmpty()
        {
            if (cards.Count <= 0) return true;
            else return false;
        }

        public void Shuffle()
        {
            Card temp = new Card();
            int i = cards.Count;
            while (i>1)
            {
                i--;

                int n = rnd.Next(i + 1);
                temp = cards[i];
                cards[i] = cards[n];
                cards[n] = temp;
            }
        }

        public Card Deal()
        {
            if (NumCards>12)
            {
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            } else { Empty(this); return null; }
        }

        public void HandleEmpty(Deck d)
        {
            //internal way to handle empty, handler added in constructor
        }

        public override string ToString()
        {
            string text = null;
            foreach(Card card in cards)
            {
                text += card + "; ";
            }
            return text;
        }
    }
}
