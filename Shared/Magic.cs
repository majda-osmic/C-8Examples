using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Magic
    {
        public int PerformSome()
        {
            return 42;
        }

        public Data GetSomeData() => new Data();

    }

    public class Data { }

}
