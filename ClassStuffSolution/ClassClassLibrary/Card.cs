using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClassLibrary
{
    public class Card
    {
        //int 1-13 for values
        //int 1-4 for suits
        private int suit;
        private int value;

        private static string[] suits = { "", "Clubs", "Diamonds", "Spades", "Hearts" };
        private static string[] values = { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King", "Ace" };
        
        public Card()
        {
            suit = 1;
            value = 1;
        }

        public Card(int v, int s)
        {
            suit = s;
            value = v;
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public int Suit
        {
            get { return this.suit; }
            set { this.suit = value; }
        }

        public bool IsAce()
        {
            if (value == 13) return true;
            else return false;
        }

       public string GetSuit() {
            return suits[suit];
        }

       public string GetValue() {
            return values[value];
        }

       public bool IsBlack() {
            if (suit % 2 != 0) return true;
            else return false;
        }

        public bool IsClub() {
            if (suit == 1) return true;
            else return false;
        }

       public bool IsDiamond() {
            if (suit ==2) return true;
            else return false;
        }

       public bool IsFaceCard() {
            if (value > 10) return true;
            else return false;

        }

        public bool IsHeart() {
            if (suit == 4) return true;
            else return false;
        }

       public bool IsRed() {
            if (!IsBlack()) return true;
            else return false;
        }

       public bool IsSpade() {
            if (suit == 3) return true;
            else return false;
        }

       public bool SetSuit() {
            return false;
       }

        public bool SetVale()
        {
            return false;
        }

        public bool HasMatchingValue(Card other)
        {
            if (other.Value == value)
                return true;
            else return false;
        }

        public bool HasMatchingSuit(Card other)
        {
            if (other.Suit == suit) return true;
            else return false;
        }

        public string FileName
        {
            get
            {
                return "card" + values[value].Substring(0, 1).ToLower() + suits[suit].Substring(0, 1).ToLower() + ".jpg";
            }
        }



        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }


    }
}
