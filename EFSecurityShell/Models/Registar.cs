using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamComeback_V2.Models
{
    public class Registar
    {
        public int RegistarID { get; set; }
        public int MemberID { get; set; }
        public int CourseID { get; set; }
        public virtual Member Member { get; set; }
        public virtual Course Course { get; set; }
    }
}