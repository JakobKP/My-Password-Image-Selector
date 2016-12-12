using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPasswordImageSelector.Domain
{
    public interface IUserRepository
    {
        void Add(DUser user);
        void Update(DUser user);
        void Remove(DUser user);
        DUser GetByIDd(Guid userId);
        DUser GetByUsername(string username);
    }
}
