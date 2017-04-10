﻿using System.Text.RegularExpressions;

namespace AspxParser
{
    partial class Parser
    {
        private bool ProcessEndTag(Match match)
        {
            var name = match.Groups["tagname"].Value;
            if (inScriptTag)
            {
                if ("script".EqualsNoCase(name))
                {
                    currentScriptTagStart = -1;
                    inScriptTag = false;
                }
                else
                {
                    return false;
                }
            }

            ProcessLiteral(match.Index);

            var location = CreateLocation(match);
            eventListener.OnTag(location, TagType.Close, string.Intern(name), TagAttributes.Empty);
            return true;
        }
    }
}
