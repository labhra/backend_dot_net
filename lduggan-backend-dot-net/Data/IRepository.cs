using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lduggan_backend_dot_net.Data
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll<U>(string path);
        public Task<T> Get(string path, int id);
        public Task<T> Add(T entity, string path);
        public Task<T> Update(T entity, string path, int id);
        public void Delete(int id, string path);
    }
}
