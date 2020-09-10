using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig6
{
    public class FamilyApp
    {
        public List<Person> _people;
        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
        }
        
        public string FindPerson(string number)
        {
            int id = int.Parse(number);
            var child = new StringBuilder();
            var foundPerson =_people[id - 1].GetDescription();

            foreach (var person in _people)
            {
                if (person.Mother != null && person.Mother.Id == id || person.Father != null && person.Father.Id == id)
                {
                    child.Append(person.GetChild() + "\n");
                }
            }
            string hasChild = child.Length > 0 ? "\n  Barn:\n" : "";
            return foundPerson + hasChild + child;
        }

        static string helpMessage = "hjelp => viser en hjelpetekst som forklarer alle kommandoene\r\nliste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. \r\nvis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)";
        public string WelcomeMessage { get; } = helpMessage;
        public string CommandPrompt { get; } = ":";


        public string HandleCommand(string command)
        {
            if (command.StartsWith("vis "))
            {
                return FindPerson(command.Substring(4));
            }
            if (command == "hjelp")
            {
                return helpMessage;
            }

            if (command == "liste")
            {
                string x = null;
                foreach (var person in _people)
                {
                    x += person.GetDescription() + "\n";
                }
                return x;
            }
            
            return "Invalid Command";
        }
    }
}
