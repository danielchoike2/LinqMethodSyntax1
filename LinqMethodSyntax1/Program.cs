using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace LinqMethod
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }
    }
    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }
    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 1, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 2, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 3, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 5, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };
            // Student GPA Collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };
            // Query A 
            var IDGPAS = from s in studentGPAList
                         orderby s.StudentID, s.GPA
                         select s;
            foreach (var s in IDGPAS)
            {
                Console.WriteLine($"ID: {s.StudentID} GPA: {s.GPA}");
            }
            Console.WriteLine("");
            // Query B
            var CLUBIDS = from s in studentClubList
                          orderby s.ClubName, s.StudentID
                          select s;
            foreach (var s in CLUBIDS)
            {
                Console.WriteLine($"Club Name: {s.ClubName} ID: {s.StudentID}");
            }
            Console.WriteLine("");

            // Query C 
            var GPACOUNT1 = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA <= 4.0);

            Console.WriteLine("The number of GPA's between 2.5 & 4.0 are: {0}", GPACOUNT1);

            Console.WriteLine("");

            // Query D 

            var TUITIONAVG = studentList.Average(s => s.Tuition);


            Console.WriteLine("The average of all the students' tuition is ${0}.00.", TUITIONAVG);
            Console.WriteLine("");

            // QUERY E 
            Console.WriteLine("List of students with the highest tuition:");
            Console.WriteLine();
            var MAXTUTITION = studentList.Where(s => s.Tuition == 5500.00).OrderByDescending(s => s.Tuition).ToList<Student>();

            foreach (var t in MAXTUTITION)
            {
                Console.WriteLine($"{t.StudentName}\nTuition: ${t.Tuition}.00 \nStudent Major: {t.Major}");
            }
            Console.WriteLine();

            // QUERY E 

            var innerJoin = studentList.Join(studentGPAList,
                student => student.StudentID,
                gpa => gpa.StudentID,
                (student, gpa) => new
                {
                    StudentName = student.StudentName,
                    StudentMajor = student.Major,
                    GPA = gpa.GPA
                });
            foreach (var s in innerJoin)
            {
                Console.WriteLine($"Name: {s.StudentName}   \t\tMajor: {s.StudentMajor}\t\tGPA: {s.GPA}");
                Console.WriteLine();
            }
            Console.WriteLine();
            //Query F 

            var innerJoin2 = studentList.Join(studentClubList,
                student => student.StudentID,
                                club => club.StudentID,
                                (student, club) => new
                                {
                                    StudentName = student.StudentName,
                                    ClubName = club.ClubName
                                });
            var innerjoin3 = innerJoin2.Where(s => s.ClubName == "Game");

            Console.WriteLine("The following students are in the Game Club:");

            foreach (var s in innerjoin3)
            {
                Console.WriteLine($"Name: {s.StudentName}");
                Console.WriteLine();
            }


        } // end of main 
    } // program 
} // Linq Method 