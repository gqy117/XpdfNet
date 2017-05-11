using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpdfNet
{
    public class ProcessService
    {
        private readonly Process Process;
        private readonly string Filename;
        private readonly string WorkingDirectory;


        public ProcessService(string filename, string arguments, string workingDirectory)
        {
            this.Filename = filename;
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
                throw new Exception($"The system cannot find the file specified. Filename: {Filename}, WorkingDirectory: {WorkingDirectory}.");
            }
        }
    }
}
