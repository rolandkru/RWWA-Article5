// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ClientLog
{
    using System;
    using System.Diagnostics;

    using log4net;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {            
            log4net.Config.XmlConfigurator.Configure();

            // Log a Fatal Error to FileAppender, QueueStorageAppender and TableStorageAppender 
            // as configured in the log4net section App.config
            var logger = LogManager.GetLogger("root");
            logger.Fatal("Fatal error");
            
            Console.WriteLine("Fatal error logged.");
            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();

            // Start Log File to Blob Storage Synchronization
            Process.Start("AzureStorageFileSyncTool.exe");
        }
    }
}