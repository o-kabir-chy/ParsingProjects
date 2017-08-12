using System;
using System.Collections.Generic;
using System.Linq;

namespace TagMatchLib
{
    public interface ITagMatch
    {
        string tag { get; set; }
        // bool IgnoreCase { get; set; }
        string inputStr { get; set; }
        bool ValidateStart();
        bool ValidateEnd();
        string ExtractBody();
        IEnumerable<string> ExtractAllTagObjects(string str);
        IEnumerable<string> AllTopLevelTags(string str);
        string TagName(string tagString);
    }
}
