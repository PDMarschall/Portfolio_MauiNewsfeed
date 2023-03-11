using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Services
{
    public abstract class GenericAppDataService<T> : IAppDataService<T> where T : IAppDataItem
    {
        public string EntityExtension { get; set; }

        public virtual async Task<List<T>> GetAllAsync()
        {
            if (EntityExtension == string.Empty)
                throw new InvalidOperationException("Service requires an Entity Extension to be defined for getting files.");

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
            if (EntityExtension == string.Empty)
                throw new InvalidOperationException("Service requires an Entity Extension to be defined for saving files.");

            string fileName = Path.Combine(FileSystem.AppDataDirectory, entity.Title + EntityExtension);
            var serializedData = JsonSerializer.Serialize(entity);
            await File.WriteAllTextAsync(fileName, serializedData);
        }

        public virtual void Delete(T entity)
        {
            if (EntityExtension == string.Empty)
                throw new InvalidOperationException("Service requires an Entity Extension to be defined for deleting files.");

            string fileName = Path.Combine(FileSystem.AppDataDirectory, entity.Title + EntityExtension);
            File.Delete(fileName);
        }
    }
}
