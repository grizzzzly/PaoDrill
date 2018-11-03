using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PaoDrill
{
    [XmlRoot("PaosList"), Serializable]
    public class PaosList
    {
        [XmlElement("Pao")]
        public List<Pao> Paos { get; set; }
    }
}
