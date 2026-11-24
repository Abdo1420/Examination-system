
namespace Examination_system
{
    public class Final_Exam : Exam
    {
       public Final_Exam(int time, int numberqustion)
        {
            TimeOfExam = time;
            NumberOfQuestion = numberqustion;
            QuestionsOfExam = new Question[numberqustion];
        }
        public override void ShowExam()
        {
            if (QuestionsOfExam == null || QuestionsOfExam.Length == 0)
            {
                throw new ArgumentNullException("The exam questions are empty.");
                return;
            }
            Console.WriteLine("Do you want to start the exam? (y/n)");
            string? startExam = Console.ReadLine();
            if (startExam != "y" && startExam != "Y")
            {
                Console.WriteLine("Exam cancelled.");
                return;
            }
            DateTime startTime = DateTime.Now;
            int[] answers = new int[QuestionsOfExam.Length];
            int examScore = 0;
            int markStudent = 0;
            for(int i = 0; i < QuestionsOfExam.Length; i++)
            {
               
                Console.WriteLine($"Header: {QuestionsOfExam[i].Header}--- Mark: {QuestionsOfExam[i].Mark}");
                Console.WriteLine($"Body: {QuestionsOfExam[i].Body}");
                Console.WriteLine("Answers:");
                for (int j = 0; j < QuestionsOfExam[i].AnswersList.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {QuestionsOfExam[i].AnswersList[j].answertext}");
                }
                Console.Write("Enter the number of your answer: ");
                int answerId;
                while (true)
                {
                 answerId = Convert.ToInt32(Console.ReadLine()) - 1;
                    if(answerId < 0 || answerId >= QuestionsOfExam[i].AnswersList.Length)
                    {
                        Console.WriteLine("Invalid answer number. Please try again.");
                        Console.Write("Enter the number of your answer: ");
                        
                    }
                    else
                    {
                    answers[i] = answerId;
                        break;
                    }
                }
                
                if (QuestionsOfExam[i].AnswersList[answerId].answerid == QuestionsOfExam[i].RightAnswer.answerid)
                {
                    markStudent += QuestionsOfExam[i].Mark;
                }
                examScore += QuestionsOfExam[i].Mark;
            }
            TimeSpan endTime = DateTime.Now - startTime;
            Console.Clear();
            foreach (var question in QuestionsOfExam)
            {
                Console.WriteLine($"Question: {question.Header}");
                Console.WriteLine($"Your Answer: {question.AnswersList[answers[Array.IndexOf(QuestionsOfExam, question)]]?.answertext}");
                Console.WriteLine($"Correct Answer: {question.RightAnswer?.answertext}");
                Console.WriteLine("-----------------");
            }
            Console.WriteLine($"Your total score: {markStudent}/{examScore}");
                Console.WriteLine($"Exam time: {endTime.TotalMinutes:F2} minutes");
        }
    }
}
