using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamComeback_V2.Models;

namespace TeamComeback_V2.Data
{
    public class TeamComeback_V2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TeamComeback_V2Context() : base("name=TeamComeback_V2Context")
        {
            Database.SetInitializer <TeamComeback_V2Context>(new TeamComebackDbInitializer());
        }

        public System.Data.Entity.DbSet<TeamComeback_V2.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<TeamComeback_V2.Models.Registar> Registars { get; set; }

        public System.Data.Entity.DbSet<TeamComeback_V2.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<TeamComeback_V2.Models.Session> Sessions { get; set; }
    }
}
