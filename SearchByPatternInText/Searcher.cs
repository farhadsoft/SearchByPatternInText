using System;
using System.Collections.Generic;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string text, string pattern, bool overlap)
        {
            if (text is null)
            {
                throw new ArgumentException($"Thrown if {nameof(text)} is null.");
            }

            if (pattern is null)
            {
                throw new ArgumentException($"Thrown if {nameof(pattern)} is null.");
            }

            int lastIndex = 0;
            List<int> result = new List<int>();

            while (lastIndex != -1)
            {
                lastIndex = text.IndexOf(pattern, lastIndex, StringComparison.OrdinalIgnoreCase);

                if (lastIndex != -1)
                {
                    lastIndex++;
                    result.Add(lastIndex);
                }
            }

            return result.ToArray();
        }
    }
}
