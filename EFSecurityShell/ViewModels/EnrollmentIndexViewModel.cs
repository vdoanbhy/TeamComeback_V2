using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using TeamComeback_V2.Models;

namespace TeamComeback_V2.ViewModels
{
    public class EnrollmentIndexViewModel
    {
        public IPagedList<Registar> Registars { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Session { get; set; }
        [Display(Name = "Start Date")]
        public DateTime DateStart { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime DateEnd { get; set; }
        public string Search { get; set; }
    }
}