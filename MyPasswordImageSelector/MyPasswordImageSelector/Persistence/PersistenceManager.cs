using MyPasswordImageSelector.Domain;
using MyPasswordImageSelector.Repository;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPasswordImageSelector.Persistence
{
    

    public class PersistenceManager
    {
        private Configuration _configuration;
        private static UserRepository _repository;
        public UserRepository UserRepository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new UserRepository();
                }
                return _repository;
            }

        }


        public PersistenceManager()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(DUser).Assembly);

            new SchemaUpdate(_configuration).Execute(false, true);
        }
    }
}
