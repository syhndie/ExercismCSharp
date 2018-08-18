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
            foreach (char c in s.ToLower())
            {
                if (Char.IsLetter(c))
                {
                    result.AddOrUpdate(c, 1, (k, v) => v + 1);
                }
            }
        });

        return result.ToDictionary(p => p.Key, p => p.Value);
    }
}