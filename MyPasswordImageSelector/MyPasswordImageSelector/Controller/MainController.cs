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

        public bool Validate(string Phrase1, string Phrase2)
        {
            if (Phrase1 == Phrase2)
            {
                //If phrases matches. Then search the user table for a match. If the user is found. Set the active user.  Return true
                return true;
            }
            return false;
        }
    }
}
