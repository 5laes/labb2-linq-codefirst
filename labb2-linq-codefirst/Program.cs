using labb2_linq_codefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace labb2_linq_codefirst
{
    internal class Program
    {
        static Labb2DbContext context = new Labb2DbContext();
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.Write("\n\tVad vill du göra?" +
                "\n\t[1]Visa mattelärare" +
                "\n\t[2]Visa studenter och deras lärare" +
                "\n\t[3]Kolla om Programmering 1 finns" +
                "\n\t[4]ändra Prog2 till OOP" +
                "\n\t[5]Ändra studenters lärare från Anas till Reidar" +
                "\n\t[6]Stäng av" +
                "\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    GetMathTeatchers();
                    Console.ReadLine();
                    Menu();
                    break;

                case 2:
                    GetStudentsWithTeachers();
                    Console.ReadLine();
                    Menu();
                    break;    
                    
                case 3:
                    CheckSubjContainProg1();
                    Console.ReadLine();
                    Menu();
                    break;

                case 4:
                    ChangeProg2ToOOP();
                    Console.ReadLine();
                    Menu();
                    break;

                case 5:
                    ChangeTeacherFromAnasToReidar();
                    Console.ReadLine();
                    Menu();
                    break;

                case 6:
                    break;

                default:
                    Menu();
                    break;
            }
        }

        public static void GetMathTeatchers()
        {
            var mathTeachers = context.Teachers.
                Where(x => x.SubjectId == 8);

            Console.Write($"\n\tMath Teachers:");
            foreach (var teacher in mathTeachers)
            {
                Console.Write($"\n\t{teacher.TeacherName}");
            }
        }

        public static void GetStudentsWithTeachers()
        {
            var studentsWithTheirTeachers = context.Students.
               Join(context.Teachers,
               student => student.TeacherId,
               teacher => teacher.Id,
               (stud, teach) => new
               {
                   studentName = stud.StudentName,
                   teacherName = teach.TeacherName
               });
            foreach (var item in studentsWithTheirTeachers)
            {
                Console.Write($"\n\tElev: {item.studentName}, Lärare: {item.teacherName}");
            }
        }

        public static void CheckSubjContainProg1()
        {
            var containsProg1 = context.Subjects.
                Select(x => x.SubjectName).
                Contains("Programmering 1");
            Console.Write($"\n\tDoes subjects contain Programming 1: {containsProg1}");
        }

        public static void ChangeProg2ToOOP()
        {
            var containsProg2 = context.Subjects.
                Where(x => x.SubjectName == "Programmering 2");
            foreach (var item in containsProg2)
            {
                string oldName = item.SubjectName;
                item.SubjectName = "OOP";
                Console.Write($"\n\t{oldName} has been changed to {item.SubjectName}");
            }
        }

        public static void ChangeTeacherFromAnasToReidar()
        {
            (from student in context.Students
             where student.TeacherId == 8
             select student).
             ToList().
             ForEach(x => x.TeacherId = 9);
            context.SaveChanges();
        }

        public static void AddData()
        {
            //context.Courses.Add(new Course { CourseName = "SUT21" });
            //context.Courses.Add(new Course { CourseName = "SUT22" });
            //context.Courses.Add(new Course { CourseName = "SUT23" });
            //context.SaveChanges();

            //context.Subjects.Add(new Subject { SubjectName = "Programmering 2" });
            //context.Subjects.Add(new Subject { SubjectName = "Matte" });
            //context.Subjects.Add(new Subject { SubjectName = "Webbdesign" });
            //context.SaveChanges();

            //context.Teachers.Add(new Teacher { TeacherName = "Anas", CourseId = 7, SubjectId = 7 });
            //context.Teachers.Add(new Teacher { TeacherName = "Reidar", CourseId = 8, SubjectId = 8 });
            //context.Teachers.Add(new Teacher { TeacherName = "Tobias", CourseId = 9, SubjectId = 9 });
            //context.Teachers.Add(new Teacher { TeacherName = "Magnus", CourseId = 7, SubjectId = 8 });
            //context.SaveChanges();

            //context.Students.Add(new Student { StudentName = "Claes", CourseId = 8, TeacherId = 8 });
            //context.Students.Add(new Student { StudentName = "Alvin", CourseId = 8, TeacherId = 9 });
            //context.Students.Add(new Student { StudentName = "Henrik", CourseId = 8, TeacherId = 10 });
            //context.Students.Add(new Student { StudentName = "Alex", CourseId = 7, TeacherId = 11 });
            //context.Students.Add(new Student { StudentName = "Kristian", CourseId = 7, TeacherId = 8 });
            //context.Students.Add(new Student { StudentName = "Linus", CourseId = 7, TeacherId = 9 });
            //context.Students.Add(new Student { StudentName = "Robin", CourseId = 9, TeacherId = 10 });
            //context.Students.Add(new Student { StudentName = "Erik", CourseId = 9, TeacherId = 11 });
            //context.Students.Add(new Student { StudentName = "Charlie", CourseId = 9, TeacherId = 8 });
            //context.Students.Add(new Student { StudentName = "Johan", CourseId = 7, TeacherId = 9 });
            //context.Students.Add(new Student { StudentName = "Jimmy", CourseId = 8, TeacherId = 10 });
            //context.Students.Add(new Student { StudentName = "Jerry", CourseId = 9, TeacherId = 11 });
            //context.SaveChanges();
        }
    }
}