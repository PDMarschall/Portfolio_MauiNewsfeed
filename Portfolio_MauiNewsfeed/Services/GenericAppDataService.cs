using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Services
{
    public class GenericAppDataService<T> : IAppDataService<T> where T : IAppDataItem
    {
        public string EntityExtension { get; set; }
        public virtual async Task<List<T>> GetAllAsync()
        {
            List<T> entities = new List<T>();
            IEnumerable<string> filterFilenames = Directory.GetFiles(FileSystem.AppDataDirectory).Where(x => x.EndsWith(EntityExtension));

            foreach (string filterFilename in filterFilenames)
            {
                string rawData = await File.ReadAllTextAsync(filterFilename);
                entities.Add(JsonSerializer.Deserialize<T>(rawData));
            }

            return entities;
        }

        public virtual async Task SaveAsync(T entity)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, entity.Title + EntityExtension);
            var serializedData = JsonSerializer.Serialize(entity);
            await File.WriteAllTextAsync(fileName, serializedData);
        }

        public virtual void Delete(T entity)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, entity.Title + EntityExtension);
            File.Delete(fileName);
        }

    }
}
