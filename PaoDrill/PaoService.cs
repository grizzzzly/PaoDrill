using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoDrill
{
    public class PaoService : IPaoService
    {
        private List<Pao> _paosList;
        private Random _randomNumber;
        public PaoService(IPaosRepository paosRepository)
        {
            _paosList = paosRepository.GetAllPaos();
            _randomNumber = new Random();
        }

        public List<string> GetListOfPropertyTypesToAsk(string propertyType)
        {
            switch (propertyType)
            {
                case nameof(Pao.Action):
                    return new List<string> { nameof(Pao.Number), nameof(Pao.Object), nameof(Pao.Person) };
                case nameof(Pao.Number):
                    return new List<string> { nameof(Pao.Action), nameof(Pao.Object), nameof(Pao.Person) };
                case nameof(Pao.Object):
                    return new List<string> { nameof(Pao.Action), nameof(Pao.Number), nameof(Pao.Person) };
                case nameof(Pao.Person):
                    return new List<string> { nameof(Pao.Action), nameof(Pao.Number), nameof(Pao.Object) };
                default:
                    return new List<string> { };
            }
        }

        public string GetPropertyFromPropertyType(string propertyType, Pao pao)
        {
            switch (propertyType)
            {
                case nameof(Pao.Action):
                    return pao.Action;
                case nameof(Pao.Number):
                    return pao.Number;
                case nameof(Pao.Object):
                    return pao.Object;
                case nameof(Pao.Person):
                    return pao.Person;
                default:
                    return String.Empty;
            }
        }

        public Pao GetRandomPao()
        {
            return _paosList[_randomNumber.Next(0, _paosList.Count)];
        }

        public string GetPropertyTypeFromFirstLetter(string choice)
        {
            string propertyType;
            switch (choice.ToUpper())
            {
                case "N":
                    propertyType = nameof(Pao.Number);
                    break;
                case "P":
                    propertyType = nameof(Pao.Person);
                    break;
                case "A":
                    propertyType = nameof(Pao.Action);
                    break;
                case "O":
                    propertyType = nameof(Pao.Object);
                    break;
                default:
                    propertyType = nameof(Pao.Number);
                    break;
            }
            return propertyType;
        }

        public bool IsPropertyPartOfPao(string property, string propertyType, Pao pao)
        {
            bool result = false;

            switch (propertyType)
            {
                case nameof(pao.Action):
                    if (String.Compare(pao.Action, property, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        result = true;
                    }
                    break;
                case nameof(pao.Number):
                    if (String.Compare(pao.Number, property, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        result = true;
                    }
                    break;
                case nameof(pao.Object):
                    if (String.Compare(pao.Object, property, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        result = true;
                    }
                    break;
                case nameof(pao.Person):
                    if (String.Compare(pao.Person, property, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        result = true;
                    }
                    break;
            }

            return result;
        }
    }
}
