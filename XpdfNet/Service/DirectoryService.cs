namespace XpdfNet
{
    using System;

    public class DirectoryService
    {
        public string GetWorkingDirectory()
        {
            string workingDirectory;

#if NET45
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#else
            workingDirectory = AppContext.BaseDirectory;
#endif

            return workingDirectory;
        }
    }
}
