using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamComeback_V2.Data;

namespace TeamComeback_V2.Models
{
    public class TeamComebackDbInitializer : DropCreateDatabaseIfModelChanges<TeamComeback_V2Context>
    {
        protected override void Seed(TeamComeback_V2Context context)
        {
           
            IList<Member> defaultMembers = new List<Member>();
            IList<Session> defaultSessions = new List<Session>();
            defaultMembers.Add(new Member() { LastName = "Doe", FirstName = "Jane", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213",DateOfLastStroke = "01/01/2013"});
            defaultMembers.Add(new Member() { LastName = "Smith", FirstName = "John", Gender = Gender.Male, DoB = "02/01/1981", Address = "456 ert str", City = "Annadale", State = State.VA, Zip = 22021, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2017" });
            defaultMembers.Add(new Member() { LastName = "Lee", FirstName = "Rose", Gender = Gender.Female, DoB = "03/01/1987", Address = "345 hfg str", City = "Falls Church", State = State.VA, Zip = 22034, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2019" });
            defaultMembers.Add(new Member() { LastName = "Kim", FirstName = "Jennie", Gender = Gender.Female, DoB = "04/01/1978", Address = "123 fsd str", City = "Springfield", State = State.VA, Zip = 22036, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2020" });
            defaultMembers.Add(new Member() { LastName = "Long", FirstName = "Shane", Gender = Gender.Male, DoB = "05/01/1983", Address = "348 asd str", City = "Fairfax", State = State.VA, Zip = 22035, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2012" });
            defaultSessions.Add(new Session() {Name="2020-Session 5", DateStart="10/19/2020",DateEnd="12/18/2020" });
            defaultSessions.Add(new Session() { Name = "2020-Session 4", DateStart = "8/19/2020", DateEnd = "10/18/2020" });
            context.Members.AddRange(defaultMembers);
            context.Sessions.AddRange(defaultSessions);
            base.Seed(context);
        }
    }
}