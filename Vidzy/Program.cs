
using System.Collections.Generic;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }

        public Tag()
        {
            Videos = new HashSet<Video>();
        }
    }
}
