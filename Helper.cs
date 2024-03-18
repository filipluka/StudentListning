using StudentListning.Models;

namespace StudentListning
{
    public class Helper
    {
        private string firstname;
        private string lastName;
        private string street;
        private string city;
        private string country;
        private string universityName;
        private string universityCity;
        private string courseCredits;
        private string courseName;
        private string grade;
        private int idNbr;

        public Helper()
        {
        }
        public Student AddStudent()
        {
            Console.WriteLine("Please type Firstname: ");
            firstname = Console.ReadLine();
            if (string.IsNullOrEmpty(firstname))
            {
                Console.WriteLine("Name can't be empty! Input students name once more");
                firstname = Console.ReadLine();
            }
            Console.WriteLine("Please type Lastname: ");
            lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Last name can't be empty! Input students lastname once more");
                lastName = Console.ReadLine();
            }
            return new Student(firstname, lastName);
        }

        public Address AddAddress()
        {
            Console.WriteLine("Please type students street address: ");
            street = Console.ReadLine();
            if (string.IsNullOrEmpty(street))
            {
                Console.WriteLine("Address can't be empty! Input students street name once more");
                street = Console.ReadLine();
            }
            Console.WriteLine("Please type City: ");
            city = Console.ReadLine();
            if (string.IsNullOrEmpty(city))
            {
                Console.WriteLine("City can't be empty! Input students city name once more");
                city = Console.ReadLine();
            }
            Console.WriteLine("Please type Country: ");
            country = Console.ReadLine();
            if (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("Country can't be empty! Input your city name once more");
                country = Console.ReadLine();
            }
         return new Address(street, city, country);
        }

        public University AddUniversity()
        {
            Console.WriteLine("Please type university name: ");
            universityName = Console.ReadLine();
            if (string.IsNullOrEmpty(universityName))
            {
                Console.WriteLine("University name can't be empty! Input university name once more");
                universityName = Console.ReadLine();
            }
            Console.WriteLine("Please type university location city: ");
            universityCity = Console.ReadLine();
            if (string.IsNullOrEmpty(universityCity))
            {
                Console.WriteLine("University location can't be empty! Input university location once more");
            }
            return new University(universityName, universityCity);
        }

        public Course AddCourse()
        {
            Console.WriteLine("Please type program name: ");
            courseName = Console.ReadLine();
            if (string.IsNullOrEmpty(courseName))
            {
                Console.WriteLine("Course name can't be empty! Input program name once more");
                universityName = Console.ReadLine();
            }
            Console.WriteLine("Please type program credits: ");
            courseCredits = Console.ReadLine();
            if (string.IsNullOrEmpty(courseCredits))
            {
                Console.WriteLine("University course credits can't be empty! Input program credits once more");
            }
            return new Course(courseName, courseCredits);
        }

        public Grade AddGrade()
        {
            Console.WriteLine("Please type students current grade (A; B; C; D) : ");
            grade = Console.ReadLine();
            if (string.IsNullOrEmpty(grade))
            {
                Console.WriteLine("Current grade can't be empty! Input grade number once more");
                grade = Console.ReadLine();
            }
            return new Grade(grade);
        }

        internal int FindStudent()
        {
            idNbr = Convert.ToInt32(Console.ReadLine());
            if (string.IsNullOrEmpty(idNbr.ToString()))
            {
                Console.WriteLine("Input Id number once more if you want to find a student");
                idNbr = Convert.ToInt32(Console.ReadLine());
            }
            return idNbr;
        }

    }
}
