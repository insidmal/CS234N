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
            //TO DO:
            // write properties from slide 10 - designing a class
            // test properties

            //write methods from slide 10; all are true or false; don't need to test console
            //TestCardConstructors(1,3);

            //TestDeck();
            TestHand();
            Console.WriteLine();
            Console.ReadLine();

        }

        static void TestHand()
        {
            Console.WriteLine("Testing Empty Constructor");
            Hand h2 = new Hand();
            Console.WriteLine("Output expected: Random 5 card hand: " + h2);
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
