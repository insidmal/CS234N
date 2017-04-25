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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void startGame()
        {

        }

        public void PlayerMove()
        {

        }

        public void ComputerMove()
        {

        }

        //event handlers for bust, blackjack, and shuffle

        //CardLoading methods, LoadAllCards will redraw the card elements
        #region CardLoading

        private void LoadAllCards(BJHand playerHand, BJHand dealerHand)
        {
            LoadPlayerCards(playerHand);
            LoadDealerCards(dealerHand);
        }

        private void LoadPlayerCards(BJHand h)
        {
            int i = 0;
            //add enumerator
            foreach(Card c in h)
            {
                LoadCard(c, "p", i++);
            }
        }

        private void LoadDealerCards(BJHand h)
        {
            int i = 0;
            //add enumerator
            foreach (Card c in h)
            {
                if (i == 0)
                {
                    PictureBox box = (PictureBox)this.Controls["dcard0"];
                    box.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\black_back.jpg");
                }
                LoadCard(c, "d", i++);
            }
        }


        private void LoadCard(Card card, string player, int i)
        {
            PictureBox box = (PictureBox)this.Controls[player + "card" + i];
            box.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\" + card.FileName);
        }
        #endregion
    }
}
