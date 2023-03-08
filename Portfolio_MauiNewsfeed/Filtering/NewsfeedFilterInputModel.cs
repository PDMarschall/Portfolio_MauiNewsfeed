using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Filtering
{
    public class NewsfeedFilterInputModel
    {
        private readonly char[] _separators = { ' ', ',', '.', ';', ':', '?', '!' };
                
        [Required(ErrorMessage = "Please input a title"), MinLength(1)]
        public string Title { get; set; } = string.Empty;

        [RegularExpression(@"^\b[a-zæøåA-ZÆØÅ]+\b(?:[ ,.;:?!]\s*[a-zæøåA-ZÆØÅ]+\b){0,2}$",
            ErrorMessage = "Vælg 1 - 3 ord."),
            RequireDisjunctive("Whitelist", "Blacklist",            
            ErrorMessage = "Please input at least one word in either list.")]

        public string Whitelist { get; set; } = string.Empty;

        [RegularExpression(@"^\b[a-zæøåA-ZÆØÅ]+\b(?:[ ,.;:?!]\s*[a-zæøåA-ZÆØÅ]+\b){0,2}$",
            ErrorMessage = "Vælg 1 - 3 ord."),
            RequireDisjunctive("Whitelist", "Blacklist",
            ErrorMessage = "Please input at least one word in either list.")]
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
