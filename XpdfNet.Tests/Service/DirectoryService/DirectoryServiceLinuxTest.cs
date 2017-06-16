namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using Xunit;
    using XpdfNet;

    public class DirectoryServiceLinuxTest
    {
        private IDirectoryService DirectoryService;

        public DirectoryServiceLinuxTest()
        {
            this.DirectoryService = new DirectoryServiceLinux();
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotext_WhenItIsLinux()
        {
            // Arrange

            // Act
            string actual = this.DirectoryService.Filename;

            // Assert
            string expected = "sudo";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetArguments_ShouldReturnPdftotextAndArguments()
        {
            // Arrange
            XpdfParameter parameter = new XpdfParameter
            {
                Encoding = "-enc UTF-8",
                PdfFilename = "1.pdf",
                OutputFilename = "1.txt"
            };

            // Act
            string actual = this.DirectoryService.GetArguments(parameter);

            // Assert
            string expected = "pdftotext -enc UTF-8 \"1.pdf\" \"1.txt\"";
            Assert.Equal(expected, actual);
        }
    }
}
