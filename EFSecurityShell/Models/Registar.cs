using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamComeback_V2.Models
{
    public enum Attendance
    {
        Present,
        Absence
    }
    public class Registar
    {
        public int RegistarID { get; set; }
        [Display(Name ="Last Name")]
        public int MemberID { get; set; }
        [Display(Name = "Course")]
        public int CourseID { get; set; }
        public Attendance? Attendance { get; set; }
        [Display(Name = "Enrollment Date")]
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public virtual Member Member { get; set; }
        public virtual Course Course { get; set; }
    }
}