namespace XpdfNet.Tests
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    using Xunit;

    public class XpdfHelperTest
    {
        private readonly XpdfHelper xpdfHelper;

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

        [Fact]
        public void ToPS_ShouldReturnText()
        {
            // Arrange
            // Act
            string actual = this.xpdfHelper.ToPS("sample1.pdf");
            actual = RemoveWhiteSpace(actual);

            // Assert
            string workingDirectory;

#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif

            string expected_pos = File.ReadAllText(Path.Combine(workingDirectory, "Expected.ps"));
            expected_pos = RemoveWhiteSpace(expected_pos);
            Assert.Equal(expected_pos, actual);
        }

        private static string RemoveWhiteSpace(string input)
        {
            var result = Regex.Replace(input, @"\s+", string.Empty);

            return result;
        }
    }
}
