using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PaoDrill.Repositories
{
    public class XmlPaosRepository : IPaosRepository
    {
        private string _xmlPath;
        public XmlPaosRepository(string xmlPath)
        {
            _xmlPath = xmlPath;
        }
        public List<Pao> GetAllPaos()
        {
            var paosList = new PaosList();
            XmlSerializer serializer = new XmlSerializer(typeof(PaosList));

            using (var loadStream = new FileStream(_xmlPath, FileMode.Open, FileAccess.Read))
            {
                paosList = (PaosList)serializer.Deserialize(loadStream);
                loadStream.Close();
            }
            return paosList.Paos;
        }
    }
}
