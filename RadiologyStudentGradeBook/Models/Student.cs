using System;
using System.Collections.Generic;

namespace RadiologyStudentGradeBook.Models
{
    public partial class Student
    {
        public Student()
        {
            ClassToStudent = new HashSet<ClassToStudent>();
            Grade = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClassToStudent> ClassToStudent { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
