using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Examples
{
    class Shorten
    {

        #region C#7 Tuples and discards

        private City GetData() => new City()
        {
            Name = "Graz",
            ZipCode = 8020
        };

        private void DoSthWithCityData()
        {
            var city = GetData();
            if (city.Name == "Graz")
            {
                //tell everybody that this city is cool
            }
        }
        #endregion

        #region Switch Expressions

        int FindIndex(AppLovSystemFlagsEnum selectionType, List<string> items)
        {
            int index = -1;
            switch (selectionType)
            {
                case AppLovSystemFlagsEnum.MultipleRevs:
                    index = items.IndexOf("Multiple Revision");
                    break;
                case AppLovSystemFlagsEnum.LatestRev:
                    index = items.IndexOf("Use latest revision of selected variant");
                    break;
                case AppLovSystemFlagsEnum.Latest2Rev:
                    index = items.IndexOf("Use latest and previous revision of selected variant");
                    break;
                case AppLovSystemFlagsEnum.SingleRevision:
                    index = items.IndexOf("Single Revision");
                    break;
            }
            return index.Process();
        }

        #endregion

        #region Property Patterns

        static string DecribeNeighbourhood(City city)
        {
            if (city.Name == "Graz")
            {
                if (city.ZipCode == 8010)
                    return "Fancy";

                return "It's Graz, it must be nice";
            }
            else if (city.Name == "Wien")
            {
                return "Nice, as long as it's not windy";
            }

            return "Neither in Graz nor in Wien, so it can't be that nice";
        }

        #endregion

        #region Tuple Patterns

        static string DecribeNeighbourhood(string name, int zipCode, int someOtherFactor)
        {
            if (name == "Graz")
            {
                if (zipCode == 8010) return "Fancy";

                return "It's Graz, it must be nice";
            }

            if (name == "Wien") return "Nice, as long as it's not windy";

            if (someOtherFactor == 42) return "This is the answer to everything";

            return "Neither in Graz nor in Wien, so it can't be that nice";
        }

        #endregion

        #region Positional Patterns

        public string GetMessage(AuthData auth)
        {
            var expiryDate = auth.ExpiryDate.ToOADate();
            var now = DateTime.Now.ToOADate();

            if (auth.LoggedIn)
            {
                if (expiryDate <= now + 28)
                    return "Your account will expire within next 4 weeks";

                return "OK";
            }

            if (expiryDate < now)
                return "Your account has expired";

            return "Unavailable";
        }

        #endregion

        #region Null coallescing assignment

        public void AddStringToList(List<string> list, string stringToAdd)
        {
            if (list == null)
                list = new List<string>();
            list.Add(stringToAdd ?? string.Empty);
        }

        #endregion

        #region Index

        static string LastWord(string[] words) => words[words.Length - 1];

        static string SecondLastWord(string[] words) => words[words.Length - 2];

        #endregion

        #region Range
        static string ConcatFirstThree(string[] words) => String.Join("", words[0], words[1], words[2]);

        static string ConcatAllButFirst5(string[] words) => String.Join("", words.Skip(5));

        static string ConcatLastTwo(string[] words) => String.Join("", words[words.Length - 2], words[words.Length - 1]);


        #endregion

    }
}