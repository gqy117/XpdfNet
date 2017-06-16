namespace XpdfNet.Tests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Moq;
    using Xunit;
    using XpdfNet;

    public class DirectoryServiceWindowsTest
    {
        private IDirectoryService DirectoryService;

        public DirectoryServiceWindowsTest()
        {
            this.DirectoryService = new DirectoryServiceWindows();
        }
        
        [Fact]
        public void GetPDFToTextExeFilename_ShouldReturnPdftotextExe_WhenItIsWindows()
        {
            // Arrange

            // Act
            string actual = this.DirectoryService.Filename;

            // Assert
            string expected = Path.Combine(this.DirectoryService.WorkingDirectory, "pdftotext.exe");
            Assert.Equal(expected, actual);
        }
    }
}
