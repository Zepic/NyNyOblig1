using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig6
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;


        public string GetDescription()
        {
            string returnInfo = "";

            if (FirstName != null)
                returnInfo += FirstName + " ";

            if (LastName != null)
                returnInfo += LastName + " ";

            if (Id != 0)
                returnInfo += "(Id=" + Id + ")";

            if (BirthYear != 0)
                returnInfo += " Født: " + BirthYear;

            if (DeathYear != 0)
                returnInfo += " Død: " + DeathYear;


            if (Father != null)
            {
                returnInfo += " Far:";
                if (Father.FirstName != null)
                    returnInfo += " " + Father.FirstName;

                returnInfo += " (Id=" + Father.Id + ")";


            }

            if (Mother != null)
            {
                returnInfo += " Mor:";
                if (Mother.FirstName != null)
                    returnInfo += " " + Mother.FirstName;

                returnInfo += " (Id=" + Mother.Id + ")";
            }
            return returnInfo;
        }

        public string GetChild()
        {
            List<string> list = new List<string>();
            if (FirstName != null)
            {
                list.Add(FirstName);
            }

            if (Id != 0)
            {
                list.Add($"(Id={Id})");
            }
            if (BirthYear != 0) list.Add($"Født: {BirthYear}");
            return "    " + string.Join(" ", list);
        }
    }
}
