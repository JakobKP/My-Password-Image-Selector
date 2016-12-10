using System.Windows.Forms;

using MyPasswordImageSelector.Controller;
using System.Collections.Generic;
using System;

namespace MyPasswordImageSelector.View
{
    public partial class VMain : Form, IMainView {

        List<string> tempIcons;
        int KeyCombinationLength = 0;
        string KeyPhrase1 = "";
        string KeyPhrase2 = "";
        
        Random random = new Random();

        public VMain()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to My Password Image Selector. Enter your master password to unlock. \n If this is your first time, create a new account, by selecting 4 images");
        }

        MainController _controller;

        public void SetController(MainController controller)
        {
            _controller = controller;  
        }

        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyPhrase1 = "";
            KeyPhrase2 = "";
            _controller.Reshuffle();
        }

        public void ReshuffleGrid(List<string> icons)
        {
            KeyCombinationLength = 0;
            tempIcons = new List<string>(icons);
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int rngNum = random.Next(tempIcons.Count);
                    iconLabel.Text = tempIcons[rngNum];
                    iconLabel.ForeColor = System.Drawing.Color.Black;
                    tempIcons.RemoveAt(rngNum);
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Reset()
        {
            KeyPhrase1 = "";
            KeyPhrase2 = "";
            _controller.Reshuffle();
        }

        private void labelSign_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == System.Drawing.Color.Blue)
                    return;
                clickedLabel.ForeColor = System.Drawing.Color.Blue;


                if (KeyPhrase1.Length == 4)
                {
                    KeyPhrase2 = KeyPhrase2 + clickedLabel.Text;
                }
                else
                {
                    KeyPhrase1 = KeyPhrase1 + clickedLabel.Text;
                }

                KeyCombinationLength = KeyCombinationLength + 1;

                if (KeyCombinationLength == 4)
                {
                    if (KeyPhrase1.Length == 4 && KeyPhrase2.Length == 4)
                    {
                        //Both Key phrases entered. Now we do some validation and unlock
                        MessageBox.Show("Phrase1 was: " + KeyPhrase1);
                        MessageBox.Show("Phrase2 was: " + KeyPhrase2);

                        if (_controller.Validate(KeyPhrase1, KeyPhrase2))
                        {
                            MessageBox.Show("System unlocked!");
                            userToolStripMenuItem.Text = "User: Jakob";
                            userToolStripMenuItem.Enabled = true;
                        }
                        else
                            MessageBox.Show("Phrases was not identical!");
                    }
                    else
                    {
                        _controller.Reshuffle();
                    }
                }
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All rights Reserved: Jakob Klein Petersen 2016");
        }
    }
}
