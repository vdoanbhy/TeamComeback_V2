using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamComeback_V2.Models
{
    public enum Terms
    {
        Fall,
        Spring,
        Summer
    }
    public class Course
    {
        public int CourseID { get; set; }
        [Required]
        public string Name { get; set; }
        public Terms? Terms { get; set; }
        public string Year { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }
        public double Cost { get; set; }
        public virtual ICollection<Registar> Registars { get; set; }
    }
}