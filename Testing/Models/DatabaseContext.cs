using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Testing.Models
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Books> books { get; set; }

        [Table("Books")]
        public class Books
        {
            [Key]
            public int BookId { get; set; }
            public string BookName { get; set; }
            public string BookGenre { get; set; }
        }
    }
}