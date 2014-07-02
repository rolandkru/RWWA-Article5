// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The table storage appender.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ClientLog
{
    using log4net.Appender;
    using log4net.Core;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;

    using Newtonsoft.Json;

    /// <summary>
    ///     The queue storage appender.
    /// </summary>
    public class QueueStorageAppender : AppenderSkeleton
    {
        /// <summary>
        ///     The queue.
        /// </summary>
        private CloudQueue queue;

        /// <summary>
        ///     The activate options.
        /// </summary>
        public override void ActivateOptions()
        {
            base.ActivateOptions();

            var connectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            var queueClient = storageAccount.CreateCloudQueueClient();

            this.queue = queueClient.GetQueueReference("clientlogs");
            this.queue.CreateIfNotExists();
        }

        /// <summary>
        /// The append.
        /// </summary>
        /// <param name="loggingEvent">
        /// The logging event.
        /// </param>
        protected override void Append(LoggingEvent loggingEvent)
        {
            string messageContent = JsonConvert.SerializeObject(loggingEvent);
            var queueMessage = new CloudQueueMessage(messageContent);
            this.queue.AddMessageAsync(queueMessage);
        }
    }
}