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
            IList<Course> defaultCourses = new List<Course>();
            IList<Member> defaultMembers = new List<Member>();
            defaultCourses.Add(new Course() { Name = "PT20-001", Terms = Terms.Fall, Year = "2020", Day = "MWF", Time = "5:00 pm - 7:30 pm", InstructorName = "John Doe", Cost = 35.99 });
            defaultCourses.Add(new Course() { Name = "PT20-002", Terms = Terms.Fall, Year = "2020", Day = "TThS", Time = "5:00 pm - 7:30 pm", InstructorName = "John Doe", Cost = 35.99 });
            defaultMembers.Add(new Member() { LastName = "Doe", FirstName = "Jane", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213",DateOfLastStroke = "01/01/2016"});
            context.Courses.AddRange(defaultCourses);
            context.Members.AddRange(defaultMembers);
            base.Seed(context);
        }
    }
}