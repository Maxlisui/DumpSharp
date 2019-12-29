using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DumpSharp.Tests
{
    #region test class

    class Foo
    {
        public int Int { get; set; }
        public string String { get; set; }
        public List<int> List { get; set; }
    }

    #endregion

    [TestClass]
    public class DumpSharpExtendedTests
    {
        [TestMethod]
        public void Dump_Class_ReturnsPropertiesAndValues()
        {
            Foo f = new Foo
            {
                Int = 1,
                String = "Test",
                List = null
            };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Foo.Int = 1");
            sb.AppendLine("Foo.String = Test");
            sb.Append("Foo.List = NULL");

            Assert.AreEqual(sb.ToString(), f.ToDumpString());
        }

        [TestMethod]
        public void Dump_ClassWithList_ReturnsListCorrectly()
        {
            Foo f = new Foo
            {
                Int = 1,
                String = "Test",
                List = new List<int>
                {
                    1, 2, 3
                }
            };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Foo.Int = 1");
            sb.AppendLine("Foo.String = Test");
            sb.AppendLine("Foo.List[0] = 1");
            sb.AppendLine("Foo.List[1] = 2");
            sb.Append("Foo.List[2] = 3");

            Assert.AreEqual(sb.ToString(), f.ToDumpString());
        }
    }
}
