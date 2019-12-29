using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DumpSharp.Tests
{
    #region testClasses

    enum ETest : byte
    {
        Test1 = 0,
        Test2 = 1,
    }

    #endregion

    [TestClass]
    public class DumpSharpBasicTests
    {

        [TestMethod]
        public void Dump_ValueTypes_ValueGetsReturned()
        {
            int i = 17;
            char c = 'x';
            double d = 17.17;

            Assert.AreEqual("17", i.ToDumpString());
            Assert.AreEqual("x", c.ToDumpString());
            Assert.AreEqual("17.17", d.ToDumpString());
        }

        [TestMethod]
        public void Dump_Null_NullGetsReturned()
        {
            object o = null;
            Assert.AreEqual("NULL", o.ToDumpString());
        }

        [TestMethod]
        public void Dump_Enum_ValuesGetReturned()
        {
            ETest t1 = ETest.Test1;
            ETest t2 = ETest.Test2;

            Assert.AreEqual("ETest.Test1", t1.ToDumpString());
            Assert.AreEqual("ETest.Test2", t2.ToDumpString());
        }

        [TestMethod]
        public void Dump_Nullable_NullOrValueGetsReturned()
        {
            int? i1 = 1;
            int? i2 = null;
            ETest? t1 = ETest.Test1;

            Assert.AreEqual("1", i1.ToDumpString());
            Assert.AreEqual("NULL", i2.ToDumpString());
            Assert.AreEqual("ETest.Test1", t1.ToDumpString());
        }

        [TestMethod]
        public void Dump_SpecialStructs_CorrectValueGetsReturned()
        {
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(1, 1);
            Assert.AreEqual("[1, 1]", kvp.ToDumpString());
        }

        [TestMethod]
        public void Dump_IEnumberable_CorrectValueGetReturned()
        {
            int[] arr = new int[3];
            arr[0] = 0;
            arr[2] = 2;

            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("[0] = 0");
            sb1.AppendLine("[1] = 0");
            sb1.Append("[2] = 2");

            List<int> l = new List<int>()
            {
                1, 2, 3, 4
            };

            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine("[0] = 1");
            sb2.AppendLine("[1] = 2");
            sb2.AppendLine("[2] = 3");
            sb2.Append("[3] = 4");

            Dictionary<int, int> dict = new Dictionary<int, int>()
            {
                {1, 1 },
                {2, 2 }
            };

            StringBuilder sb3 = new StringBuilder();
            sb3.AppendLine("[0] = [1, 1]");
            sb3.Append("[1] = [2, 2]");

            Assert.AreEqual(sb1.ToString(), arr.ToDumpString());
            Assert.AreEqual(sb2.ToString(), l.ToDumpString());
            Assert.AreEqual(sb3.ToString(), dict.ToDumpString());
        }
    }
}
