using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace XpdfNet.Test
{
    [TestFixture]
    public class XpdfHelperTest
    {
        [Test]
        public void ToText_ShouldReturnText()
        {
            // Arrange
            XpdfHelper xpdfHelper = new XpdfHelper();

            // Act
            string actual = xpdfHelper.ToText("./sample1.pdf");
            actual = actual.Replace("\f", "");

            // Assert
            string expected = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Expected.txt"));
            Assert.AreEqual(expected, actual);
        }
    }
}
