using Business_Access_Layer.Services;
using Data_Access_Layer.Interface;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XUnit_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly IRepository<Person> _Person; // not requied bcz we are taking fron Bussiness layer class

        public PersonDetailsController(IRepository<Person> Person, PersonService ProductService)
        {
            _personService = ProductService;
            _Person = Person;

        }

        //Add Person  
        [HttpPost("AddPerson")]
        public async Task<Object> AddPerson([FromBody] Person person)
        {
            try
            {
                await _personService.AddPerson(person);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Delete Person  
        [HttpDelete("DeletePerson/id")]
        public bool DeletePerson(int ID)
        {
            try
            {
                _personService.DeletePerson(ID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update Person  
        [HttpPut("UpdatePerson")]
        public bool UpdatePerson(Person person)
        {
            try
            {
                _personService.UpdatePerson(person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //GET All Person by Name  
        [HttpGet("GetAllPersonByName")]
        public Object GetAllPersonByName(string UserEmail)
        {
            var data = _personService.GetPersonByUserName(UserEmail);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Person by Id 
        [HttpGet("GetAllPersonById")]
        public Object GetAllPersonById(int Id)
        {
            var data = _personService.GetPersonByUserId(Id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Person  
        [HttpGet("GetAllPersons")]
        public Object GetAllPersons()
        {
            var data = _personService.GetAllPersons();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
