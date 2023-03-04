using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Configuration
{
    public class SettingsService
    {
        public NewsfeedSettings LoadNewsfeedSettings()
        {
            return new NewsfeedSettings();
        }

        public void SaveNewsfeedSettings()
        {
            var temp = new NewsfeedSettings();
            temp.FilterFeeds = true;
            string json = JsonSerializer.Serialize(temp);

            // Get the directory where the executing assembly is located
            string assemblyDirectory = "C:\\Users\\PDMar\\source\\repos\\Portfolio_MauiNewsfeed\\Portfolio_MauiNewsfeed\\newsfeedSettings.json";

            // Combine the directory and filename to get the full filepath

            File.WriteAllText(assemblyDirectory, json);
        }
    }
}
