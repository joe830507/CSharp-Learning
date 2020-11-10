namespace CSharpLearning
{
    class Student
    {
        public string Code { get; set; } = "C-000";

        public long ID { get; set; } = 0l;

        public string Name { get; set; } = "New Memeber";

        public string Course { get; set; } = "Visual Basic";

        public static void Demonstrate()
        {
            Student s = new Student();
            System.Console.WriteLine($"Code:{s.Code},ID:{s.ID},Name:{s.Name},Course:{s.Course}");
        }
    }
}
