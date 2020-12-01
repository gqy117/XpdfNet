using System;
using System.Collections.Generic;
using System.Text;

namespace Xpdf.Wrapper
{
    /// <summary>
    /// Represents all Executable names and how to retrieve them based on OS.
    /// </summary>
    public class XpdfExecutable
    {
        private string LinuxName { get; set; }

        private string OsxName { get; set; }

        private string WindowsName { get; set; }

        /// <summary>
        /// Creates new XpdfExecutable object.
        /// </summary>
        /// <param name="linuxName">Linux filename</param>
        /// <param name="osxName">OSX filename</param>
        /// <param name="windowsName">Windows filename</param>
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
                case OS.OSX: return this.OsxName.ThrowIfWhite(nameof(this.OsxName), "OSX is currently unsupported");
                case OS.Windows: return this.WindowsName.ThrowIfWhite(nameof(this.WindowsName), "Windows is currently unsupported");
            }

            throw new Exception($"Unknown OS: {os}");
        }

        internal string GetExecutableName(OS os, string pdfExeName)
        {
            switch (os)
            {
                case OS.Linux: return "/bin/bash";
                case OS.OSX: throw new Exception("OSX is currently unsupported");
                case OS.Windows: return pdfExeName;
            }

            throw new Exception($"Unknown OS: {os}");
        }
    }
}