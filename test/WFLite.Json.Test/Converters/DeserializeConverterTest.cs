using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFLite.Json.Converters;

namespace WFLite.Json.Test.Converters
{
    [TestClass]
    public class DeserializeConverterTest
    {
        [TestMethod]
        public void Test___Method_Convert___Object()
        {
            var testee = new DeserializeConverter();

            dynamic obj = testee.Convert("{\"a\":10,\"b\":20}");

            Assert.AreEqual(10, Convert.ToInt32(obj["a"]));
            Assert.AreEqual(20, Convert.ToInt32(obj["b"]));
        }

        [TestMethod]
        public void Test___Method_Convert___Dictionary()
        {
            var testee = new DeserializeConverter<Dictionary<string, int>>();

            var value = testee.Convert("{\"a\":10,\"b\":20}");

            Assert.AreEqual(10, value["a"]);
            Assert.AreEqual(20, value["b"]);
        }

        [TestMethod]
        public void Test___Method_Convert___Array()
        {
            var testee = new DeserializeConverter<List<int>>();

            var value = testee.Convert("[10,20]");

            Assert.AreEqual(10, value[0]);
            Assert.AreEqual(20, value[1]);
        }
    }
}
