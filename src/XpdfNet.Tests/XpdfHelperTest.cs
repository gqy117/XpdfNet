namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    using Xunit;

    public class XpdfHelperTest
    {
        private readonly XpdfHelper xpdfHelper;
        private XpdfHelper xpdfHelper2;

        public XpdfHelperTest()
        {
            this.xpdfHelper = new XpdfHelper();
            List<string> eArg = new List<string>();
            eArg.Add("-paperw 80");
            this.xpdfHelper2 = new XpdfHelper(eArg);
        }

        [Fact]
        public void XpdfHelperTest_withExtraArguments()
        {
            Assert.True(this.xpdfHelper2 != null);
        }

        [Fact]
        public void ToText_ShouldReturnText()
        {
            // Arrange
            List<string> eArg = new List<string>();
            eArg.Add("-paperw 80");
            this.xpdfHelper2 = new XpdfHelper(eArg);

            // Act
            string actual = this.xpdfHelper.ToText("sample1.pdf");
            string actualExtraArgs = this.xpdfHelper2.ToText("sample1.pdf");
            actual = RemoveWhiteSpace(actual);
            actualExtraArgs = RemoveWhiteSpace(actualExtraArgs);

            // Assert
            string workingDirectory;

#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif

            string expected = File.ReadAllText(Path.Combine(workingDirectory, "Expected.txt"));
            string expectedargs = File.ReadAllText(Path.Combine(workingDirectory, "ExpectedArg.txt"));
            expected = RemoveWhiteSpace(expected);

            Assert.Equal(expected, actual);
            Assert.Equal(expected, actualExtraArgs);
        }

        [Fact]
        public void ToPS_ShouldReturnText()
        {
            // Arrange
            // Act
            string actual = this.xpdfHelper.ToPS("sample1.pdf");
            string actualExtraArgs = this.xpdfHelper2.ToPS("sample1.pdf");
            actual = RemoveWhiteSpace(actual);
            actualExtraArgs = RemoveWhiteSpace(actualExtraArgs);

            // Assert
            string workingDirectory;

#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif

            string expected_ps = File.ReadAllText(Path.Combine(workingDirectory, "Expected.ps"));
            string expected_ps_args = File.ReadAllText(Path.Combine(workingDirectory, "ExpectedArg.ps"));
            expected_ps = RemoveWhiteSpace(expected_ps);
            expected_ps_args = RemoveWhiteSpace(expected_ps_args);
            Assert.Equal(expected_ps, actual);
            Assert.Equal(expected_ps_args, actualExtraArgs);
        }

        private static string RemoveWhiteSpace(string input)
        {
            var result = Regex.Replace(input, @"\s+", string.Empty);

            return result;
        }
    }
}
