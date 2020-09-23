using System;
namespace Movie.Controllers
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

        public Student(int id, string name, int age)
        {
            StudentId = id;
            StudentName = name;
            Age = age;
        }
    }
}
