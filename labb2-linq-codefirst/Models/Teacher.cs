using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb2_linq_codefirst.Models
{
    internal class Teacher
    {
        public Teacher()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string TeacherName { get; set; } = null!;
        public int CourseId { get; set; }
        public int SubjectId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
