using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPasswordImageSelector.Controller
{
    public class MainController
    {
        IMainView _view;

        List<string> icons = new List<string>() { "b", "e", "f", "h", "j", "k", "l", "m", "o", "p", "t", "æ", "å", ",", ".", ":", "<", "!", "¤", "%", "(", "?", "~", "'", "*" };

        public MainController(IMainView view)
        {
            _view = view;
            view.SetController(this);
        }

        public void Reshuffle()
        {
            _view.ReshuffleGrid(icons);
        }
    }
}
