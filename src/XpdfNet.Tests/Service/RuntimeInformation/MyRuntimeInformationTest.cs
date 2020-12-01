namespace XpdfNet.Tests
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Xunit;

    public class MyRuntimeInformationTest
    {/*
        private readonly MyRuntimeInformation myRuntimeInformation;
        
        public MyRuntimeInformationTest()
        {
            this.myRuntimeInformation = new MyRuntimeInformation();
        }

        [Fact]
        public void GetOSPlatform_ShouldReturnCorrespondingOS()
        {
            // Act
            OS actual = this.myRuntimeInformation.GetOSPlatform();

            // Assert
            OS expected = GetCurrentOS();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, false)]
        public void GetOSPlatform_ShouldReturnLinux(bool isLinux, bool isWindows)
        {
            // Act
            OS actual = this.myRuntimeInformation.GetOSPlatform(isLinux, isWindows);

            // Assert
            OS expected = OS.Linux;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, false)]
        public void GetOSPlatform_ShouldReturnUnsupport(bool isLinux, bool isWindows)
        {
            // Act
            OS actual = this.myRuntimeInformation.GetOSPlatform(isLinux, isWindows);

            // Assert
            OS expected = OS.OSX;
            Assert.Equal(expected, actual);
        }

        private static OS GetCurrentOS()
        {
            OS os;

            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
            {
                os = OS.Windows;
            }
            else if (File.Exists(@"/proc/sys/kernel/ostype"))
            {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                {
                    // Note: Android gets here too
                    os = OS.Linux;
                }
                else
                {
                    os = OS.Unsupported;
                }
            }
            else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
            {
                // Note: iOS gets here too
                os = OS.OSX;
            }
            else
            {
                os = OS.Unsupported;
            }

            return os;
        }
        */
    }
}
