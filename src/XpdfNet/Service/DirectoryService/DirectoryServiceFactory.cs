namespace XpdfNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DirectoryServiceFactory
    {
        public IDirectoryService GetDirectoryService(IRuntimeInformation runtimeInformation)
        {
            IDirectoryService result = null;

            switch (runtimeInformation.GetOSPlatform())
            {
                case OS.Windows:
                    result = new DirectoryServiceWindows();
                    break;

                case OS.Linux:
                case OS.OSX:
                    result = new DirectoryServiceLinux();
                    break;

                default:
                    throw new ArgumentException("XpdfNet currently only supports Linux, Windows and OSX.");
            }

            return result;
        }
    }
}
