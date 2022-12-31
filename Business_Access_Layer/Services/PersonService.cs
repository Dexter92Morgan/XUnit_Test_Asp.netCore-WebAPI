using Data_Access_Layer.Data;
using Data_Access_Layer.Interface;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.Services
{
    //If there is any difficult-to-test code, for example, network, database, unit test, class, or method etc. just use attribute
    //"[ExcludeFromCodeCoverage]"

   // [ExcludeFromCodeCoverage]
    public class PersonService
    {
        private readonly IRepository<Person> _person;

        public PersonService(IRepository<Person> perosn)
        {
            _person = perosn;
        }

       
        //GET All Perso Details   
        public List<Person> GetAllPersons()
        {
            try
            {
                return _person.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Get Person Details By Person Id  
        public List<Person> GetPersonByUserId(int? UserId)
        {
            return _person.GetAll().Where(x => x.Id == UserId).ToList();
        }

      
        //Get Person by Person Name  
        public List<Person> GetPersonByUserName(string UserName)
        {
            return _person.GetAll().Where(x => x.UserEmail == UserName).ToList();
        }

        //Add Person  
        public async Task<Person> AddPerson(Person Person)
        {
            return await _person.Create(Person);
        }

        //Delete Person   
        public bool DeletePerson(int Id)
        {

            try
            {
                var DataList = _person.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _person.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }

        //Update Person Details  
      
        public bool UpdatePerson(Person person)
        {
            try 
            { 
               _person.Update(person);
           
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}


//for unit test
//https://www.dotnetcurry.com/aspnet-core/1414/unit-testing-aspnet-core
//https://www.hosting.work/aspnet-core-moq-xunit-unit-testing/
//http://www.mukeshkumar.net/articles/testing/crud-operations-unit-testing-in-aspnet-core-web-api-with-xunit

//for code coverage
//https://www.code4it.dev/blog/code-coverage-vs-2019-coverlet