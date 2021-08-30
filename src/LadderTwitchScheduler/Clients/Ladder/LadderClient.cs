using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http.Json;

namespace LadderTwitchScheduler.Clients.Ladder
{
    public class LadderClient
    {
        private HttpClient client = new HttpClient();
        private string baseUrl = new string("https://alttprladder.com/api/v1/PublicApi/");

        public LadderClient()
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));
        }

        public async Task<RacerList> GetActiveRacersAsync()
        {
            RacerList racers = null;
            using (var res = await client.GetAsync("GetActiveRacers"))
            {
                if (res.IsSuccessStatusCode)
                {
                    racers = new RacerList();
                    racers.AddRange(await res.Content.ReadFromJsonAsync<Racer[]>());
                }
            }
            return racers;
        }

        public async Task<Schedule> GetScheduleAsync(int season_id)
        {
            Schedule schedule = null;
            using (var res = await client.GetAsync($"GetSchedule?season_id={season_id}"))
            {
                if (res.IsSuccessStatusCode)
                {
                    schedule = new Schedule(
                        await res.Content.ReadFromJsonAsync<ScheduleItem[]>()
                        );
                }
            }
            return schedule;
        }

        public async Task<Season[]> GetSeasonsAsync()
        {
            Season[] seasons = null;
            using (var res = await client.GetAsync("GetSeasons"))
            {
                if (res.IsSuccessStatusCode)
                {
                    seasons = await res.Content.ReadFromJsonAsync<Season[]>();
                }
            }
            return seasons;
        }

        public async Task<Flag[]> GetFlagsAsync()
        {
            Flag[] flags = null;
            using (var res = await client.GetAsync("GetFlags"))
            {
                if (res.IsSuccessStatusCode)
                {
                    flags = await res.Content.ReadFromJsonAsync<Flag[]>();
                }
            }

            return flags;
        }

        public async Task <Standing[]> GetStandingsAsync(int season_id = 0, int flag_id = 0)
        {
            Standing[] standings = null;
            using (var res = await client.GetAsync($"GetStandings?season_id={season_id}&flag_id={flag_id}"))
            {
                if (res.IsSuccessStatusCode)
                {
                    standings = await res.Content.ReadFromJsonAsync<Standing[]>();
                }
            }

            return standings;
        }

        public async Task <Standing[]> GetRacerStandingsAsync(int racer_id, int season_id = 0, int flag_id = 0)
        {
            Standing[] standings = null;
            using (var res = await client.GetAsync($"GetRacerStandings?racer_id={racer_id}&season_id={season_id}&flag_id={flag_id}"))
            {
                if (res.IsSuccessStatusCode)
                {
                    standings = await res.Content.ReadFromJsonAsync<Standing[]>();
                }
            }

            return standings;
        }

        public async Task <RacerHistory> GetRacerHistoryAsync(int racer_id)
        {
            RacerHistory history = null;
            using (var res = await client.GetAsync($"GetRacerHistory?racer_id={racer_id}"))
            {
                if (res.IsSuccessStatusCode)
                {
                    history = await res.Content.ReadFromJsonAsync<RacerHistory>();
                }
            }
            
            return history;
        }

        public async Task <string> GetCurrentRaceTime()
        {
            string raceTime = string.Empty;
            using (var res = await client.GetAsync("GetCurrentRaceTime"))
            {
                if (res.IsSuccessStatusCode)
                {
                    raceTime = await res.Content.ReadAsStringAsync();
                }
            }
            return raceTime;
        }

        public async Task <bool> IsCurrentlyRacing(int racer_id)
        {
            bool isRacing = false;
            using (var res = await client.GetAsync($"IsCurrentlyRacing?racer_id={racer_id}"))
            {
                if (res.IsSuccessStatusCode)
                {
                    isRacing = await res.Content.ReadFromJsonAsync<bool>();
                }
            }

            return isRacing;
        }
    }
}