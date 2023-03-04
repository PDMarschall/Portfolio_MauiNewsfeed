using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Configuration
{
    public class NewsfeedFilter
    {
        public string Title { get; set; }        
        public List<string> UserWhitelist { get; set; } = new List<string> { };
        public List<string> UserBlacklist { get; set; } = new List<string> { };
    }
}
