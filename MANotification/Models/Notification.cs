using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace MANotification.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string? AlertTitle { get; set; }
        public DateTime SentTime { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GCNotificationStatus Status { get; set; }
    }
}
