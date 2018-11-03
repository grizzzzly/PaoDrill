using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoDrill
{
    public interface IPaoService
    {
        Pao GetRandomPao();
        bool IsPropertyPartOfPao(string property, string propertyType, Pao pao);

        List<string> GetListOfPropertyTypesToAsk(string propertyType);

        string GetPropertyFromPropertyType(string propertyType, Pao pao);

        string GetPropertyTypeFromFirstLetter(string choice);
    }
}
