using SampleForHttp.Models;
using SampleForHttp.Services;
using System.Threading.Tasks;
using System;

namespace SampleForHttp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjo" +
                "i0JHQvtCz0LTQsNC9IiwidGVuYW50IjoiNzI5IiwibmJmIjoxNjMwMjI3NTQzLCJle" +
                "HAiOjE2MzAzMTM5NDMsImlzcyI6IlRlc3QtQmFja2VuZC0xIiwiYXVkIjoiQmFza2V" +
                "0QmFsbENsdWJTYW1wbGUifQ.ysEKsiS8ZN5MTxXkqzu1XDYtB_sg1xLHH9sur4UlPO8";

            TeamService teamService = new TeamService(token);

            Team team = new Team()
            {
                Name = "Spartac",
                FoundationYear = 2009,
                Division = "ads",
                Conference = "A",
                ImageUrl = "myImage"
            };

            await teamService.Add(team);
            var teams = await teamService.GetTeams();

            PlayerService playerService = new PlayerService(token);

            Player player = new Player()
            {
                Name = "Max",
                Number = 9,
                Position = "Forward",
                Team = 826,
                Birthday = new DateTime(1990, 01, 01),
                Height = 190,
                Weight = 80,
                AvatarUrl = "AvatarUrl9"
            };

            await playerService.Add(player);
            var players = await playerService.GetPlayers();
        }
    }
}
