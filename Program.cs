using Microsoft.EntityFrameworkCore;

namespace StudentListning
{
    internal class Program
    {
        private static DBHelper helper = new DBHelper();
        private static DbContextOptions<StudentDBContext> contextOptions;

        static void Main(string[] args)
        {
          contextOptions = new DbContextOptionsBuilder<StudentDBContext>()
  .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\filip\Projects\StudentListing\Data\local_db.mdf;Integrated Security=True;Connect Timeout=30")
  .Options;
            helper = new DBHelper();
            ShowMeny();
        }

        private static void ShowMeny()
        {
            string command = "";
            while (command != "exit")
            {
                Console.Clear();
                // Display title as the C# console adressbok app.
                Console.WriteLine("***********************************");
                Console.WriteLine("Console Student list application in C#\r");
                Console.WriteLine("***********************************\n");

                // Ask the user to choose an option.
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add student");
                Console.WriteLine("\tb - Remove student");
                Console.WriteLine("\tc - List students");
                Console.WriteLine("\td - Update students data");

                Console.WriteLine("Please enter your option: ");
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "a":
                        helper.AddStudentToDB(contextOptions);
                        break;
                    case "b":
                        helper.RemoveStudentFromDB(contextOptions);
                        break;
                    case "c":
                        helper.ListAllStudents(contextOptions);
                        break;
                    case "d":
                        helper.UpdateStudent(contextOptions);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
