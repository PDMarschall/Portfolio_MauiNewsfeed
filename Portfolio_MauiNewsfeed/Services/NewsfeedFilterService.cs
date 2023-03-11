using Portfolio_MauiNewsfeed.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Services
{
    public class NewsfeedFilterService : GenericAppDataService<NewsfeedFilter>
    {
        public NewsfeedFilterService()
        {
            EntityExtension = "filter.json";
        }
    }
}
