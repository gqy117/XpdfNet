namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using Xunit;
    using XpdfNet;

    public class DirectoryServiceFactoryTest
    {
        private DirectoryServiceFactory DirectoryServiceFactory;
        private Mock<IRuntimeInformation> MockRuntimeInformation;

        public DirectoryServiceFactoryTest()
        {
            this.MockRuntimeInformation = new Mock<IRuntimeInformation>();
            this.DirectoryServiceFactory = new DirectoryServiceFactory();
        }

        [Fact]
        public void GetDirectoryService_ShouldReturnDirectoryServiceLinux_WhenItIsLinux()
        {
            // Arrange
            this.MockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Linux);

            // Act
            var actual = this.DirectoryServiceFactory.GetDirectoryService(this.MockRuntimeInformation.Object);

            // Assert
            Assert.IsType<DirectoryServiceLinux>(actual);
        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldThrowAnException_WhenItIsOSX()
        {
            // Arrange
            this.MockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.OSX);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => this.DirectoryServiceFactory.GetDirectoryService(this.MockRuntimeInformation.Object));

            // Assert
            string expected = "XpdfNet currently only supports Linux and Windows OS.";
            Assert.Equal(expected, ex.Message);

        }

        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotextExe_WhenItIsWindows()
        {
            // Arrange
            this.MockRuntimeInformation.Setup(x => x.GetOSPlatform()).Returns(OS.Windows);

            // Act
            var actual = this.DirectoryServiceFactory.GetDirectoryService(this.MockRuntimeInformation.Object);

            // Assert
            Assert.IsType<DirectoryServiceWindows>(actual);
        }
    }
}
