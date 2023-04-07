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
        // Useful info if attribute is used in an element: https://stackoverflow.com/questions/14245846/deserializing-xml-file-with-multiple-element-attributes-attributes-are-not-des
        // The hierarchy of the objects should be adapted.
        public Pao (string number, string person, string action, string obj, string personComment, string actionComment, string objectComment)
        {
            Number = number;
            Person = person;
            Action = action;
            Object = obj;
            PersonComment = personComment;
            ActionComment = actionComment;
            ObjectComment = objectComment;
        }

        [XmlElement("Number")]
        public string Number { get; set; }

        [XmlElement("Person")]
        public string Person { get; set; }

        [XmlElement("Action")]
        public string Action { get; set; }

        [XmlElement("Object")]
        public string Object { get; set; }

        [XmlElement("PersonComment")]
        public string PersonComment { get; set; }

        [XmlElement("ActionComment")]
        public string ActionComment { get; set; }

        [XmlElement("ObjectComment")]
        public string ObjectComment { get; set; }
    }
}
