using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Services
{
    public interface IAppDataService<T>
    {
        string EntityExtension { get; set; }
        void Delete(T entity);
        Task<List<T>> GetAllAsync();
        Task SaveAsync(T entity);
    }
}
