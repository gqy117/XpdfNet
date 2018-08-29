namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using XpdfNet;
    using Xunit;

    public class DirectoryServiceLinuxTest
    {
        private readonly IDirectoryService directoryService;

        public DirectoryServiceLinuxTest()
        {
            this.directoryService = new DirectoryServiceLinux();
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotext_WhenItIsLinux()
        {
            // Arrange

            // Act
            string actual = this.directoryService.Filename;
            string actual2 = this.directoryService.PDFToPSFilename;
            string actual3 = this.directoryService.PDFToTextFilename;

            // Assert
            string expected = "/bin/bash";
            Assert.Equal(expected, actual);
            Assert.Equal(expected, actual2);
            Assert.Equal(expected, actual3);
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
            string actual = this.directoryService.GetArgumentsToText(parameter);
            string actual2 = this.directoryService.GetArguments(parameter);

            // Assert
            string expected = "-c \"chmod +x ./pdftotext; ./pdftotext -enc UTF-8 \"1.pdf\" \"1.txt\"\"";

            Assert.Equal(expected, actual);
            Assert.Equal(expected, actual2);
        }

        [Fact]
        public void GetArguments_ShouldReturnPdftopsAndArguments()
        {
            // Arrange
            XpdfParameter parameter = new XpdfParameter
            {
                PDFLevel = "-level3",
                PdfFilename = "1.pdf",
                OutputFilename = "1.txt"
            };

            // Act
            string actual = this.directoryService.GetArgumentsToPS(parameter);

            // Assert
            string expected = "-c \"chmod +x ./pdftops; ./pdftops -level3 \"1.pdf\" \"1.txt\"\"";
            Assert.Equal(expected, actual);
        }
    }
}
