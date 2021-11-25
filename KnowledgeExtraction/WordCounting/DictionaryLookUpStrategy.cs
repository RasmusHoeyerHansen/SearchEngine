using System.Collections.Generic;
using System.Linq;
using Domain_models.Entities;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.WordCounting
{
    internal class DictionaryLookUpStrategy : IMediaItemProcessingStrategy<WordRatio>
    {
        public IEnumerable<WordRatio> ProcessMedia(ITextMediaItem item)
        {
            var strings = item.ParsedStrings;
            int numberOfWords = strings.Count();
            // arbitrarily chosen, to not build list entirely from the start.
            int repeatingWords = 3;
            Dictionary<string, int> ratios = new(numberOfWords/repeatingWords);
            int totalUniqueWords = 0;
            for (int i = 0; i < numberOfWords; i++)
            {
                if (string.IsNullOrWhiteSpace(strings[i]))
                {
                    continue;
                }
                if (ratios.ContainsKey(strings[i]))
                {
                    ratios[strings[i]] += 1;
                    continue;
                }
                ratios.Add(strings[i], 1);
                totalUniqueWords++;
            }
            List<WordRatio> result = new(totalUniqueWords);
            foreach (KeyValuePair<string,int> keyValuePair in ratios)
            {
                result.Add(new WordRatio(){Word = keyValuePair.Key, Occurances = keyValuePair.Value});
            }

            return result;
        }
    }
}