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
        /*
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

            // Assert
            string expected = "/bin/bash";
            Assert.Equal(expected, actual);
        }

        /*
        [Fact]
        public void GetArguments_ShouldReturnPdftotextAndArguments()
        {
            // Arrange
            XpdfParameter parameter = new XpdfParameter
            {
                Encoding = "-enc UTF-8",
                PdfFilename = "1.pdf",
                OutputFilename = "1.txt",
            };

            // Act
            string actual = this.directoryService.GetArguments(parameter);

            // Assert
            string expected = "-c \"chmod +x ./pdftotext; ./pdftotext -enc UTF-8 \"1.pdf\" \"1.txt\"\"";
            Assert.Equal(expected, actual);
        }
        */
    }
}
