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
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                os = OS.Linux;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                os = OS.Windows;
            }
#endif

            return os;
        }
    }

}
