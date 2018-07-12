using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using AngleSharp;

namespace Guess
{
    public class Names
    {
        public string name { get; set; }
        public List<string> allNames = new List<string> { };

        public Names()
        {
            FetchList();
        }

        public async void FetchList()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "http://www.avss.ucsb.edu/NameFema.HTM";

            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cellSelector = "tr td:nth-child(3)";
            var cells = document.QuerySelectorAll(cellSelector);
            var names = cells.Select(m => m.TextContent);

            foreach(string name in names)
            {
                allNames.Add(name);
            }

            return;
        }
    }
}
