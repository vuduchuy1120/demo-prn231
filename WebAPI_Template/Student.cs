namespace WebAPI_Template
{
    public class Student
    {
        public string code { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public Student()
        {
            
        }

        public Student(string code, string name, int age)
        {
            this.code = code;
            this.name = name;
            this.age = age;
        }

        public override string? ToString()
        {
            
            return code + "\t" + name + "\t" + age;
        }

    }
}
