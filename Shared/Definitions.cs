using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public enum AppLovSystemFlagsEnum
    {
        IsAdmin = 1,
        MultipleRevs = 2,
        LatestRev = 4,
        Latest2Rev = 8,
        SingleRevision = 16,
        SingleNode = 32
    }

    public class City
    {
        public string Name { get; set; }
        public int ZipCode { get; set; }

        //available starting C#7
        public void Deconstruct(out string name, out int zipCode) => (name, zipCode) = (Name, ZipCode);
    }
}
