using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace CSharp8_Examples
{
    class Shorten
    {

        #region C#7 Tuples and discards


        private City GetData() => new City()
        {
            Name = "Graz",
            ZipCode = 8020
        };

        //this would also work with .NET Framework, but must import Tuple as Nuget Package
        private (string, int) CityNameAndZipCode()
        {
            //do some calc
            return ("Graz", 8020);
        }

        private void DoSthWithCityData()
        {
            (string cityName, int zipCode) = CityNameAndZipCode();
            if (cityName == "Graz")
            {
                //tell everybody that this city is cool
            }

            (cityName, _) = GetData(); //use discard for variables you don't care about
        }

        #endregion

        #region Switch Expressions

        int FindIndex(AppLovSystemFlagsEnum selectionType, List<string> items)
        {
            int index = selectionType switch
            {
                AppLovSystemFlagsEnum.MultipleRevs => items.IndexOf("Multiple Revision"),
                AppLovSystemFlagsEnum.LatestRev => items.IndexOf("Use latest revision of selected variant"),
                AppLovSystemFlagsEnum.Latest2Rev => items.IndexOf("Use latest and previous revision of selected variant"),
                AppLovSystemFlagsEnum.SingleRevision => items.IndexOf("Single Revision"),
                _ => -1
            };

            return index.Process();
        }

        private int FindIndexV2(AppLovSystemFlagsEnum selectionType, List<string> items) =>
            Extensions.Process(selectionType switch
            {
                AppLovSystemFlagsEnum.MultipleRevs => items.IndexOf("Multiple Revision"),
                AppLovSystemFlagsEnum.LatestRev => items.IndexOf("Use latest revision of selected variant"),
                AppLovSystemFlagsEnum.Latest2Rev => items.IndexOf("Use latest and previous revision of selected variant"),
                AppLovSystemFlagsEnum.SingleRevision => items.IndexOf("Single Revision"),
                _ => -1
            });
        #endregion

        #region Property Patterns

        static string DecribeNeighbourhood(City city) => city switch
        {
            { Name: "Graz", ZipCode: 8010 } => "Fancy",
            { Name: "Graz" } => "It's Graz, it must be nice",
            { Name: "Wien" } => "Nice, as long as it's not windy",
            _ => "Neither in Graz nor in Wien, so it can't be that nice"
        };

        #endregion

        #region Tuple Patterns

        static string DecribeNeighbourhood(string name, int zipCode, int someOtherFactor) =>
          (name, zipCode, someOtherFactor) switch
          {
              ("Graz", 8010, _) => "Fancy",
              ("Graz", _, _) => "It's Graz, it must be nice",
              ("Wien", _, _) => "Nice, as long as it's not windy",
              (_, _, 42) => "This is the answer to everything",
              _ => "Neither in Graz nor in Wien, so it can't be that nice"
          };

        #endregion

        #region Positional Patterns

        public string GetMessage(AuthData auth)
        {
            var now = DateTime.Now.ToOADate();
            return auth switch
            {
                var (isLoggedIn, expiryDate) when isLoggedIn && expiryDate < now + 28 => "Your account will expire within next 4 weeks",
                var (isLoggedIn, expiryDate) when !isLoggedIn && expiryDate < now  => "Your account has expired",
                (true, _) => "OK",
                _ => "Unavailable"
            };
        }



        #endregion

        #region Null coallescing assignment
        public void AddStringToList(List<string> list, string stringToAdd)
        {
            list ??= new List<string>();
            list.Add(stringToAdd ?? String.Empty);
        }

        #endregion

        #region Index

        static string LastWord(string[] words) => words[^1];

        static string SecondLastWord(string[] words) => words[^2];
        #endregion

        #region Range
        static string ConcatFirstThree(string[] words) => String.Join("", words[..2]);
        static string ConcatAllButFirst5(string[] words) => String.Join("", words[6..]);
        static string ConcatLastTwo(string[] words) => String.Join("", words[^2..^0]);

        #endregion

    }
}

