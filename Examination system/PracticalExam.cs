
namespace Examination_system
{
    public class Practical_Exam : Exam
    {
        #region constractor
        public Practical_Exam(int time, int numberqustion)
        {
            TimeOfExam = time;
            NumberOfQuestion = numberqustion;
            QuestionsOfExam= new Question[numberqustion];
        }

        public override void ShowExam()
        {
            if (QuestionsOfExam == null || QuestionsOfExam.Length == 0)
            {
                throw new ArgumentException("The exam has no questions.");
                return;
            }
            Console.WriteLine("Do you want to start the exam? (y/n)");
            string? startExam = Console.ReadLine();
            if (startExam != "y"&& startExam != "Y")
            {
                Console.WriteLine("Exam cancelled.");
                return;
            }
            DateTime startTime = DateTime.Now;
            int[] answers = new int[_questionsOfExam.Length];
            for (int i = 0; i < _questionsOfExam.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {_questionsOfExam[i].Header}--- Mark: {_questionsOfExam[i].Mark}");
                Console.WriteLine(_questionsOfExam[i].Body);
                if (_questionsOfExam[i].AnswersList == null || _questionsOfExam[i].AnswersList.Length == 0)
                {
                    throw new ArgumentException("The question has no answers.");
                    return;
                }
                for (int j = 0; j < _questionsOfExam[i].AnswersList.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {_questionsOfExam[i].AnswersList[j].answertext}");
                }
                Console.Write($"Enter your answer (1-{_questionsOfExam[i].AnswersList.Length}): ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int answer) && answer >= 1 && answer <= _questionsOfExam[i].AnswersList.Length)
                    {
                        answers[i] = answer-1;
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect answer. Please try again.");
                        Console.Write($"Enter your answer (1-{_questionsOfExam[i].AnswersList.Length}): ");
                    }

                    
                }
            }
            TimeSpan endTime = DateTime.Now - startTime;
            Console.Clear();
            Console.WriteLine("Correct answers:");
            foreach (var question in _questionsOfExam)
            {
                Console.WriteLine($"Question: {question.Header}");
                Console.WriteLine($"Correct Answer: {question.RightAnswer?.answertext}");
                Console.WriteLine($"Your Answer: {question.AnswersList[answers[Array.IndexOf(_questionsOfExam, question)]]?.answertext}");
                Console.WriteLine("-----------------");
            }
                Console.WriteLine($"Exam Time: {endTime.TotalMinutes:F2} minutes");
        #endregion
        }
    }
}
