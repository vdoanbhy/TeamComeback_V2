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
            defaultMembers.Add(new Member() { LastName = "Doe", FirstName = "Jane", Gender = Gender.Female, DoB = new DateTime(1982, 1, 1), Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-423-3213",DateOfLastStroke = new DateTime(2013, 1, 1) });
            defaultMembers.Add(new Member() { LastName = "Smith", FirstName = "John", Gender = Gender.Male, DoB = new DateTime(1981, 2, 1), Address = "456 ert str", City = "Annadale", State = State.VA, Zip = 22021, PhoneNumber = "123-456-3213", DateOfLastStroke = new DateTime(2017, 1, 1) });
            defaultMembers.Add(new Member() { LastName = "Lee", FirstName = "Rose", Gender = Gender.Female, DoB = new DateTime(1987, 3, 1), Address = "345 hfg str", City = "Falls Church", State = State.VA, Zip = 22034, PhoneNumber = "345-123-3213", DateOfLastStroke = new DateTime(2019, 1, 1) });
            defaultMembers.Add(new Member() { LastName = "Kim", FirstName = "Jennie", Gender = Gender.Female, DoB = new DateTime(1978, 4, 1), Address = "123 fsd str", City = "Springfield", State = State.VA, Zip = 22036, PhoneNumber = "678-123-3213", DateOfLastStroke = new DateTime(2020, 1, 1) });
            defaultMembers.Add(new Member() { LastName = "Long", FirstName = "Shane", Gender = Gender.Male, DoB = new DateTime(1983, 5, 1), Address = "348 asd str", City = "Fairfax", State = State.VA, Zip = 22035, PhoneNumber = "703-123-3213", DateOfLastStroke = new DateTime(2012, 1, 1) });
            defaultSessions.Add(new Session() {Name="2020-Session 5", DateStart= new DateTime(2020, 10, 19), DateEnd= new DateTime(2020, 12, 18)});
            defaultSessions.Add(new Session() { Name = "2020-Session 4", DateStart = new DateTime(2020, 8, 19), DateEnd = new DateTime(2020, 10, 18) });
            context.Members.AddRange(defaultMembers);
            context.Sessions.AddRange(defaultSessions);
            base.Seed(context);
        }
    }
}