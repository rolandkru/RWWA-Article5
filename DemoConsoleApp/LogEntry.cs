// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The log entry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ClientLog
{
    using System;

    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    ///     The log entry.
    /// </summary>
    public sealed class LogEventEntity : TableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventEntity"/> class.
        /// </summary>
        public LogEventEntity()
        {
            var now = DateTime.UtcNow;
            this.PartitionKey = string.Format("{0:yyyy-MM}", now);
            this.RowKey = string.Format("{0:dd HH:mm:ss.fff}-{1}", now, Guid.NewGuid());
        }

        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// Gets or sets the thread name.
        /// </summary>
        public string ThreadName { get; set; }

        /// <summary>
        /// Gets or sets the logger name.
        /// </summary>
        public string LoggerName { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        public string Line { get; set; }
    }
}