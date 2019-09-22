using System;
using System.Collections.Generic;

namespace RadiologyStudentGradeBook.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassToStudent = new HashSet<ClassToStudent>();
            Grade = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }

        public virtual ICollection<ClassToStudent> ClassToStudent { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
