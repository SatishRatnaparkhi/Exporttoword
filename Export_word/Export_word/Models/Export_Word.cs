using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Export_word.Models
{
    public class Export_Word : DbContext
    {
        public DbSet<StudentDetail> Studentrecord { get; set; }
    }
}