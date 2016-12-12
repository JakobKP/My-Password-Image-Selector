using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;
using MyPasswordImageSelector.Domain;
using System.Data.SQLite;
using NHibernate.Tool.hbm2ddl;

namespace MyPasswordImageSelector.Test
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            _sessionFactory = new Configuration().Configure().AddAssembly(typeof(DUser).Assembly).BuildSessionFactory();
        }

        [SetUp]
        public void SetupContext()
        {
            var connection = new SQLiteConnection("Data Source=nhibernate.db;Version=3");
            connection.Open();
            new SchemaExport(_configuration).Execute(false, true, false, connection, null);
        }
    }

}
