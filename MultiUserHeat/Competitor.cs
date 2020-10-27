using System;

namespace MultiUserHeat
{
    public class Competitor
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int StartingNumber { get; set; }

        public Competitor()
        {
            Id = new Guid();
        }
    }
}
