using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPasswordImageSelector.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace MyPasswordImageSelector.Repository
{
    public class UserRepository : IUserRepository
    {
        public void Add(DUser user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(user);
                transaction.Commit();
            }
        }

        public DUser GetByIDd(Guid userId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<DUser>(userId);
        }

        public DUser GetByUsername(string username)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria(typeof(DUser)).Add(Restrictions.Eq("Name", username)).UniqueResult<DUser>();
        }

        public void Remove(DUser user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(user);
                transaction.Commit();
            }
        }

        public void Update(DUser user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(user);
                transaction.Commit();
            }
        }
    }
}
