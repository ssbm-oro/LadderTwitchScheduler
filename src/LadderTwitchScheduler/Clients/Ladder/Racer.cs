using System.Collections;
using System.Collections.Generic;

namespace LadderTwitchScheduler.Clients.Ladder
{
    public class Racer
    {
        public int racer_id { get; set; }
        public string RacerName { get; set; }
    }

    public class RacerList : List<Racer>, IEnumerable<Racer>
    {
        public RacerList()
        {
        }

        public RacerList(IEnumerable<Racer> collection) : base(collection)
        {
            racers = collection;
        }

        public RacerList(int capacity) : base(capacity)
        {
        }

        public IEnumerable<Racer> racers { get; set; }
        public int count { get; set; }

        IEnumerator<Racer> IEnumerable<Racer>.GetEnumerator()
        {
            return racers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return racers.GetEnumerator();
        }
    }
}