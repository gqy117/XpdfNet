namespace XpdfNet
{
    using System;

    public class DirectoryService
    {
        public string GetWorkingDirectory()
        {
            string workingDirectory;

#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif

            return workingDirectory;
        }
    }
}
