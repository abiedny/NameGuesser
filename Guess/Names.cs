using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;

namespace Guess
{
    public static class Names
    {
        public static async Task<List<string>> FetchListAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "http://www.avss.ucsb.edu/NameFema.HTM";

            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cellSelector = "tr td:nth-child(3)";
            var cells = document.QuerySelectorAll(cellSelector);
            var names = cells.Select(m => m.TextContent);

            List<string> allNames = new List<string> { };
            foreach(string name in names)
            {
                allNames.Add(name);
            }

            return allNames;
        }
    }
}
