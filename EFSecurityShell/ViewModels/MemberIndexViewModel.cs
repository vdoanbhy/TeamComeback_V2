using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamComeback_V2.Models;

namespace TeamComeback_V2.ViewModels
{
    public class MemberIndexViewModel
    {
        public IPagedList<Member> Members { get; set; }
        public string Search { get; set; }
    }
}