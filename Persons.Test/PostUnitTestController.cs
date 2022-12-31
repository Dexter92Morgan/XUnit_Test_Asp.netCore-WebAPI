using Business_Access_Layer.Services;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persons.Test
{
    public class PostUnitTestController
    {
        private PersonService repository;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; }
        public static string connectionString = "Host=localhost;Port=5432;User ID=postgres; Password=password;Database=Xunit;Pooling=true;";

        static PostUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(connectionString)
                .Options;
        }
        public PostUnitTestController()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new PersonService(context);

        }
    }


}
