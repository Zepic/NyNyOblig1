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
        //_people[2].GetDescription()
        //char id = (char) charId;
        //int intId = (char) charId;
        public string FindPerson(string number)
        {
            int id = int.Parse(number);
            var child = new StringBuilder();
            var foundPerson =_people[id].GetDescription();

            foreach (var person in _people)
            {
                if (person.Mother != null && person.Mother.Id == id || person.Father != null && person.Father.Id == id)
                {
                    child.Append(person.GetChild() + "\n");
                }
            }
            string hasChild = child.Length > 0 ? "\n  Barn:\n" : ""; //forkortet if settning
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
    //if (command == "vis 1")
    //{
    //    return _people[0].GetDescription() + FindChild(1);
    //}
    //if (command == "vis 2")
    //{
    //    return _people[1].GetDescription() + FindChild(2);
    //}
    //if (command == "vis 3")
    //{
    //    return _people[2].GetDescription() + FindChild(3);
    //}
    //if (command == "vis 4")
    //{
    //    return _people[3].GetDescription() + FindChild(4);
    //}
    //if (command == "vis 5")
    //{
    //    return _people[4].GetDescription() + FindChild(5);
    //}
    //if (command == "vis 6")
    //{
    //    return _people[5].GetDescription() + FindChild(6);
    //}
    //if (command == "vis 7")
    //{
    //    return _people[6].GetDescription() + FindChild(7);
    //}
    //if (command == "vis 8")
    //{
    //    return _people[7].GetDescription() + FindChild(8);
    //}
}
