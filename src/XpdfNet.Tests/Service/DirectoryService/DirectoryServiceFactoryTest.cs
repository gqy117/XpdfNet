namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using Xpdf.Wrapper;
    using XpdfNet;
    using Xunit;

    public class DirectoryServiceFactoryTest
    {
        /*
        private readonly Mock<IRuntimeInformation> mockRuntimeInformation;

        public DirectoryServiceFactoryTest()
        {
            this.mockRuntimeInformation = new Mock<IRuntimeInformation>();
        }

        [Fact]
        public void GetDirectoryService_ShouldReturnDirectoryServiceLinux_WhenItIsLinux()
        {
            // Arrange
            this.mockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Linux);

            // Act
            var actual = DirectoryServiceFactory.GetDirectoryService(this.mockRuntimeInformation.Object);

            // Assert
            Assert.IsType<DirectoryServiceLinux>(actual);
        }

        [Fact]
        public void GetDirectoryService_ShouldReturnDirectoryServiceOSX_WhenItIsOSX()
        {
            // Arrange
            this.mockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.OSX);

            // Act
            var actual = DirectoryServiceFactory.GetDirectoryService(this.mockRuntimeInformation.Object);

            // Assert
            Assert.IsType<DirectoryServiceOSX>(actual);
        }

        [Theory]
        [InlineData(OS.Unsupported)]
        [InlineData(null)]
        public void GetPDFToTextExeFilename_ShouldThrowAnException_WhenItIsOSX(OS os)
        {
            // Arrange
            this.mockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(os);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => DirectoryServiceFactory.GetDirectoryService(this.mockRuntimeInformation.Object));

            // Assert
            string expected = "XpdfNet currently only supports Linux, Windows and OSX.";
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotextExe_WhenItIsWindows()
        {
            // Arrange
            this.mockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Windows);

            // Act
            var actual = DirectoryServiceFactory.GetDirectoryService(this.mockRuntimeInformation.Object);

            // Assert
            Assert.IsType<DirectoryServiceWindows>(actual);
        }
        */
    }
}
