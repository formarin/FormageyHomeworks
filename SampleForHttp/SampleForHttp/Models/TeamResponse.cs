using System.Collections.Generic;

namespace SampleForHttp.Models
{
    public class TeamResponse
    {
        public IEnumerable<Team> Data { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
