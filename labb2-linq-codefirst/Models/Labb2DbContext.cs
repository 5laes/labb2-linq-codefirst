using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace labb2_linq_codefirst.Models
{
    internal class Labb2DbContext : DbContext
    {
        public Labb2DbContext()
        {
        }

        public Labb2DbContext(DbContextOptions<Labb2DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = CLAES; Database = Labb2LinqCodeFirst; Encrypt = False; Trusted_Connection = True;");
        }
    }
}
