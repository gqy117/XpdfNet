namespace XpdfNet.Tests
{
    using System;
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

        private static string RemoveWhiteSpace(string input)
        {
            var result = Regex.Replace(input, @"\s+", string.Empty);

            return result;
        }
    }
}
