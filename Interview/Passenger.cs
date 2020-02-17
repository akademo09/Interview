using System;

namespace Interview
{
    public class Passenger : IStoreable<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
