using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamComeback_V2.Models;

namespace TeamComeback_V2.ViewModels
{
    public class SessionsIndexViewModel
    {
        public IPagedList<Session> Sessions { get; set; }
        public string Search { get; set; }
    }
}