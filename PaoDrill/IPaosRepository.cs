using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoDrill
{
    public interface IPaosRepository
    {
        List<Pao> GetAllPaos();
    }
}
