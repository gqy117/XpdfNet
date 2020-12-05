namespace Xpdf.Wrapper
{
    using System;
    using System.Runtime.InteropServices;

    public class MyRuntimeInformation : IRuntimeInformation
    {
        public OS GetOSPlatform()
        {
            OS os;

#if NET45
            os = OS.Windows;
#elif NETSTANDARD2_0
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            os = this.GetOSPlatform(isLinux, isWindows);
#else
            throw new Exception("Unknown OS");
#endif

            return os;
        }

        public OS GetOSPlatform(bool isLinux, bool isWindows)
        {
            OS os = OS.OSX;

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
