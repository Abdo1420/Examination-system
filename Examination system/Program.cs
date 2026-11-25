namespace Examination_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C_Sharp");
            subject.CreateExam();
            Console.Clear();
            subject.ExamOfSubject.ShowExam(); 
        }
    }
}
