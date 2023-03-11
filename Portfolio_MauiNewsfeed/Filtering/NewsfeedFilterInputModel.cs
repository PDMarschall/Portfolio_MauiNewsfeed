using Portfolio_MauiNewsfeed.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Filtering
{
    public class NewsfeedFilterInputModel
    {
        private readonly char[] _separators = { ' ', ',', '.', ';', ':', '?', '!' };
        private const string WhitelistName = "Whitelist";
        private const string BlacklistName = "Blacklist";
        private const string RegexError = "Mindst 1 ord og maksimalt 3 ord.";
        private const string DisjunctionError = "Vælg mindst 1 ord til enten whitelist eller blacklist.";

        [Required(ErrorMessage = "Vælg en titel."), MinLength(1)]
        public string Title { get; set; } = string.Empty;

        [RegularExpression(@"^\b[a-zæøåA-ZÆØÅ]+\b(?:[ ,.;:?!]\s*[a-zæøåA-ZÆØÅ]+\b){0,2}\s*$",
            ErrorMessage = RegexError),
            RequiredDisjunction(new string[] { WhitelistName, BlacklistName },
            ErrorMessage = DisjunctionError)]
        public string Whitelist { get; set; } = string.Empty;

        [RegularExpression(@"^\b[a-zæøåA-ZÆØÅ]+\b(?:[ ,.;:?!]\s*[a-zæøåA-ZÆØÅ]+\b){0,2}\s*$",
            ErrorMessage = RegexError),
            RequiredDisjunction(new string[] { WhitelistName, BlacklistName },
            ErrorMessage = DisjunctionError)]
        public string Blacklist { get; set; } = string.Empty;

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
            return inputList.Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
