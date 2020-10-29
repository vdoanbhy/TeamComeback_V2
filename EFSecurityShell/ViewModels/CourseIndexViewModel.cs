using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamComeback_V2.Models;

namespace TeamComeback_V2.ViewModels
{
    public class CourseIndexViewModel
    {
        public IPagedList<Course> Courses { get; set; }
        public string Search { get; set; }
        public string Session { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }
        
    }
}