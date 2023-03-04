using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Configuration
{
    public class NewsfeedSettings
    {
        public bool EnableFilter { get; set; }

        public List<string> UserWhitelist { get; set; } = new List<string> { "den" };
        public List<string> UserBlacklist { get; set; } = new List<string> { };
    }
}
