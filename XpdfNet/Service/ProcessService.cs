namespace XpdfNet
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    public class ProcessService
    {
        private readonly Process process;
        private readonly string filename;
        private readonly string arguments;
        private readonly string workingDirectory;

        public ProcessService(string filename, string arguments, string workingDirectory)
        {
            this.filename = filename;
            this.arguments = arguments;
            this.workingDirectory = workingDirectory;

            this.process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = arguments,
                    UseShellExecute = false,
                    WorkingDirectory = workingDirectory,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
        }

        public void StartAndWaitForExit()
        {
            try
            {
                this.process.Start();
                this.process.WaitForExit();
            }
            catch (Win32Exception ex)
            {
                throw new Exception($"Message: {ex.Message}. InnerException: {ex.InnerException}. filename: {this.filename}; arguments: {this.arguments}; workingDirectory: {this.workingDirectory};");
            }
        }
    }
}
