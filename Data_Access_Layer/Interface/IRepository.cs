using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interface
{
    public interface IRepository<T>  // where T is Model Class(Person)
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public List<T> GetAll();

        public T GetById(int Id);

        public void Delete(T _object);
    }
}
