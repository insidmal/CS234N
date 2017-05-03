using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassClassLibrary;

namespace Blackjack
{
    public partial class bjForm : Form
    {
        public bjForm()
        {
            InitializeComponent();
            startGame(true);

        }

        Deck deck = new Deck();
        BJHand playerHand;
        BJHand computerHand;


        private void hitButton_Click(object sender, EventArgs e)
        {
            bool bust;
            bool dbust;
            bool canmove;
            PlayerMove(out bust);
            if (bust) {
                LoadAllCards(playerHand, computerHand, true);
                MessageBox.Show("Oh no! You busted." + Environment.NewLine + "Dealer Wins!");
                startGame(false);
            }
            else {
                LoadPlayerCards(playerHand);
                ComputerMove(out canmove, out dbust);
                if (dbust)
                {
                    LoadDealerCards(computerHand, true);
                    MessageBox.Show("The Dealer Busted." + Environment.NewLine + "You Win!");
                    startGame(false);
                }
                else LoadDealerCards(computerHand, false);

            }
        }

        private void newHandButton_Click(object sender, EventArgs e)
        {
            startGame(false);
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            bool dbust;
            bool canmove = true;
            int pScore;
            int cpuScore ;

            while (canmove)
            {
                ComputerMove(out canmove, out dbust);
                LoadDealerCards(computerHand, false);
                if (dbust) { LoadDealerCards(computerHand, true); MessageBox.Show("The Dealer Busted." + Environment.NewLine + "You Win!"); startGame(false); return; }
            }
            cpuScore = computerHand.Score;
            pScore = playerHand.Score;

            //dealer can't go and player stood, so calcluate winner -- we already checked busting so can just compare raw scores
            if (cpuScore > pScore)
            {
                LoadAllCards(playerHand, computerHand, true);
                MessageBox.Show("Dealer Won" + Environment.NewLine + "---------------" + Environment.NewLine + "Dealer: " + cpuScore + Environment.NewLine + "You: " + pScore);
                startGame(false);
            }
            else if (cpuScore < pScore)
            {
                LoadAllCards(playerHand, computerHand, true);
                MessageBox.Show("You Won" + Environment.NewLine + "---------------" + Environment.NewLine + "Dealer: " + cpuScore + Environment.NewLine + "You: " + pScore);
                startGame(false);
            }
            else
            {
                LoadAllCards(playerHand, computerHand, true);
                MessageBox.Show("Push" + Environment.NewLine + "---------------" + Environment.NewLine + "Dealer: " + cpuScore + Environment.NewLine + "You: " + pScore);
                startGame(false);
            }
        }

        private void startGame(bool newDeck)
        {
            //option for starting from a new deck, or if new deck has less than possibly playable cards
            if (newDeck == true || deck.NumCards < 10)
            {
                deck = new Deck();
                deck.Shuffle();
                MessageBox.Show("Shuffling the deck...");
            }

            //build new hands for player and computer
            playerHand = new BJHand();
            computerHand = new BJHand();
            Card c1;
            Card c2;
            string extra = "!";
            for (int i = 0; i < 2; i++)
            {
                c1 = deck.Deal();
                playerHand.Add(c1);
                c2 = deck.Deal();
                computerHand.Add(c2);
            }

            //load hands in UI
            LoadAllCards(playerHand, computerHand, false);
            if (playerHand.Score == 21) {
                if (computerHand.Score == 21) extra = " ..but so did the dealer." + Environment.NewLine + "The game is a tie!";
                LoadAllCards(playerHand, computerHand, true);
                MessageBox.Show("You got a Blackjack"+extra); startGame(false);
            }
            else if (computerHand.Score == 21) {
                if (playerHand.Score == 21) extra = " ..but so did the dealer." + Environment.NewLine + "The game is a tie!";
                LoadAllCards(playerHand, computerHand, true);
                MessageBox.Show("The dealer got a Blackjack"+extra); startGame(false);
            }


        }

        public void PlayerMove(out bool bust)
        {
            Card c = deck.Deal();
            playerHand.Add(c);
            LoadPlayerCards(playerHand);
            if (playerHand.Score > 21) { bust = true; }
            else bust = false;
        }

        public void ComputerMove(out bool canmove, out bool bust)
        {
            //computer stands on 17 or greater, hits on less than 17 unless ace is present - hits on 17
            int score = computerHand.Score;
            canmove = true;
            if (score < 17 || (score == 17 && computerHand.HasAce()))
            {
                Card c = deck.Deal();
                computerHand.Add(c);
            }
            else canmove = false;
            LoadDealerCards(computerHand, false);
            if (computerHand.Score > 21) bust = true;
            else bust = false;
        }

        //event handlers for bust, blackjack, and shuffle

        //CardLoading methods, LoadAllCards will redraw the card elements
        #region CardLoading

        private void LoadAllCards(BJHand playerHand, BJHand dealerHand, bool end)
        {
            LoadPlayerCards(playerHand);
            LoadDealerCards(dealerHand, end);
        }

        private void LoadPlayerCards(BJHand h)
        {
            int i = 0;
            //load cards, probably would have made more sense to use a for loop since I'm going to 5 anyway, oh well
            foreach(Card c in h)
            {
                LoadCard(c, "p", i++);
            }
            //hide the missing cards
            for (int z = i; z < 5; z++)
            {
                PictureBox box = (PictureBox)this.Controls["pcard" + z];
                box.Visible = false;

            }
        }

        private void LoadDealerCards(BJHand h, bool turnfirst)
        {
            int i = 0;
            //load cards
            foreach (Card c in h)
            {
                if (i == 0 && turnfirst == false)
                {
                    PictureBox box = (PictureBox)this.Controls["dcard0"];
                    box.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\black_back.jpg");
                    i++;
                }
                else LoadCard(c, "d", i++);
            }
            //hide rest
            for (int z = i; z < 5; z++)
            {
                PictureBox box = (PictureBox)this.Controls["dcard"+z];
                box.Visible = false;

            }

        }


        private void LoadCard(Card card, string player, int i)
        {
            PictureBox box = (PictureBox)this.Controls[player + "card" + i];
            box.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\" + card.FileName);
            box.Visible = true;
        }
        #endregion


    }
}
