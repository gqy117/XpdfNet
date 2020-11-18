using System;
using System.Collections.Generic;
using System.Text;

namespace Xpdf.Wrapper.Model
{
    /// <summary>
    /// Represents all Executable names and how to retrieve them based on OS.
    /// </summary>
    public class XpdfExecutable
    {
        private string LinuxName { get; set; }
        private string OsxName { get; set; }
        private string WindowsName { get; set; }

        public XpdfExecutable(string linuxName, string osxName, string windowsName)
        {
            this.LinuxName = linuxName;
            this.OsxName = osxName;
            this.WindowsName = windowsName;
        }

        internal string GetXpdfExecutableName(OS os)
        {
            switch (os)
            {
                case OS.Linux: return this.LinuxName.ThrowIfWhite(nameof(LinuxName), "Linux is currently unsupported");
                case OS.OSX: return this.OsxName.ThrowIfWhite(nameof(OsxName), "OSX is currently unsupported");
                case OS.Windows: return this.WindowsName.ThrowIfWhite(nameof(WindowsName), "Windows is currently unsupported");
            }

            throw new Exception($"Unknown OS: {os.ToString()}");
        }

        internal string GetExecutableName(OS os)
        {
            //Will be bash if unix
            //Will be XpdfExec name if windows
            //Will throw exception for mac
        }
    }
}