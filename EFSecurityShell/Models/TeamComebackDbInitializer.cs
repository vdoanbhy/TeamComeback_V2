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
            defaultMembers.Add(new Member() { LastName = "Doe", FirstName = "Jane", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213",DateOfLastStroke = "01/01/2016"});
            defaultMembers.Add(new Member() { LastName = "Smith", FirstName = "John", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2016" });
            defaultMembers.Add(new Member() { LastName = "Lee", FirstName = "Rose", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2016" });
            defaultMembers.Add(new Member() { LastName = "Kim", FirstName = "Jennie", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2016" });
            defaultMembers.Add(new Member() { LastName = "Long", FirstName = "Shane", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213", DateOfLastStroke = "01/01/2016" });
            defaultSessions.Add(new Session() {Name="2020-Session 5", DateStart="10/19/2020",DateEnd="12/18/2020" });
            defaultSessions.Add(new Session() { Name = "2020-Session 4", DateStart = "8/19/2020", DateEnd = "10/18/2020" });
            context.Members.AddRange(defaultMembers);
            context.Sessions.AddRange(defaultSessions);
            base.Seed(context);
        }
    }
}