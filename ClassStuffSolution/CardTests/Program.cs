using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassClassLibrary;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {

            //write methods from slide 10; all are true or false; don't need to test console
            //TestCardConstructors(1,3);

            //TestDeck();
             TestHand();
            //TestBJHand();

            Console.WriteLine();
            Console.ReadLine();

        }


        static void TestBJHand()
        {
            Console.WriteLine("Testing Score with just Aces to check my value");
            BJHand bj = new BJHand();
            Card c = new Card(14, 1);
            bj.Add(c);
            Console.WriteLine("Expecting Ace from Card object: " + c);
            if (bj.HasAce() == true) {
                Console.WriteLine("Has ace tested true");
            }
            else Console.WriteLine("has ace tested false");

            Console.WriteLine("We already have an ace, now adding a King");
            Card c2 = new Card(13, 2);
            bj.Add(c2);
            Console.WriteLine("Score should be 21 (ace + king): " + bj.Score);
            Console.WriteLine("Rcreating a new bj hand with an ace and a jack");
            BJHand bj2 = new BJHand();
            bj2.Add(c);
            Card c3 = new Card(11, 3);
            Console.WriteLine("testing me new card to make sure it is correct card I created: " + c3);
            bj2.Add(c3);
            Console.WriteLine("testing ace and jack, expecting 21: " + bj.Score);

            Console.WriteLine("adding another card to give the ace a 1 value, adding a 5");
            Card c4 = new Card(5, 4);
            bj2.Add(c4);
            Console.WriteLine("expecting score 16 (ace(1), jack(10), 5): " + bj2.Score);
            Console.WriteLine("Busting hand to make it over 21, adding 2 more 5 card objects");
            bj2.Add(c4);
            bj2.Add(c4);
            if (bj2.IsBusted())
                Console.WriteLine("Busted returned true, here is the score (ace(1), jack(10), 5, 5, 5): " + bj2.Score);
            else Console.WriteLine("Busted returned false");
            Console.WriteLine("Testing a new hand with no aces, adding a king and 5 created earlier for simplicity");
            BJHand bj3 = new BJHand();
            bj3.Add(c2);
            bj3.Add(c4);
            Console.WriteLine("Score should be 15 (king + 5): " + bj3.Score);
            Console.WriteLine("busting without an ace");
            bj3.Add(c4);
            bj3.Add(c4);
            if (bj3.IsBusted() == true)
                Console.WriteLine("Busted true, score should be 25: " + bj3.Score);
            else Console.WriteLine("Bust failed! Houston you have a problem!");

        }


        static void TestHand()
        {
            //Console.WriteLine("Testing Empty Constructor");
            //Hand h2 = new Hand();
            //Console.WriteLine("Output expected: Random 5 card hand: " + h2);
            Console.WriteLine("Testing Constructor using List of Cards");
            List<Card> cards = new List<Card>() { new Card(1, 1), new Card(1,2), new Card(2,1), new Card(2,3), new Card(4,4) };
            Hand h1 = new Hand(cards);
            Console.WriteLine("Output expected: 1C 1D 2C 2S 4H: " + h1);
            Console.WriteLine();
            Console.WriteLine("Searching for Index based on card; expecting index location: "+ h1.IndexOf(new Card(2, 1)));
            Console.WriteLine("Searching for Index based on card; expecting  -1: " + h1.IndexOf(new Card(2, 2)));
            Console.WriteLine("Searching for Index based on value; expecting index location: " + h1.IndexOf(4));
            Console.WriteLine("Searching for Index based on value; expecting -1: " + h1.IndexOf(8));
            Console.WriteLine("Searching for Index based on value and suit; expecting index location: " + h1.IndexOf(2,1));
            Console.WriteLine("Searching for Index based on value and suit; expecting -1: " + h1.IndexOf(2,8));
            Console.WriteLine();
            Console.WriteLine("Checking using HasCard based on card; expecting true: " + h1.HasCard(new Card(2, 1)));
            Console.WriteLine("Searching using HasCard based on card; expecting false: " + h1.HasCard(new Card(2, 2)));
            Console.WriteLine("Searching using HasCard based on value; expecting true: " + h1.HasCard(2));
            Console.WriteLine("Searching using HasCard based on value; expecting false: " + h1.HasCard(8));
            Console.WriteLine("Searching using HasCard based on value and suit; expecting true: " + h1.HasCard(2, 1));
            Console.WriteLine("Searching using HasCard value and suit; expecting false: " + h1.HasCard(2, 8));
            Console.WriteLine("Displaying Hand again to make sure nothing modified it expecting same hand as above:" + h1);
            Console.WriteLine();
            Console.WriteLine("Discharging Card index position 2");
            h1.Discharge(2);
            Console.WriteLine("New deck without 3rd card: "+ h1);

        } 


        static void TestDeck()
        {
            Console.WriteLine("Creating Deck");
            Deck d1 = new Deck();
            Console.WriteLine("How many cards are there? Expecting 52" + d1.NumCards);
            Console.WriteLine("Expecting Lines for Deck, will be long list:"+d1);
            Console.WriteLine("Shuffling Deck");
            d1.Shuffle();
            Console.WriteLine("Expecting Lines for Shuffled Deck, will be long list:" + d1);
            Console.WriteLine("Dealing card, will then display list -- card should be first in list and removed from following list:" + d1.Deal());
            Console.WriteLine("And now the new deck:" + d1);
            Console.WriteLine("How many cards are left? Expecting 51" + d1.NumCards);
            Console.WriteLine("Is it Empty? Expecting no:" + d1.IsEmpty());
            Console.WriteLine("Now dealing remaining cards in for loop based on Count");
            int c = d1.NumCards;
            for (int i = 0;i<c;i++)
            {
                d1.Deal();

            }
            Console.WriteLine("How many cards are there? Expecting 0: " + d1.NumCards);

        }

        static void TestCardConstructors(int v, int s)
        {
            Card c = new Card(v,s);
            Console.WriteLine("Testing is methods");
            Console.WriteLine("The card is " + c);
            Console.WriteLine("Is Red " + c.IsRed());
            Console.WriteLine("Is Ace " + c.IsAce());
            Console.WriteLine("Is Black " + c.IsBlack());
            Console.WriteLine("Is Club " + c.IsClub());
            Console.WriteLine("Is Diamond " + c.IsDiamond());
            Console.WriteLine("Is FaceCard " + c.IsFaceCard());
            Console.WriteLine("Is Heart " + c.IsHeart());
            Console.WriteLine("Is Red " + c.IsRed());
            Console.WriteLine("Is Spade " + c.IsSpade());

        }
    }
}
