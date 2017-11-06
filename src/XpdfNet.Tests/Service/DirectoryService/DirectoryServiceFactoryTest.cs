namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using XpdfNet;
    using Xunit;

    public class DirectoryServiceFactoryTest
    {
        private DirectoryServiceFactory directoryServiceFactory;
        private Mock<IRuntimeInformation> mockRuntimeInformation;

        public DirectoryServiceFactoryTest()
        {
            this.mockRuntimeInformation = new Mock<IRuntimeInformation>();
            this.directoryServiceFactory = new DirectoryServiceFactory();
        }

        [Fact]
        public void GetDirectoryService_ShouldReturnDirectoryServiceLinux_WhenItIsLinux()
        {
            // Arrange
            this.mockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Linux);

            // Act
            var actual = this.directoryServiceFactory.GetDirectoryService(this.mockRuntimeInformation.Object);

            // Assert
            Assert.IsType<DirectoryServiceLinux>(actual);
        }

        [Theory]
        [InlineData(OS.OSX)]
        [InlineData(OS.Unsupported)]
        [InlineData(null)]
        public void GetPDFToTextExeFilename_ShouldThrowAnException_WhenItIsOSX(OS os)
        {
            // Arrange
            this.mockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(os);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => this.directoryServiceFactory.GetDirectoryService(this.mockRuntimeInformation.Object));

            // Assert
            string expected = "XpdfNet currently only supports Linux and Windows OS.";
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotextExe_WhenItIsWindows()
        {
            // Arrange
            this.mockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Windows);

            // Act
            var actual = this.directoryServiceFactory.GetDirectoryService(this.mockRuntimeInformation.Object);

            // Assert
            Assert.IsType<DirectoryServiceWindows>(actual);
        }
    }
}
