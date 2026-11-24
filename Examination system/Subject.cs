namespace Examination_system
{
    public class Subject
    {
        #region filds
        private int _id;
        private string? _name;
        private Exam _examOfSubject;


        #endregion

        #region properts
        public int Id { get; set; }
        public string? Name { get; set; }
        public Exam ExamOfSubject { get => _examOfSubject; set => _examOfSubject = value; }
        #endregion

        #region constarcetor
        public Subject(int id, string? name)
        {
            Id = id;
            Name = name;
            
        }
        #endregion
        #region methods
        public void CreateExam()
        {
           
            Console.WriteLine("Enter the type of exam 1: Practical, 2: Final");
            int examType = 0;
            while (true)//لعدم ادخال نوع امتحان غير صحيح
            {
                if (int.TryParse(Console.ReadLine(), out  examType) && (examType == 1 || examType == 2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Practical or 2 for Final.");
                }
            }
            
            
            Console.WriteLine("Enter the time of exam in minutes 30-180:");
            int time = 0;
            while (true)//لعدم ادخال وقت امتحان غير صحيح
            {
                if (int.TryParse(Console.ReadLine(), out time) && time >= 30 && time <= 180)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a time between 30 and 180 minutes.");
                }
            }
            Console.WriteLine("Enter the number of questions:");
            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());
            if (examType == 1)
            {
                ExamOfSubject = new Practical_Exam(time, numberOfQuestions);
            }
            else
            {
                ExamOfSubject = new Final_Exam(time, numberOfQuestions);
            }
            Console.Clear();
            for(int i = 0; i < numberOfQuestions; i++)//للوب على عدد الاسئلة وادخال كل سؤال
            {
                int questionType = 0;
                if (examType == 2)
                {
                    Console.WriteLine($"Enter the type of question {i + 1} 1: Multiple Choice, 2: True/False");
                    while (true)//لعدم ادخال نوع سؤال غير صحيح
                    {
                        if (examType == 2)
                        {
                            if (int.TryParse(Console.ReadLine(), out  questionType) && (questionType == 1 || questionType == 2))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 for Multiple Choice or 2 for True/False.");
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine($"Enter the header of question {i + 1}:");
                string? header = Console.ReadLine();
                Console.WriteLine($"Enter the body of question {i + 1}:");
                string? body = Console.ReadLine();
                Console.WriteLine($"Enter the mark of question {i + 1}:");
                int mark = Convert.ToInt32(Console.ReadLine());
                int sizeOfAnswers = 0;//عدد الاجوبة لاضفتها الي حجم الارراي
                if (examType == 1|| questionType==1)
                {
                    sizeOfAnswers = 4;
                }
                else 
                {
                    sizeOfAnswers = 2;
                }
              
                Answer[] answersList = new Answer[sizeOfAnswers];//الارراي الخاص بالاجوبة
                for (int j = 0; j < sizeOfAnswers; j++)
                {
                    Console.WriteLine($"Enter the text of answer {j + 1} for question {i + 1}:");
                    string? answerText = Console.ReadLine();
                    answersList[j] = new Answer(j + 1, answerText);
                }
                Console.WriteLine($"Enter the number of the correct answer for question {i + 1} (1-{sizeOfAnswers}):");
                int rightAnswerId = Convert.ToInt32(Console.ReadLine());
                Answer rightAnswer = answersList[rightAnswerId - 1];
                Question question = new Question(header,body,mark,answersList,rightAnswer);
                ExamOfSubject.QuestionsOfExam[i] = question;
            }
        }
        #endregion
    }
}
