using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Models
{

    public partial class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
