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
                    result = new DirectoryServiceUnix();
                    break;

                default:
                case OS.Unsupported:
                case OS.OSX:
                    throw new ArgumentException("XpdfNet currently only supports Unix and Windows OS.");
            }

            return result;
        }
    }
}
