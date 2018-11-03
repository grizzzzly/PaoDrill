using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PaoDrill
{
    public class Pao
    {
        public Pao()
        { }
        public Pao (string number, string person, string action, string obj)
        {
            Number = number;
            Person = person;
            Action = action;
            Object = obj;
        }

        [XmlElement("Number")]
        public string Number { get; set; }

        [XmlElement("Person")]
        public string Person { get; set; }

        [XmlElement("Action")]
        public string Action { get; set; }

        [XmlElement("Object")]
        public string Object { get; set; }
    }
}
