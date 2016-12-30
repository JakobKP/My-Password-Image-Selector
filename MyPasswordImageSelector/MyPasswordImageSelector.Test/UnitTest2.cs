using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;
using System.Data.SQLite;
using NHibernate.Tool.hbm2ddl;
using MyPasswordImageSelector.Domain;
using MyPasswordImageSelector.Repository;

namespace MyPasswordImageSelector.Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestFixture]
        public class UserRepositoryTest
        {
            private ISessionFactory _sessionFactory;
            private Configuration _configuration;

            [OneTimeSetUp]
            public void TestFixtureSetup()
            {
                _configuration = new Configuration();
                _configuration.Configure();
                _configuration.AddAssembly(typeof(DUser).Assembly);
                _sessionFactory = _configuration.BuildSessionFactory();
            }

            [SetUp]
            public void SetupContext()
            {
//                var connection = new SQLiteConnection("Data Source=nhibernate.db;Version=3");
//                connection.Open();
                new SchemaUpdate(_configuration).Execute(false, true);
            }

            [Test]
            public void Can_add_new_product()
            {
                var product = new DUser { Username = "KP", KeyPhrase1 = "sumthing", KeyPhrase2 = "sumthing" };
                IUserRepository repository = new UserRepository();
                repository.Add(product);

                // use session to try to load the product
                using (ISession session = _sessionFactory.OpenSession())
                {
                    var fromDb = session.Get<DUser>(product.Id);
                    // Test that the product was successfully inserted
                    NUnit.Framework.Assert.IsNotNull(fromDb);
                    NUnit.Framework.Assert.AreNotSame(product, fromDb);
                    NUnit.Framework.Assert.AreEqual(product.Username, fromDb.Username);
                    Console.WriteLine(fromDb.Username);
                    Console.WriteLine(fromDb.KeyPhrase1);
                    Console.WriteLine(fromDb.KeyPhrase2);
                }
            }
        }
    }
}
