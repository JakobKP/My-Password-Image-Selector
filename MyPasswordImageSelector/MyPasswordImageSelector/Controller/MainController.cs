using MyPasswordImageSelector.Domain;
using MyPasswordImageSelector.Persistence;
using MyPasswordImageSelector.Repository;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPasswordImageSelector.Controller
{
    public class MainController
    {
        IMainView _view;
        PersistenceManager PManager;
        IUserRepository _repository;
        List<string> icons = new List<string>() { "b", "e", "f", "h", "j", "k", "l", "m", "o", "p", "t", "æ", "å", ",", ".", ":", "<", "!", "¤", "%", "(", "?", "~", "'", "*" };

        public MainController(IMainView view)
        {
            _view = view;
            view.SetController(this);
            PManager = new PersistenceManager();
            _repository = PManager.UserRepository;
        }

        public void Reshuffle()
        {
            _view.ReshuffleGrid(icons);
        }

        //Båd, cykel, mand, fly
        public bool Validate(string Phrase1, string Phrase2)
        {
            if (Phrase1 == Phrase2)
            {
                if (_repository.GetByKeyPhrases(Phrase1, Phrase2) != null)
                {
                    Reshuffle();
                    return true;
                }
                else
                {
                    var newUser = new DUser { Username = "KP", KeyPhrase1 = Phrase1, KeyPhrase2 = Phrase2 };
                    _repository.Add(newUser);
                }                    
            }
            return false;
        }
    }
}
