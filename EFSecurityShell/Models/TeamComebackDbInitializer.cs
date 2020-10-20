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
            defaultCourses.Add(new Course() { Name = "L1-M-World Games 1", Terms = Terms.Fall, Year = "2020", Day = DayOfWeek.Monday, Time = "10:00 am - 10:20 am", InstructorName = "John Doe", Cost = 19.99, Description = "Play World Game" });
            defaultCourses.Add(new Course() { Name = "L1-Escape This", Terms = Terms.Fall, Year = "2020", Day = DayOfWeek.Monday, Time = "10:20 am - 10:40 am", InstructorName = "Zoe Doe", Cost = 19.99, Description = "Play World Game" });
            defaultCourses.Add(new Course() { Name = "L1-Presentation Group", Terms = Terms.Fall, Year = "2020", Day = DayOfWeek.Monday, Time = "10:40 am - 10:00 am", InstructorName = "Dave Doe", Cost = 19.99, Description = "Play World Game" });
            defaultCourses.Add(new Course() { Name = "L2-Select Topics 2", Terms = Terms.Fall, Year = "2020", Day = DayOfWeek.Tuesday, Time = "10:00 am - 10:20 am", InstructorName = "Jim Doe", Cost = 25.99, Description = "Play World Game" });
            defaultCourses.Add(new Course() { Name = "L2-Number Crunchers", Terms = Terms.Fall, Year = "2020", Day = DayOfWeek.Tuesday, Time = "10:20 am - 10:40 am", InstructorName = "Joe Doe", Cost = 25.99, Description = "Play World Game" });
            defaultCourses.Add(new Course() { Name = "AL-Slow Road to Better", Terms = Terms.Fall, Year = "2020", Day = DayOfWeek.Tuesday, Time = "10:40 am - 11:00 am", InstructorName = "Amy Doe", Cost = 15.99, Description = "Play World Game" });
            defaultMembers.Add(new Member() { LastName = "Doe", FirstName = "Jane", Gender = Gender.Female, DoB = "01/01/1980", Address = "123 abc str", City = "Fairfax", State = State.VA, Zip = 22031, PhoneNumber = "123-123-3213",DateOfLastStroke = "01/01/2016"});
            context.Courses.AddRange(defaultCourses);
            context.Members.AddRange(defaultMembers);
            base.Seed(context);
        }
    }
}