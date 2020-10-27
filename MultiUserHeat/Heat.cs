using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiUserHeat
{
    public class Heat
    {
        private static Random _random;
        
        public IDictionary<int, Competitor> HeatResult { get; private set; }
        public IEnumerable<Competitor> Competitors { get; private set; }
        public int Number { get; private set; }
        public Heat(ICollection<Competitor> competitors, int number)
        {
            Competitors = competitors;
            HeatResult = new Dictionary<int, Competitor>();
            Number = number;
            _random = new Random();
        }

        public IDictionary<int, Competitor> RunHeat()
        {
            ShuffleCompetitors(Competitors);
            CreateHeatResult(Competitors);
            return HeatResult;
        }

        private void CreateHeatResult(IEnumerable<Competitor> competitors)
        {
            var position = 1;
            foreach (var competitor in competitors)
            {
                HeatResult.Add(position++, competitor);
            }
        }

        private void ShuffleCompetitors(IEnumerable<Competitor> list)
        {
            var shuffledList = list.Select(x => new { Number = _random.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item);
            Competitors = shuffledList;
        }
    }
}