namespace XpdfNet.Tests
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using Xunit;

    public class XpdfHelperTest
    {
        private XpdfHelper XpdfHelper;

        public XpdfHelperTest()
        {
            this.XpdfHelper = new XpdfHelper();
        }

        [Fact]
        public void ToText_ShouldReturnText()
        {
            // Arrange

            // Act
            string actual = this.XpdfHelper.ToText("./sample1.pdf");
            actual = RemoveWhiteSpace(actual);

            // Assert
            string workingDirectory;

#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif

            string expected = File.ReadAllText(Path.Combine(workingDirectory, "Expected.txt"));
            expected = RemoveWhiteSpace(expected);

            Assert.Equal(expected, actual);
        }

        private string RemoveWhiteSpace(string input)
        {
            input = input.Replace("\f", "");
            input = Regex.Replace(input, @"\r\n?|\n", string.Empty);
            input = Regex.Replace(input, @"\s+", "");

            return input;
        }
    }
}
