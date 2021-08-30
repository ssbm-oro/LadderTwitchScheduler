using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LadderTwitchScheduler.Clients.Twitch
{
    public class TwitchClient
    {
        private HttpClient client = new HttpClient();
        private string clientId = "k85ti06w0g9ckjnnmj11vofxrjioy9";
        private string baseUrl = "https://api.twitch.tv/helix/";

        public string  access_token { get; set; }

        public User LoggedInUser { get; set; }

        public TwitchClient()
        {
            access_token = string.Empty;

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));
            client.DefaultRequestHeaders.Add("Client-Id", clientId);
        }

        public void Login(string access_token)
        {
            this.access_token = access_token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
        }

        public async Task<User> GetUserAsync()
        {
            Users users = await client.GetFromJsonAsync<Users>($"{baseUrl}users");

            /*HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}users");

            using (var res = await client.SendAsync(req))
            {
                if (res.IsSuccessStatusCode)
                {
                    users = await res.Content.ReadFromJsonAsync<Users>();
                }
            }*/

            if (users != null)
            {
                return users.data[0];
            }

            return null;
        }

        public async Task<bool> PutStreamScheduleSegment(StreamScheduleSegment seg, string broadcaster_id)
        {
            using (var res = await client.PostAsJsonAsync<StreamScheduleSegment>($"{baseUrl}schedule/segment?broadcaster_id={broadcaster_id}", seg))
            {
                return (res.IsSuccessStatusCode);
            }
        }
    }
}