using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstTestProAug14th;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProAug14th
{
    [TestClass]
    public class TestCalculate
    {
        [TestMethod]
        public void CalculateAll()
        {
            //Arrange
            Calculate cl = new Calculate();
            //Act
            double re = cl.Add(101, 202);
            //Assert
            Assert.AreEqual(re, 303);
        }
    }
}
