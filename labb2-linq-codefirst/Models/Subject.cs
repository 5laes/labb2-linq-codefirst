using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb2_linq_codefirst.Models
{
    internal class Subject
    {
        public Subject()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
