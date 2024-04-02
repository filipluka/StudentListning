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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Read
        internal void ListAllStudents(DbContextOptions<StudentDBContext> contextOptions)
        {
            try
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
                            string gradeName = stdnt.Grade.GradeName;
                            string course = stdnt.Course.CourseName;
                            string university = stdnt.University.UniversityName;
                            Console.WriteLine("ID: {0}, Name: {1}, University: {2}, Program: {3}, Grade: {4}", stdnt.StudentID, name, university, course, gradeName);
                        }

                    }
                    else
                    {
                        Console.WriteLine("The Database is empty:");
                    }
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Update
        internal void UpdateStudent(DbContextOptions<StudentDBContext> contextOptions)
        {
            Console.WriteLine("Please type ID number for student you want to update: ");

            var idToUpdate = helper.FindStudent();


            try
            {
                using (var context = new StudentDBContext(contextOptions))
                {
                    var searchedStudent = context.Students.Include(a => a.Address).Include(s => s.Grade).Include(u => u.University).Include(c => c.Course).FirstOrDefault(std => std.StudentID == idToUpdate);
                    if (searchedStudent != null)
                    {
                        searchedStudent = showUpdateMeny(searchedStudent);

                        context.Students.Update(searchedStudent);

                        context.SaveChanges();
                        Console.WriteLine("Student data updated in the Database");
                    } else
                    {
                        Console.WriteLine("Student with this ID doesn't exist in the database");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Delete
        internal void RemoveStudentFromDB(DbContextOptions<StudentDBContext> contextOptions)
        {
            Console.WriteLine("Please type ID number for student you want to search or delete: ");

            var idToRemove = helper.FindStudent();

            try
            {
                using (var context = new StudentDBContext(contextOptions))
                {
                    var searchedStudent = context.Students.Include(a => a.Address).Include(s => s.Grade).Include(u => u.University).Include(c => c.Course).FirstOrDefault(std => std.StudentID == idToRemove);
                    if (searchedStudent != null)
                    {
                        var searchedStudentCourse = searchedStudent.Course;
                        var searchedStudentUniversity = searchedStudent.University;
                        var searchedStudentGrade = searchedStudent.Grade;
                        context.Remove(searchedStudent);
                        context.RemoveRange(searchedStudent.Address);
                        context.RemoveRange(searchedStudentUniversity);
                        context.RemoveRange(searchedStudentCourse);
                        context.RemoveRange(searchedStudentGrade);

                        context.SaveChanges();
                        Console.WriteLine("Student removed from the Database");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Student with this ID doesn't exist in the database");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
