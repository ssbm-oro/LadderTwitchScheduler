using System.Collections;
using System.Collections.Generic;

namespace LadderTwitchScheduler.Clients.Ladder
{
    public class ScheduleItem
    {
        public int race_id { get; set; }
        public string Season { get; set; }
        public string Mode { get; set; }
        public string StartTime { get; set; }
        public string RaceName { get; set; }
        public bool HasCompleted { get; set; }
        public int ParticipantCount { get; set; }
    }

    public class Schedule : List<ScheduleItem>, IEnumerable<ScheduleItem>
    {
        public IEnumerable<ScheduleItem> Schedules;

        public Schedule()
        {
        }

        public Schedule(IEnumerable<ScheduleItem> collection) : base(collection)
        {
            Schedules = collection;
        }

        public Schedule(int capacity) : base(capacity)
        {
        }

        IEnumerator<ScheduleItem> IEnumerable<ScheduleItem>.GetEnumerator()
        {
            return Schedules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Schedules.GetEnumerator();
        }
    }
}