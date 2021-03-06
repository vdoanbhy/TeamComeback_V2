﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamComeback_V2.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
        public string Time { get; set; }
        [Required]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }
        [Required]
        public double Cost { get; set; }
        public string Description { get; set; }
        public int? SessionID { get; set; }
        public virtual Session Session { get; set; }
        public virtual ICollection<Registar> Registars { get; set; }
    }
}