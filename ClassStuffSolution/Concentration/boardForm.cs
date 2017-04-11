using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassClassLibrary;

/* turn in ifll card,s shuffle cards, load card, ismatch, filename, hasmatcingvalue
 */

namespace Concentration
{
    public partial class boardForm : Form
    {
        public boardForm()
        {
            InitializeComponent();
        }

        #region Instance Variables
        //* ToDo:  Replace this array of strings with an array of Cards
        //* Notice that my code uses an array of 21 elements and leaves the first element empty
        //string[] cards = new string[21];
        Card[] cards = null;
        const int NOT_PICKED_YET = -1;
        int index1 = NOT_PICKED_YET;
        int index2 = NOT_PICKED_YET;
        int matches = 0;
        Random generator = new Random();
        #endregion

        //methods need updated to uses card class
        // fill cards, shuffle cards, load cards, ismatch;


        #region Methods

        private void FillCards()
        {
            //* Notice that my array ignores index 0
            int i = 1;

            //* suits go from 1 to 4
            for (int suit = 1; suit <= 4; suit++)
            {
                //* I used the first 5 cards.  Ace = 1, 2 = 2 ...
                for (int value = 1; value <= 5; value++)
                {
                    //* The right side of this assignment statement should construct a Card object
                    cards[i] = new Card(value, suit);
                    i++;
                }
            }
        }

        private void ShuffleCards()
        {
            //* Notice that my array ignores index 0
            for (int i = 1; i <= 20; i++)
            {
                int randomIndex = generator.Next(1, 21);
                Card temp = cards[randomIndex];
                cards[randomIndex] = cards[i];
                cards[i] = temp;
            }
        }

        private void LoadCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            //* edit the very last part of this assignment statment to use the Filename property of the card class
            card.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\" + cards[i].FileName);
        }

        // This method doesn't change.  It is the same for every card.
        private void LoadCardBack(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\black_back.jpg");
        }

        // This method doesn't change.  It manipulates the user interface and is not based on a card.
        private void HideCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Enabled = false;
            card.Visible = false;
        }

        //* ToDo:  Edit this method.  2 cards are the same if the value and the suit are the same.
        //* Would it be appropriate to add a method to the Card class called IsMatch?
        private bool IsMatch(int index1, int index2)
        {
            if (cards[index1].HasMatchingValue(cards[index2]))
                return true;
            else
                return false;
        }

        // This method doesn't change.  It manipulates the user interface and is not based on a card.
        private void HideAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = false;
                card.Visible = false;
            }
        }

        // This method doesn't change.  It manipulates the user interface and is not based on a card.
        private void ShowAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = true;
                card.Visible = true;
            }
        }

        // This method doesn't change.  It manipulates the user interface and is not based on a card.
        private void DisableAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = false;
            }
        }

        // This method doesn't change.  It manipulates the user interface and is not based on a card.
        private void DisableCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Enabled = false;
        }

        // This method doesn't change.  It manipulates the user interface and is not based on a card.
        private void EnableAllVisibleCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                if (card.Visible)
                    card.Enabled = true;
            }
        }

        #endregion
        // This event handler doesn't change.  It calls methods that you already changed.
        private void frmBoard_Load(object sender, EventArgs e)
        {
            FillCards();
            ShuffleCards();
            for (int i = 1; i <= 20; i++)
            {
                LoadCardBack(i);
            }
        }

        // This event handler doesn't change.  It calls methods that you already changed.
        private void card_Click(object sender, EventArgs e)
        {
            PictureBox card = (PictureBox)sender;
            int cardIndex = int.Parse(card.Name.Substring(4));
            if (index1 == NOT_PICKED_YET)
            {
                index1 = cardIndex;
                LoadCard(cardIndex);
                DisableCard(cardIndex);
            }
            else
            {
                index2 = cardIndex;
                LoadCard(cardIndex);
                DisableAllCards();
                flipTimer.Enabled = true;
            }
        }

        // This event handler doesn't change.  It calls methods that you already changed.
        private void flipTimer_Tick(object sender, EventArgs e)
        {
            flipTimer.Enabled = false;
            if (IsMatch(index1, index2))
            {
                HideCard(index1);
                HideCard(index2);
                index1 = NOT_PICKED_YET;
                index2 = NOT_PICKED_YET;
                matches++;
                if (matches == 10)
                {
                    MessageBox.Show("Game Over");
                }
                else
                    EnableAllVisibleCards();
            }
            else
            {
                LoadCardBack(index1);
                LoadCardBack(index2);
                index1 = NOT_PICKED_YET;
                index2 = NOT_PICKED_YET;
                EnableAllVisibleCards();
            }
        }
    }
}
