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
    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    ///     The table storage appender.
    /// </summary>
    public class TableStorageAppender : AppenderSkeleton
    {
        /// <summary>
        ///     The table.
        /// </summary>
        private CloudTable table;

        /// <summary>
        ///     The activate options.
        /// </summary>
        public override void ActivateOptions()
        {
            base.ActivateOptions();

            var connectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            this.table = tableClient.GetTableReference("ClientLogs");
            this.table.CreateIfNotExists();
        }

        /// <summary>
        /// The append.
        /// </summary>
        /// <param name="loggingEvent">
        /// The logging event.
        /// </param>
        protected override void Append(LoggingEvent loggingEvent)
        {
            var entity = new LogEventEntity
                         {
                             Message = loggingEvent.RenderedMessage, 
                             Level = loggingEvent.Level.Name, 
                             Class = loggingEvent.LocationInformation.ClassName,
                             Line = loggingEvent.LocationInformation.LineNumber
                         };

            var insertOperation = TableOperation.Insert(entity);
            this.table.ExecuteAsync(insertOperation);
        }
    }
}