namespace XpdfNet.Tests
{
    using System;
    using System.IO;
    using XpdfNet;
    using Xunit;

    public class DirectoryServiceWindowsTest
    {
        private readonly IDirectoryService directoryService;

        public DirectoryServiceWindowsTest()
        {
            this.directoryService = new DirectoryServiceWindows();
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotextExe_WhenItIsWindows()
        {
            // Arrange

            // Act
            string actual = this.directoryService.Filename;
            string actual2 = this.directoryService.PDFToTextFilename;

            // Assert
            string expected = Path.Combine(this.directoryService.WorkingDirectory, "pdftotext.exe");
            Assert.Equal(expected, actual);
            Assert.Equal(expected, actual2);
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftoPsExe_WhenItIsWindows()
        {
            // Arrange

            // Act
            string actual = this.directoryService.PDFToPSFilename;

            // Assert
            string expected = Path.Combine(this.directoryService.WorkingDirectory, "pdftops.exe");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetArguments_ShouldReturnString()
        {
            // Arrange
            XpdfParameter par = new XpdfParameter()
            {
                OutputFilename = "b.ps",
                PdfFilename = "b.pdf",
                PDFLevel = "-level3"
            };

            // Act
            string actual = this.directoryService.GetArguments(par);
            string actual2 = this.directoryService.GetArgumentsToText(par);
            string actual3 = this.directoryService.GetArgumentsToPS(par);

            // Assert
            string expected = "-level3 \"b.pdf\" \"b.ps\"";
            Assert.Equal(expected, actual);
            Assert.Equal(expected, actual2);
            Assert.Equal(expected, actual3);
        }
    }
}
