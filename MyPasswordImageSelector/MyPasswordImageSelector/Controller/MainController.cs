using MyPasswordImageSelector.Domain;
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


namespace MyPasswordImageSelector.Controller
{
    public class MainController
    {
        IMainView _view;
        IUserRepository _repository;
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        List<string> icons = new List<string>() { "b", "e", "f", "h", "j", "k", "l", "m", "o", "p", "t", "æ", "å", ",", ".", ":", "<", "!", "¤", "%", "(", "?", "~", "'", "*" };

        public MainController(IMainView view)
        {
            _view = view;
            view.SetController(this);
            _repository = new UserRepository();

            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(DUser).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();

            var connection = new SQLiteConnection("Data Source=nhibernate.db;Version=3");
            connection.Open();
            new SchemaExport(_configuration).Execute(false, true, false, connection, null);
        }

        public void Reshuffle()
        {
            _view.ReshuffleGrid(icons);
        }

        public bool Validate(string Phrase1, string Phrase2)
        {
            if (Phrase1 == Phrase2)
            { 
                if (_repository.GetByKeyPhrases(Phrase1, Phrase2) != null)
                {
                    _view.Unlock(true);
                    return true;
                } else
                {
                    //user 2 identical phrases, but user not found. Prompt user to create one
                }
                    
            }
            return false;
        }
    }
}
