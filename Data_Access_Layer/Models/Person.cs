using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Models
{
    [Table("Persons", Schema = "dbo")]/// for separate schma in db and separate table
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "UserPassword")]
        public string UserPassword { get; set; }
        [Required]
        [Display(Name = "UserEmail")]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
