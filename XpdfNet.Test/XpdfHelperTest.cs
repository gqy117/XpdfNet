using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XpdfNet.Test
{
    public class XpdfHelperTest
    {
        [Fact]
        public void ToText_ShouldReturnText()
        {
            // Arrange
            XpdfHelper xpdfHelper = new XpdfHelper();

            // Act
            string actual = xpdfHelper.ToText("./sample1.pdf");
            actual = actual.Replace("\f", "");

            // Assert
            string expected = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Expected.txt"));
            Assert.Equal(expected, actual);
        }
    }
}
