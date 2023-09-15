using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit;
using FirstTestProAug14th;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProAug14th
{
    [TestFixture]
    internal class UnitTestingAug14th
    {
        [Test]
        public void Adding_Isvalue_Correct()
        {//arrange
            Calculate m = new Calculate();
            //act 
            double res = m.Add(101, 202);
            //assert
            Assert.AreEqual(res, 202);
            // x negative, y negative, both negative 3
            //  4 test cases 

        }
    }
}
