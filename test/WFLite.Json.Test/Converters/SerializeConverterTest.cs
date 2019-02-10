using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Json.Converters;

namespace WFLite.Json.Test.Converters
{
    [TestClass]
    public class SerializeConverterTest
    {
        [TestMethod]
        public void Test___Method_Convert___Object()
        {
            var testee = new SerializeConverter();

            Assert.AreEqual("{\"a\":10,\"b\":20}", testee.Convert(new Dictionary<string, int>()
            {
                { "a", 10 },
                { "b", 20 }
            }));
        }

        [TestMethod]
        public void Test___Method_Convert___Array()
        {
            var testee = new SerializeConverter();

            Assert.AreEqual("[10,20]", testee.Convert(new int[] { 10, 20 }));
        }
    }
}
