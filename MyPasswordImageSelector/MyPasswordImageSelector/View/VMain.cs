using System.Windows.Forms;

using MyPasswordImageSelector.Controller;
using System.Collections.Generic;
using System;

namespace MyPasswordImageSelector.View
{
    public partial class VMain : Form, IMainView {

        List<string> tempIcons;
        
        Random random = new Random();

        public VMain()
        {
            InitializeComponent();
        }

        MainController _controller;

        public void SetController(MainController controller)
        {
            _controller = controller;  
        }

        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Reshuffle();
        }

        public void ReshuffleGrid(List<string> icons)
        {
            tempIcons = new List<string>(icons);
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int rngNum = random.Next(tempIcons.Count);
                    iconLabel.Text = tempIcons[rngNum];
                    tempIcons.RemoveAt(rngNum);
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
