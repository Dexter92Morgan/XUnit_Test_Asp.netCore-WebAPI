using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using XUnit_Test;

namespace Persons.Test
{

    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Persons.AddRange(
                new Person() { UserName = "CSHARP", UserPassword = "csharp", UserEmail="2123" , CreatedOn= DateTime.Now, IsDeleted = false},
                new Person() { UserName = "CSHARP2", UserPassword = "csharp2", UserEmail = "21232", CreatedOn = DateTime.Now, IsDeleted = false }

            );

            context.SaveChanges();
        }
    }
}
//let's open NuGet Package Manager for "Persons.Test" project and browse for "FluentAssertions" and installed it.
