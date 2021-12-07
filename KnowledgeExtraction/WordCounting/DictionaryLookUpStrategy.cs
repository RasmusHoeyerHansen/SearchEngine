using System.Collections.Generic;
using System.Linq;
using Domain_models.Entities;
using KnowledgeExtraction.Common;

namespace KnowledgeExtraction.WordCounting
{
    internal class DictionaryLookUpStrategy : IMediaItemProcessingStrategy<IWordCount>
    {
        public IEnumerable<IWordCount> ProcessMedia(ITextItem item)
        {
            string[] strings = ApproximateDictSize(item, out int numberOfWords, out Dictionary<string, int> WordRatios);
            PupulateRatioDictionary(numberOfWords, strings, WordRatios, out int totalUniqueWords);

            List<IWordCount> result = new(totalUniqueWords);
            foreach (KeyValuePair<string, int> keyValuePair in WordRatios)
                result.Add(new WordCount()
                    {Word = keyValuePair.Key, Occurances = keyValuePair.Value, MediaTitle = item.Title});

            return result;
        }

        private static string[] ApproximateDictSize(ITextItem item, out int numberOfWords,
            out Dictionary<string, int> ratios)
        {
            var strings = item.ParsedStrings;
            numberOfWords = strings.Count();
            // arbitrarily chosen, to not build list entirely from the start.
            int repeatingWords = 3;
            ratios = new Dictionary<string, int>(numberOfWords / repeatingWords);
            return strings;
        }

        private void PupulateRatioDictionary(int numberOfWords, string[] strings, Dictionary<string, int> ratios,
            out int totalUniqueWords)
        {
            totalUniqueWords = 0;
            for (int i = 0; i < numberOfWords; i++)
            {
                if (string.IsNullOrWhiteSpace(strings[i])) continue;

                if (ratios.ContainsKey(strings[i]))
                {
                    ratios[strings[i]] += 1;
                    continue;
                }

                ratios.Add(strings[i], 1);
                totalUniqueWords++;
            }
        }
    }
}