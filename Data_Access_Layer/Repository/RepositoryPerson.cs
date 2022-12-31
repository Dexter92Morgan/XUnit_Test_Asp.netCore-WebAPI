using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer.Models;
using Data_Access_Layer.Interface;
using System.Threading.Tasks;
using Data_Access_Layer.Data;
using System.Linq;

namespace Data_Access_Layer.Repository
{
    public class RepositoryPerson : IRepository<Person>
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryPerson(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Person> Create(Person _object)
        {
            var obj = await _dbContext.Persons.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Person _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public List<Person> GetAll()
        {
            try
            {
                return _dbContext.Persons.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Person GetById(int Id)
        {
            return _dbContext.Persons.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(Person _object)
        {
            _dbContext.Persons.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
