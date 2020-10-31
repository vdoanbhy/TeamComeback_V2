using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamComeback_V2.Models
{
    public class Session
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Session Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}