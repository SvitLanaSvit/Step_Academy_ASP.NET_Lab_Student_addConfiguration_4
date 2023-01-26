namespace Lab_Student_addConfiguration_4.Model
{
    public class Student
    {
        public Profile? Profile { get; set; }
        public Academy? Academy { get; set; }
    }


    public class Profile
    {
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
    }

    public class Academy
    {
        public IEnumerable<string> Subjects { get; set; } = null!;
    }
}
