using System;
using System.Collections.Generic;

namespace RadiologyStudentGradeBook.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }
        public string Type { get; set; }
        public int TotalPointsPossible { get; set; }
        public int PointsEarned { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
