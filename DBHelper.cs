using Microsoft.EntityFrameworkCore;
using StudentListning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListning
{

    public class DBHelper
    {
        Helper helper;
        private string? newVal;

        public DBHelper()
        {
            helper = new Helper();
        }

        //Create
        internal void AddStudentToDB(DbContextOptions<StudentDBContext> contextOptions)
        {
            using (var context = new StudentDBContext(contextOptions))
            {
                //Create and save new student
                Console.WriteLine("Adding new student!");


                var student = helper.AddStudent();

                context.Database.EnsureCreated();
                context.Students.Add(student);

                student.Address = helper.AddAddress();
                student.University = helper.AddUniversity();
                student.Grade = helper.AddGrade();
                student.Course = helper.AddCourse();
                context.SaveChanges();

                Console.WriteLine("Student added to database ");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }

        //Read
        internal void ListAllStudents(DbContextOptions<StudentDBContext> contextOptions)
        {
            using (var context = new StudentDBContext(contextOptions))
            {
                context.Database.EnsureCreated();
                //Display all students from database
                var students = (from s in context.Students orderby s.LastName select s).Include(s => s.Grade).Include(u => u.University).Include(c => c.Course).ToList<Student>();
                

                if (students.Count != 0)
                {
                    Console.WriteLine("List all Students from the Database:");

                    foreach (var stdnt in students)
                    {
                        string name = stdnt.FirstName + " " + stdnt.LastName;
                        string gradeName =  stdnt.Grade.GradeName;
                        string course = stdnt.Course.CourseName;
                        string university = stdnt.University.UniversityName;
                        Console.WriteLine("ID: {0}, Name: {1}, University: {2}, Program: {3}, Grade: {4}", stdnt.StudentID, name, university, course, gradeName);
                    }
                   
                } else
                {
                    Console.WriteLine("The Database is empty:");
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        //Update
        internal void UpdateStudent(DbContextOptions<StudentDBContext> contextOptions)
        {
            Console.WriteLine("Please type ID number for student you want to update: ");

            var idToUpdate = helper.FindStudent();



            using (var context = new StudentDBContext(contextOptions))
            {
                var searchedStudent = context.Students.First(std => std.StudentID == idToUpdate);
                searchedStudent = showUpdateMeny(searchedStudent);

                context.Students.Update(searchedStudent);

                context.SaveChanges();
                Console.WriteLine("Student data updated in the Database");
            }
        }

        //Delete
        internal void RemoveStudentFromDB(DbContextOptions<StudentDBContext> contextOptions)
        {
            Console.WriteLine("Please type ID number for student you want to search or delete: ");

            var idToRemove = helper.FindStudent();

            using (var context = new StudentDBContext(contextOptions))
            {
                var searchedStudent = context.Students.First(std => std.StudentID == idToRemove);

                //context.Students.Remove(searchedStudent);
                context.Remove(searchedStudent);

                context.SaveChanges();
                Console.WriteLine("Student removed from the Database");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private Student showUpdateMeny(Student studentToUpdate)
        {
            string command = "";
            while (command != "exit")
            {
                Console.Clear();

                // Ask the user to choose an option.
                Console.WriteLine("Choose an parameter from the following list which you want to update in database:");
                Console.WriteLine("\ta - Students Firstname");
                Console.WriteLine("\tb - Students Lastname");
                Console.WriteLine("\tc - Students Grade");
                Console.WriteLine("\td - Students Street");
                Console.WriteLine("\te - Students City");
                Console.WriteLine("\tf - Students Country");
                Console.WriteLine("\tg - Students University name");
                Console.WriteLine("\th - Students University location");

                Console.WriteLine("Please enter your option: ");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "a":
                        studentToUpdate.FirstName = GetNewValue();
                        command = "exit";
                        break;
                    case "b":
                        studentToUpdate.LastName = GetNewValue();
                        command = "exit";
                        break;
                    case "c":
                        studentToUpdate.Grade.GradeName = GetNewValue(); ;
                        command = "exit";
                        break;
                    case "d":
                        studentToUpdate.Address.Street = GetNewValue();
                        command = "exit";
                        break;
                    case "e":
                        studentToUpdate.Address.City = GetNewValue();
                        command = "exit";
                        break;
                    case "f":
                        studentToUpdate.Address.Country = GetNewValue();
                        command = "exit";
                        break;
                    case "g":
                        studentToUpdate.University.UniversityName = GetNewValue();
                        command = "exit";
                        break;
                    case "h":
                        studentToUpdate.University.UniversityCity = GetNewValue();
                        command = "exit";
                        break;
                    default:
                        break;
                }
            }
            return studentToUpdate;
        }

        private string GetNewValue()
        {
            Console.WriteLine("Please type a new value you want to update: ");
            newVal = Console.ReadLine();
            return newVal;
        }


    }
}
