using Course_Site.Models;
   
namespace Course_Site.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        context.Database.EnsureCreated();
       
       if (context.Students.Any())
        {
            return;   // DB has been seeded
        }

        var students = new Student[]
        {
            new Student{StudentId =1,StudentName="Carson Alexander",Email="carsonAq403@gmail.com",StudentBirthDate=DateTime.Parse("2005-09-01"),RegTime=DateTime.Parse("2022-05-02")},
            new Student{StudentId =2,StudentName="Meredith Alonso",Email="mereAlo03@gmail.com",StudentBirthDate=DateTime.Parse("2001-03-01"),RegTime=DateTime.Parse("2018-01-22")},
            new Student{StudentId =3,StudentName="Arturo Anand",Email="ArturoK56@gmail.com",StudentBirthDate=DateTime.Parse("1998-03-09"),RegTime=DateTime.Parse("2017-11-22")}
        };

        foreach (Student s in students)
        {
            context.Students.Add(s);
        }
        
        context.SaveChanges();

        if (context.Courses.Any())
        {
            return;   // DB has been seeded
        }

        var courses = new Courses[]
            {
            new Courses{CourseId=1,Title="Chemistry",CourseDescription="" +
            "Chemistry is the branch of science that deals" +
            " with the properties, composition," +
            " and structure of elements and compounds," +
            " how they can change, and the energy that is released or absorbed when they change.",DepartmentId = 1},
            new Courses{CourseId=2,Title="Microeconomics",CourseDescription="Microeconomics is a branch of mainstream economics that studies the behavior of individuals and firms in making decisions regarding" +
            " the allocation of scarce resources and the interactions among these individuals and firms.",DepartmentId = 2},
            new Courses{CourseId=3,Title="Macroeconomics",CourseDescription="Macroeconomics is the branch of economics" +
            " that deals with the structure, performance, behavior, and decision-making" +
            " of the whole, or aggregate, economy. The two main areas of macroeconomic" +
            " research are long-term economic growth and shorter-term business cycles.",DepartmentId=2}

            };
        foreach (Courses c in courses)
        {
            context.Courses.Add(c);
        }
        context.SaveChanges();

        if (context.Departments.Any())
        {
            return;   // DB has been seeded
        }
        var departments = new Department[]
        {
            new Department{ DepartmentId =1, Name="Science",Budget=10000000,StartDate=DateTime.Parse("1991-09-11"),InstructorId= 1},
            new Department{ DepartmentId =2, Name="Economics",Budget=1370043,StartDate=DateTime.Parse("1995-04-01"),InstructorId= 2}

        };
        foreach (Department d in departments)
        {
            context.Departments.Add(d);
        }
        context.SaveChanges();
        if (context.Instructors.Any())
        {
            return;   // DB has been seeded
        }
        var instructors = new Instructor[]
        {
            new Instructor{InstructorId = 1, InstructorName="Dmitro Mendeleev", HireDate=DateTime.Parse("1850-02-08") },
            new Instructor{InstructorId = 2, InstructorName="Adam Smith", HireDate=DateTime.Parse("1754-06-16") }
        };
        foreach (Instructor i in instructors)
        {
            context.Instructors.Add(i);
        }
        context.SaveChanges();
        if (context.OfficeAssignments.Any())
        {
            return;   // DB has been seededs
        }
        var office = new OfficeAssignment[]
        {
            new OfficeAssignment{InstructorId = 1, Location="Madrid"},
            new OfficeAssignment{InstructorId = 2, Location="London"},
        };
        foreach (OfficeAssignment o in office)
        {
            context.OfficeAssignments.Add(o);
        }
        context.SaveChanges();


    }
}
        
    

