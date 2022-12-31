using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer.Data;
using Data_Access_Layer.Models;

namespace CoreServices.Test
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

            context.Categories.AddRange(
                new Category() { Name = "CSHARP", Slug = "csharp" },
                new Category() { Name = "VISUAL STUDIO", Slug = "visualstudio" },
                new Category() { Name = "ASP.NET CORE", Slug = "aspnetcore" },
                new Category() { Name = "SQL SERVER", Slug = "sqlserver" }
            );

            context.Posts.AddRange(
                new Post() { Title = "Test Title 1", Description = "Test Description 1", CategoryId = 2, CreatedDate = DateTime.Now },
                new Post() { Title = "Test Title 2", Description = "Test Description 2", CategoryId = 3, CreatedDate = DateTime.Now }
            );
            context.SaveChanges();
        }

    }
}
