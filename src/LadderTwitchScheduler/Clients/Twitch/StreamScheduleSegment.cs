using System;

namespace LadderTwitchScheduler.Clients.Twitch
{
    public class StreamScheduleSegment
    {
        public DateTimeOffset start_time { get; set; }
        public string timezone { get; set; }
        public bool is_recurring { get; set; }
        public string duration { get; set; }
        public string category_id { get; set; }
        public string title { get; set; }
    }
}