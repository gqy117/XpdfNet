namespace XpdfNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using Xunit;
    using XpdfNet;

    public class DirectoryServiceUnixTest
    {
        private IDirectoryService DirectoryService;

        public DirectoryServiceUnixTest()
        {
            this.DirectoryService = new DirectoryServiceUnix();
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
    }
}
