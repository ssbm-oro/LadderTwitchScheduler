namespace LadderTwitchScheduler.Clients.Ladder
{
    public class RacerStats
    {
        public string Category { get; set; }
        public int flag_id { get; set; }
        public int Played { get; set; }
        public int Finished { get; set; }
        public int Fastest { get; set; }
        public int Average { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
    }
}