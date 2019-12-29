using System;
using System.Collections.Generic;
using System.Text;

namespace DumpSharp.ConsoleTest
{
    public class Bar
    {
        #region properties

        public int Int { get; set; }
        public List<Bar> Bars { get; set; }

        #endregion
    }
}
