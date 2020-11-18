namespace Xpdf.Wrapper
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Manages the process of kicking off a process.
    /// </summary>
    public class ProcessService
    {
        private readonly Process process;
        private readonly string filename;
        private readonly string arguments;
        private readonly string workingDirectory;
        private readonly StringBuilder outputBuilder = new StringBuilder();
        private readonly StringBuilder errorBuilder = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessService"/> class.
        /// </summary>
        /// <param name="filename">Filename to execute.</param>
        /// <param name="arguments">Arguments to be passed to the filename being executed.</param>
        /// <param name="workingDirectory"></param>
        public ProcessService(string filename, string arguments, string workingDirectory)
        {
            this.filename = filename ?? throw new ArgumentNullException(nameof(filename));
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
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardErrorEncoding = Encoding.UTF8,
                    StandardOutputEncoding = Encoding.UTF8,
                },
            };
        }

        /// <summary>
        /// Gets the output from the StandardOuput.
        /// </summary>
        public string StandardOutout => this.outputBuilder.ToString();

        /// <summary>
        /// Gets the standard error output.
        /// </summary>
        public string ErrorOutout => this.errorBuilder.ToString();

        /// <summary>
        /// Begin the process and wait for it's completion.
        /// </summary>
        public void StartAndWaitForExit()
        {
            try
            {
                this.process.OutputDataReceived += (sender, args) => this.outputBuilder.Append(args.Data);
                this.process.ErrorDataReceived += (sender, args) => this.errorBuilder.Append(args.Data);
                this.process.Start();
                this.process.BeginOutputReadLine();
                this.process.BeginErrorReadLine();
                this.process.WaitForExit();

                if (this.errorBuilder.Length > 0)
                {
                    throw new Exception(this.errorBuilder.ToString());
                }
            }

            // TODO: May want to catch all errors here. Especially for linux and mac os.
            catch (Win32Exception ex)
            {
                throw new Win32Exception($"Message: {ex.Message}. InnerException: {ex.InnerException}. Filename: {this.filename}; Arguments: {this.arguments}; WorkingDirectory: {this.workingDirectory};");
            }
        }
    }
}
