namespace XpdfNet
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    public class ProcessService
    {
        private readonly Process Process;
        private readonly string Filename;
        private readonly string Arguments;
        private readonly string WorkingDirectory;


        public ProcessService(string filename, string arguments, string workingDirectory)
        {
            this.Filename = filename;
            this.Arguments = arguments;
            this.WorkingDirectory = workingDirectory;

            this.Process = new Process
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
                this.Process.Start();
                this.Process.WaitForExit();
            }
            catch (Win32Exception ex)
            {
                throw new Exception($"Message: {ex.Message}. InnerException: {ex.InnerException}. Filename: {Filename}; Arguments: {Arguments}; WorkingDirectory: {WorkingDirectory};");
            }
        }
    }
}
