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
        private const string FilterExtension = "filter.json";

        public async Task<List<NewsfeedFilter>> GetAllFiltersAsync()
        {
            List<NewsfeedFilter> filters = new List<NewsfeedFilter>();
            IEnumerable<string> filterFilenames = Directory.GetFiles(FileSystem.AppDataDirectory).Where(x => x.EndsWith(FilterExtension));

            foreach (string filterFilename in filterFilenames)
            {
                string rawData = await File.ReadAllTextAsync(filterFilename);
                filters.Add(JsonSerializer.Deserialize<NewsfeedFilter>(rawData));
            }

            return filters;            
        }

        public async Task SaveFilterAsync(NewsfeedFilter filter)
        {            
            string fileName = Path.Combine(FileSystem.AppDataDirectory, filter.Title + FilterExtension);
            var serializedData = JsonSerializer.Serialize(filter);
            await File.WriteAllTextAsync(fileName, serializedData);
        }

        public void DeleteFilter(NewsfeedFilter filter)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, filter.Title + FilterExtension);
            File.Delete(fileName);
        }
    }
}
