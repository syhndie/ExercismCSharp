using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Concurrent;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        ConcurrentDictionary<char, int> result = new ConcurrentDictionary<char, int>();

        Parallel.ForEach(texts, s =>
        {
            var letterCounts = s.ToLower()
                .Where(char.IsLetter)
                .GroupBy(c => c);

            foreach (var g in letterCounts)
            {
                result.AddOrUpdate(g.Key, g.Count(), (k, v) => v + g.Count());
            }
        });

        return result.ToDictionary(p => p.Key, p => p.Value);
    }
}