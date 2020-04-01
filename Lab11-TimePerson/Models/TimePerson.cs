using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace Lab11_TimePerson.Models
{
    public class TimePerson
    {  
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        public TimePerson(int year, string honor, string name, string country, int birthyear, int deathyear, string title, string category, string context)
        {
            Year = year;
            Honor = honor;
            Name = name;
            Country = country;
            BirthYear = birthyear;
            DeathYear = deathyear;
            Title = title;
            Category = category;
            Context = context;
        }

        public static List<TimePerson> GetPersons(int startyear, int endYear)
        {


            // create a list of Time persons (instantiate a new list)
            List<TimePerson> list = new List<TimePerson>();

            // get the path of your timeperson.csv file
            // getting the path is not as simple as ../../../ have to use 
            // the Path or Environment class
            var path = @"../Lab11-TimePerson/wwwroot/personOfTheYear.csv";

            // once you get the file path, 
            // read all the lines and save it into an array of strings
            string[] allNames = File.ReadAllLines(path);

            // traverse through the strings for each line item
            // remember CSV is delimited by commas.

            string[] Header = allNames[0].Split(',');

            for (int i = 1; i < allNames.Length; i++)
            {
                string[] splitName = allNames[i].Split(',');

                TimePerson person = new TimePerson(
                    splitName[0] == "" ? 0 : Convert.ToInt32(splitName[0]),
                    splitName[1],
                    splitName[2],
                    splitName[3],
                    splitName[4] == "" ? 0 : Convert.ToInt32(splitName[4]),
                    splitName[5] == "" ? 0 : Convert.ToInt32(splitName[5]),
                    splitName[6],
                    splitName[7],
                    splitName[8]
                    );
                list.Add(person);

            }

            // use LINQ to filter out with the years that you brought in against your list of persons
     
            List<TimePerson> query2 = list.Where(x => x.Year >= startyear && x.Year <= endYear).ToList();


            //return your list of persons
            return query2;

        }
    }
}


