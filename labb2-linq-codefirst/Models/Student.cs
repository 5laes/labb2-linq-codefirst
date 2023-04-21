using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb2_linq_codefirst.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Teacher? Teacher { get; set; }
    }
}
