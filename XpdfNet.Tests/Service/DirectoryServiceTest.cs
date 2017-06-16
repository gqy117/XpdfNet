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
        private DirectoryServiceBase _directoryServiceBase;
        private Mock<IRuntimeInformation> MockRuntimeInformation;

        public DirectoryServiceTest()
        {
            this.MockRuntimeInformation = new Mock<IRuntimeInformation>();
            this._directoryServiceBase = new DirectoryServiceBase(this.MockRuntimeInformation.Object);
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotext_WhenItIsLinux()
        {
            // Arrange
            this.MockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Linux);

            // Act
            string actual = this._directoryServiceBase.Filename;

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
            Exception ex = Assert.Throws<ArgumentException>(() => this._directoryServiceBase.Filename);

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
            string actual = this._directoryServiceBase.Filename;

            // Assert
            string expected = "pdftotext.exe";
            Assert.Equal(expected, actual);
        }
    }
}
