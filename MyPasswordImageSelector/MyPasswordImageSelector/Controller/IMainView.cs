using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPasswordImageSelector.Controller
{
    public interface IMainView
    {
        void SetController(MainController controller);
        void ReshuffleGrid(List<string> icons);
        void Unlock(Boolean userFound);
    }
}
