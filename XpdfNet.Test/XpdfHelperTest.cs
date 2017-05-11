using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Text.RegularExpressions;

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
            actual = Regex.Replace(actual, @"\r\n?|\n", string.Empty);

            // Assert
            string expected = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Expected.txt"));
            expected = Regex.Replace(expected, @"\r\n?|\n", string.Empty);

            Assert.Equal(expected, actual);
        }
    }
}
