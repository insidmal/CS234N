using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClassLibrary
{
    public class Hand
    {
        private List<Card> hand = new List<Card>();

        public Hand()
        {
            Deck d1 = new Deck();
            d1.Shuffle();
            for (int i = 0; i < 5; i++) hand.Add(d1.Deal());
        }

        public Hand(List<Card> cards)
        {
            int max = cards.Count;
            for (int i = 0; i < max; i++) hand.Add(cards[i]);
        }

        public int NumCards
        {
            get { return hand.Count; }
        }

        public Hand Add(Card c)
        {
            hand.Add(c);
            return new Hand(hand);
        }

        public Card GetCard(int i)
        {
            return hand[i];
        }

       public int IndexOf(Card c)
        {


            int i = 0;
            foreach (Card card in hand)
            {
                if (card.Value == c.Value && card.Suit == c.Suit) return i;
                i++;
            }
            return -1;
        }


        public int IndexOf(int v)
        {
            int i = 0;
             foreach(Card card in hand)
            {
                if (card.Value == v) return i;
                i++;
            }
            return -1;
        }

        public int IndexOf(int v, int s)
        {
            int i = 0;
            foreach (Card card in hand)
            {
                if (card.Value == v && card.Suit == s) return i;
                i++;
            }
            return -1;
        }



        public bool HasCard(Card c)
        {
            if (this.IndexOf(c) >= 0) return true;
            else return false;
        }

        public bool HasCard(int v)
        {
            if (this.IndexOf(v) >= 0) return true;
            else return false;
        }

        public bool HasCard(int v, int s)
        {
            if (this.IndexOf(v,s) >= 0) return true;
            else return false;

        }

        public Card Discharge(int i)
        {
            Card card = hand[i];
            hand.Remove(hand[i]);
            return card;
        }

        public override string ToString()
        {
            string text = null;
            foreach (Card card in hand)
            {
                text += card + "; ";
            }
            return text;

        }

    }
}
