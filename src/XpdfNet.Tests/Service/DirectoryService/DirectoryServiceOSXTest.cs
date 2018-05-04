namespace XpdfNet.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using Moq;
    using XpdfNet;
    using Xunit;

    public class DirectoryServiceOSXTest
    {
        private IDirectoryService directoryService;

        public DirectoryServiceOSXTest()
        {
            this.directoryService = new DirectoryServiceOSX();
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotext_WhenItIsLinux()
        {
            // Arrange

            // Act
            string actual = this.directoryService.Filename;

            // Assert
            string expected = "/bin/bash";
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
            string actual = this.directoryService.GetArguments(parameter);

            // Assert
            string expected = "-c \"chmod +x ./pdftotext; ./pdftotext -enc UTF-8 \"1.pdf\" \"1.txt\"\"";
            Assert.Equal(expected, actual);
        }
    }
}
