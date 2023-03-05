using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Filtering
{
    public class NewsfeedFilterInputModel
    {
        private char[] separators = { ' ', ',', '.', ';', ':', '?', '!' };

        public string Title { get; set; }
        public string Whitelist { get; set; }
        public string Blacklist { get; set; }

        public NewsfeedFilter ConvertInputModel()
        {
            NewsfeedFilter newFilter = new NewsfeedFilter();
            newFilter.Title = this.Title;
            newFilter.UserWhitelist = HandleInputList(this.Whitelist);
            newFilter.UserBlacklist = HandleInputList(this.Blacklist);
            return newFilter;
        }

        private List<string> HandleInputList(string inputList)
        {
            return inputList.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
