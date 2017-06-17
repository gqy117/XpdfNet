namespace XpdfNet
{
    using System;
    using System.Runtime.InteropServices;

    public class MyRuntimeInformation : IRuntimeInformation
    {
        public OS GetOSPlatform()
        {
            OS os = OS.Unsupported;

#if NET45
            os = OS.Windows;
#else
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            os = this.GetOSPlatform(isLinux, isWindows);
#endif

            return os;
        }

        public OS GetOSPlatform(bool isLinux, bool isWindows)
        {
            OS os = OS.Unsupported;

            if (isLinux)
            {
                os = OS.Linux;
            }
            else if (isWindows)
            {
                os = OS.Windows;
            }

            return os;
        }
    }
}
