using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class TagCleaner
    {
        public const string ALLOWED_TAG_CHARACTERS = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ/-&.: ";

        public static string cleanTag(string tag)
        {
            if (tag.Except(ALLOWED_TAG_CHARACTERS).Any())
            {
                IEnumerable<char> newCharacters = tag.Except(ALLOWED_TAG_CHARACTERS);
                foreach (char c in newCharacters)
                {
                    tag = tag.Replace(c, Char.Parse(" "));
                }
            }
            return tag.Trim();
        }
    }
}
