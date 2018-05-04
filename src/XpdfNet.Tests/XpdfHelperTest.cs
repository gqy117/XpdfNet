namespace XpdfNet.Tests
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    using Xunit;

    public class XpdfHelperTest
    {
        private XpdfHelper xpdfHelper;

        public XpdfHelperTest()
        {
            this.xpdfHelper = new XpdfHelper();
        }

        [Fact]
        public void ToText_ShouldReturnText()
        {
            // Arrange

            // Act
            string actual = this.xpdfHelper.ToText("sample1.pdf");
            actual = this.RemoveWhiteSpace(actual);

            // Assert
            string workingDirectory;

#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif

            string expected = File.ReadAllText(Path.Combine(workingDirectory, "Expected.txt"));
            expected = this.RemoveWhiteSpace(expected);

            Assert.Equal(expected, actual);
        }

        private string RemoveWhiteSpace(string input)
        {
            input = Regex.Replace(input, @"\s+", string.Empty);

            return input;
        }
    }
}
