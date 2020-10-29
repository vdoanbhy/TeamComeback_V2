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
        public string Member { get; set; }
        [Display(Name = "Day")]
        public string Course { get; set; }
        public string Session { get; set; }
        public string Search { get; set; }
    }
}