using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.ViewModel
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CategoryName { get; set; }
    }
}

//Now let's create a folder name with ViewModel and create one class as PostViewModel.
//This is nothing but a model class which is responsible for getting the data from multiple sources.
//As we have to show data together for category and related post. So, that's why we have created
//this PostViewModel.
