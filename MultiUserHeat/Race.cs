using System;
using System.Collections.Generic;

namespace MultiUserHeat
{
    public enum RaceType
    {
        Default = 0,
        Kids = 1,
        Women = 2
    }

    public class Race
    {
        private const int _maxNumberOfHeats = 3;
        private const int _maxNumberOfCompetitors = 5;

        public RaceType Type { get; private set; }
        public ICollection<Competitor> Competitors { get; private set; }
        public ICollection<Heat> Heats { get; private set; } = new List<Heat>();

        public Race() : this(RaceType.Default, new List<Competitor>())
        {
        }

        public Race(RaceType type) : this(type, new List<Competitor>())
        {
        }

        public Race(RaceType type, ICollection<Competitor> competitors)
        {
            if (competitors.Count > _maxNumberOfCompetitors)
                throw new ArgumentException($"Du kan bara lägga till {_maxNumberOfCompetitors} stycken tävlande");

            Type = type;
            Competitors = competitors;
        }

        public bool AddCompetitor(Competitor competitor)
        {
            if (Competitors.Count == _maxNumberOfCompetitors)
                return false;

            if (Competitors.Contains(competitor))
                return false;

            Competitors.Add(competitor);
            return true;
        }

        private bool AddHeat(Heat heat)
        {
            if (Heats.Count == _maxNumberOfHeats)
                return false;

            if (Heats.Contains(heat))
                return false;

            Heats.Add(heat);
            return true;
        }

        public void StartRace()
        {
            if (Competitors.Count == 0)
                throw new ApplicationException("Ett race måste ha tävlande");

            while (Heats.Count < _maxNumberOfHeats)
            {
                AddHeat(new Heat(Competitors, Heats.Count + 1));
            }

            foreach (var heat in Heats)
            {
                heat.RunHeat();
            }
        }
    }
}
