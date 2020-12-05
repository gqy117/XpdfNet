namespace Xpdf.Wrapper.Tests
{
    using System;
    using System.IO;
    using Xunit;
    using Wrapper;

    public class XpdfHelperTest
    {
        [Fact]
        public void ToText_ShouldReturnText()
        {
            // Arrange
            string workingDirectory;

#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif
            string expected = File.ReadAllText(Path.Combine(workingDirectory, "NoParams.txt"));

            // Act
            string actual = Xpdf.PdfToText("sample1.pdf");

            // Assert

            Assert.Equal(expected, actual);
        }
    }
}
