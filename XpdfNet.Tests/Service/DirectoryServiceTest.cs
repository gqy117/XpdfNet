namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using Xunit;
    using XpdfNet;

    public class DirectoryServiceTest
    {
        private DirectoryService DirectoryService;
        private Mock<IRuntimeInformation> MockRuntimeInformation;

        public DirectoryServiceTest()
        {
            this.MockRuntimeInformation = new Mock<IRuntimeInformation>();
            this.DirectoryService = new DirectoryService(this.MockRuntimeInformation.Object);
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotext_WhenItIsLinux()
        {
            // Arrange
            this.MockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Linux);

            // Act
            string actual = this.DirectoryService.GetPDFToTextExeFilename();

            // Assert
            string expected = "pdftotext";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldThrowAnException_WhenItIsOSX()
        {
            // Arrange
            this.MockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.OSX);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => this.DirectoryService.GetPDFToTextExeFilename());

            // Assert
            string expected = "XpdfNet currently only supports Unit and Windows OS.";
            Assert.Equal(expected, ex.Message);

        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotextExe_WhenItIsWindows()
        {
            // Arrange
            this.MockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Windows);

            // Act
            string actual = this.DirectoryService.GetPDFToTextExeFilename();

            // Assert
            string expected = "pdftotext.exe";
            Assert.Equal(expected, actual);
        }
    }
}
