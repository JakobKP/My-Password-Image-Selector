using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyPasswordImageSelector.Controller;
using MyPasswordImageSelector.View;

namespace MyPasswordImageSelector
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            VMain view = new VMain();
            MainController controller = new MainController(view);
            controller.Reshuffle();
            view.ShowDialog();
        }
    }
}
