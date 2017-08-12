using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace TagMatchLib
{
    public class TagMatch : ITagMatch
    {

        public TagMatch()
        {
            IgnoreCase = true;
        }
        public bool IgnoreCase { get; set; }



        public string inputStr { get; set; }


        public string tag { get; set; }

        public IEnumerable<string> AllTopLevelTags(string str)
        {
            // string matchingRegex = @"<\s*(?<tag>\w+)\s*>(?<body>\.*)</\s*\k<tag>\s*>";
            string matchingRegex = @"(?ix)<\s*(?<tag>\w+)\s*>(?<body>.*)</\s*\1\s*>";
            Match m1 = Regex.Match(str, matchingRegex, RegexOptions.IgnoreCase);
            MatchCollection matchCollection = Regex.Matches(str, matchingRegex, RegexOptions.IgnoreCase);
            ICollection<string> arr = new List<string>();
            foreach (Match m in matchCollection)
            {
                arr.Add(m.Value);
            }
            return arr.ToList();
        }

        public IEnumerable<string> ExtractAllTagObjects(string str)
        {
            string matchingRegex = string.Format(@"(?ix)<\s*{0}\s*>(?<body>.*)</\s*{0}\s*>", tag);
            Match m1 = Regex.Match(inputStr, matchingRegex, RegexOptions.IgnoreCase);
            MatchCollection matchCollection = Regex.Matches(inputStr, matchingRegex, RegexOptions.IgnoreCase);
            ICollection<string> arr = new List<string>();
            foreach (Match m in matchCollection)
            {
                arr.Add(m.Value);
            }
            return arr.ToList();
        }

        public string ExtractBody()
        {
            string matchingRegex = string.Format(@"(?ix)<\s*{0}\s*>(?<body>.*)</\s*{0}\s*>", tag);
            Match m = Regex.Match(inputStr, matchingRegex, RegexOptions.IgnoreCase);
            string body = m.Groups["body"].Value;
            return body;
        }

        public string TagName(string tagString)
        {
            string matchingRegex = @"(?ix)<\s*(?<tag>\w+)\s*>(?<body>.*)</\s*\1\s*>";
            Match m = Regex.Match(tagString, matchingRegex);
            if (m.Success)
            {
                return m.Groups["tag"].Value;
            }
            return null;
        }

        public bool ValidateEnd()
        {
            string matchingRegex = string.Format(@"(?ix)</s*{0}\s*>$", tag);
            bool hasValidEnd = Regex.IsMatch(inputStr, matchingRegex);
            return hasValidEnd;
        }

        public bool ValidateStart()
        {
            string matchingRegex = string.Format(@"(?ix)^<s*{0}\s*>", tag);
            bool hasValidStart = Regex.IsMatch(inputStr, matchingRegex);
            return hasValidStart;
        }
    }
}
