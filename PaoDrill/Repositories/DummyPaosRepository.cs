using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoDrill.Repositories
{
    public class DummyPaosRepository : IPaosRepository
    {
        public List<Pao> GetAllPaos()
        {
            return new List<Pao>
            {
                new Pao { Number = "00", Person = "Sissi", Action = "fait signe",  Object = "tresses", ObjectComment = "Je vous assure !" },
                new Pao { Number = "01", Person = "Stefan Edberg", Action = "glisse", Object = "aéroglisseur"},
                new Pao { Number = "02", Person = "Isaac Newton", Action = "trouve", Object = "pomme"},
                new Pao { Number = "03", Person = "Sophie Marceau", Action = "embrasse", Object = "écouteurs"}
            };
        }
    }
}
