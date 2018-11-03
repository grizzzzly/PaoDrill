using PaoDrill.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoDrill
{
    class Program
    {
        static void Main(string[] args)
        {
            //var repository = new DummyPaosRepository();
            var repository = new XmlPaosRepository(AppDomain.CurrentDomain.BaseDirectory + "/DataForDrill/PaosList.xml");
            var paoService = new PaoService(repository);
            int requestedNumberOfQuestions;
            int remainingNumberOfQuestions;
            var paos = new List<Pao>();
            List<string> propertyTypesToTest;

            Console.WriteLine("How many questions do you want? (default is as many questions as you want!)");
            if (!(int.TryParse(Console.ReadLine(), out requestedNumberOfQuestions)))
            {
                Console.WriteLine("Default defined: as many as you want!");
                requestedNumberOfQuestions = 10000;
            }

            Console.WriteLine("Which information do you want I give you?");
            DisplayAvailableChoices("");

            string givenPropertyType;
            var givenInformationChoice = Console.ReadKey().Key.ToString();
            Console.WriteLine();
            givenPropertyType = paoService.GetPropertyTypeFromFirstLetter(givenInformationChoice);

            Console.WriteLine("Do you want to be questioned on all the different properties (default, [y]) or only one [n]?");
            var questionOnAllProperties = Console.ReadKey().Key.ToString();
            if (String.Compare(questionOnAllProperties, "n", true) == 0)
            {
                Console.WriteLine("Which information do you want to give?");
                DisplayAvailableChoices(givenInformationChoice);
                var informationToGiveChoice = Console.ReadKey().Key.ToString();
                Console.WriteLine();
                propertyTypesToTest = new List<string> { paoService.GetPropertyTypeFromFirstLetter(informationToGiveChoice) };
            }
            else
            {
                propertyTypesToTest = paoService.GetListOfPropertyTypesToAsk(givenPropertyType);
            }

            string answer = givenInformationChoice;
            int totalQuestions = 0;
            int goodAnswers = 0;
            int partialGoodAnswers;

            remainingNumberOfQuestions = requestedNumberOfQuestions;
            while (remainingNumberOfQuestions > 0)
            {
                totalQuestions++;
                remainingNumberOfQuestions--;
                partialGoodAnswers = 0;

                Pao randomPao = paoService.GetRandomPao();
                foreach (string propertyType in propertyTypesToTest)
                {
                    Console.WriteLine($"{totalQuestions}) What is the {propertyType.ToLower()} for the {givenPropertyType.ToLower()} \"{paoService.GetPropertyFromPropertyType(givenPropertyType, randomPao)}\"?");
                    answer = Console.ReadLine();
                    if (String.Compare(answer, "x", true) == 0)
                    {
                        remainingNumberOfQuestions = 0;
                        break;
                    }
                    else
                    {
                        if (paoService.IsPropertyPartOfPao(answer, propertyType, randomPao))
                        {
                            Console.WriteLine("Bravo!");
                            partialGoodAnswers++;
                        }
                        else
                        {
                            Console.WriteLine($"The wright answer was \"{paoService.GetPropertyFromPropertyType(propertyType, randomPao)}\".");
                        }
                    }
                }
                if (partialGoodAnswers == propertyTypesToTest.Count)
                {
                    goodAnswers++;
                }
                Console.WriteLine();
            }

            if (String.Compare(answer, "x", true) == 0)
            {
                totalQuestions--;
            }
            Console.WriteLine();
            Console.WriteLine();
            if (goodAnswers == totalQuestions)
            {
                Console.WriteLine("Super! No error!");
            }
            Console.WriteLine($"{goodAnswers} good complete answer{(goodAnswers > 1 ? "s" : "")} out of {totalQuestions} question{(totalQuestions > 1 ? "s" : "")} (or group of questions).");
            Console.Read();
        }

        static void DisplayAvailableChoices(string optionToRemove)
        {
            if (String.Compare(optionToRemove, "n", true) != 0)
                Console.WriteLine("- number [n]");
            if (String.Compare(optionToRemove, "p", true) != 0)
                Console.WriteLine("- person [p]");
            if (String.Compare(optionToRemove, "a", true) != 0)
                Console.WriteLine("- action [a]");
            if (String.Compare(optionToRemove, "o", true) != 0)
                Console.WriteLine("- object [o]");
            Console.WriteLine("\"x\" to exit.");
        }
    }
}
