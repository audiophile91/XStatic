using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace XStatic.Static
{
    public static class XString
    {

        /// <summary>
        /// Checks number of phrase occurences in given text.
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="text"></param>
        /// <returns>Count of phrase occurences.</returns>
        public static int GetPhraseOccurences(string phrase, string text) => text.Split(phrase).Length - 1;

        /// <summary>
        /// Looks for first phrase occurence index in given text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="phrase"></param>
        /// <returns>Index of first phrase occurence or -1 if phrase does not exists</returns>
        public static int GetPhraseOccurenceIndex(string phrase, string text)
        {
            for (int i = 0; i < text.Length - phrase.Length - 1; i++)
            {
                if (text.Substring(i, phrase.Length) == phrase)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Removes all phrase occurences but first or last based on boolean input.
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="text"></param>
        /// <param name="leaveFirstOccurence"></param>
        /// <returns>Duplicates free text.</returns>
        public static string RemovePhraseDuplicates(string phrase, string text, bool leaveFirstOccurence)
        {
            if (text != null && phrase != null)
            {
                var parts = text.Split(phrase);

                if (parts.Length > 2)
                {
                    var output = new StringBuilder();

                    if (leaveFirstOccurence)
                    {
                        output.Append(parts.First());
                        output.Append(phrase);
                        output.Append(string.Join("", parts.Skip(1)));
                    }
                    else
                    {
                        output.Append(string.Join("", parts.SkipLast(1)));
                        output.Append(phrase);
                        output.Append(parts.Last());
                    }
                    return output.ToString();
                }
                return text;
            }
            else
            {
                return "";
            }
        }       

    }
}
