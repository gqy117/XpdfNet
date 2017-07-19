namespace XpdfNet.Tests
{
    using System;
    using Xunit;

    public class ProcessServiceTest
    {
        private ProcessService processService;

        [Fact]
        public void ToText_ShouldThrowExceptionWithPathInformation_WhenPDFToTextExeCanNotBeFound()
        {
            // Arrange
            string filename = "nonExistingfile.exe";
            string arguments = "arg1 arg2";
            string workingDirectory = "./";

            this.processService = new ProcessService(filename, arguments, workingDirectory);

            // Act
            Exception ex = Assert.Throws<Exception>(() => this.processService.StartAndWaitForExit());

            // Assert
            string expected = $"Filename: {filename}; Arguments: {arguments}; WorkingDirectory: {workingDirectory};";
            Assert.Contains(expected, ex.Message);
        }
    }
}
