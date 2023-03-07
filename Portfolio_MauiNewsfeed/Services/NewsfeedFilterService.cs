using Portfolio_MauiNewsfeed.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Services
{
    public class NewsfeedFilterService
    {
        public List<NewsfeedFilter> GetAllNewsfeedFilters()
        {
            List<NewsfeedFilter> filters = new List<NewsfeedFilter>();
            IEnumerable<string> filterFilenames = Directory.GetFiles(FileSystem.AppDataDirectory).Where(x => x.EndsWith("filter.json"));

            foreach (string filterFilename in filterFilenames)
            {
                string rawData = File.ReadAllText(filterFilename);
                filters.Add(JsonSerializer.Deserialize<NewsfeedFilter>(rawData));
            }

            return filters;            
        }

        public void SaveNewsfeedFilter(NewsfeedFilter filter)
        {            
            string fileName = Path.Combine(FileSystem.AppDataDirectory, filter.Title + "filter.json");
            var serializedData = JsonSerializer.Serialize(filter);
            File.WriteAllText(fileName, serializedData);
        }

        public void DeleteFilter(NewsfeedFilter filter)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, filter.Title + "filter.json");
            File.Delete(fileName);
        }
    }
}
