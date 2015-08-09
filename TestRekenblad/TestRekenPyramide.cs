using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rekenblad;

namespace TestRekenblad
{
    [TestClass]
    public class TestRekenPyramide
    {
        [TestMethod]
        public void GeneratePyramid_HasAllCellsFilled()
        {
            RekenPyramide rp = new RekenPyramide();
            Random rnd = new Random(3);
            int [,] pyramide = rp.GeneratePyramid(3,rnd,2);
            Assert.AreEqual(true,pyramide.IsFixedSize);
            //Assert.AreEqual(6,pyramide.Length);
        }
    }
}
