using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPasswordImageSelector.Domain
{
    public class DUser
    {
        public virtual Guid Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string KeyPhrase1 { get; set; }
        public virtual string KeyPhrase2 { get; set; }
    }
}
