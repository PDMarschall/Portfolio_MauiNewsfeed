using Portfolio_MauiNewsfeed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Filtering
{
    public class NewsfeedFilter : IAppDataItem
    {
        public string Title { get; set; }

        public List<string> UserWhitelist { get; set; } = new List<string>();

        public List<string> UserBlacklist { get; set; } = new List<string>();

        public void CopyFilterValues(NewsfeedFilter filter)
        {
            if (filter != null)
            {
                this.Title = filter.Title;
                this.UserWhitelist = filter.UserWhitelist;
                this.UserBlacklist = filter.UserBlacklist;
            }
        }
    }
}
