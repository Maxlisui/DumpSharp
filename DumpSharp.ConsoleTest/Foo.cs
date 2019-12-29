using System;
using System.Collections.Generic;
using System.Text;

namespace DumpSharp.ConsoleTest
{
    public class Foo
    {
        #region properties

        public int Property { get; set; }
        public string String { get; set; }
        public List<int> List { get; set; }
        public int Readonly 
        {
            get
            {
                return 1;
            }
        }
        public Bar Bar { get; set; }

        #endregion
    }
}
