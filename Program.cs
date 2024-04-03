namespace ÖvningGenerics20240403
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentList = new StudentCollection();

            studentList.Add(new Student(1, 75, 88));
            studentList.Add(new Student(2, 77, 92));
            studentList.Add(new Student(3, 60, 85));
            studentList.Add(new Student(4, 75, 88));



            Display(studentList);
            Console.WriteLine("-------------------------");


            studentList.Remove(new Student(4, 75, 88));

            Display(studentList );
        }



        public static void Display(StudentCollection students)
        {
            Console.WriteLine("\nID:\tGrade:\tTotal:");

            foreach (Student student in students)
            {
                Console.WriteLine("{0}\t{1}\t{2}",
                student.ID.ToString(), student.Grade.ToString(), student.Total.ToString());
              
            }
        }
    }
}
