using System;
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
