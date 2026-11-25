
namespace Examination_system
{
    public class Question
    {
        #region Filds
        private string? _Header;//راس السؤال
        private string? _Body;//السؤال نفسه
        private int _Mark;//درجة السؤال
        private Answer[] _AnswersList;//مصفوفة الاجابات
        private Answer _RightAnswer;//الاجابة الصحيحة
        #endregion

        #region properts
        public string? Header
        {
            set 
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("please enter the question");

                _Header=value;
            }
            get
            {
                return _Header;
            }
        }
        public string? Body
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("please enter the question");

                _Body = value;
            }
            get
            {
                return _Body;
            }
        }
        public int Mark
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The result cannot be negative.");

                _Mark=value;
            }
            get
            {
                return _Mark;
            }
        }
        public Answer[] AnswersList
        {
            set
            {
                if (value == null||value.Length==0)
                    throw new InvalidOperationException("Erorr,An empty value cannot be entered.");//لا يسمح بالاجابات الخالية
                HashSet<int> answersIds = new HashSet<int>(); 
                foreach(Answer answer in value)
                {
                    if (answer == null)
                    {
                        throw new ArgumentNullException("Erorr,value is null");//التاكد من وجود المصفوفة
                    }
                    else if (!answersIds.Add(answer.answerid))
                    {
                        throw new InvalidOperationException("Erorr,answerId is olredy exist");//للتاكد من عدم تكرار الرقم بتاع السؤال
                    }
                }
                _AnswersList= value;
            }
            get
            {
                return _AnswersList;
            }
        }
        public Answer RightAnswer
        {
            get
            {
                return _RightAnswer;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Incorrect answer");//لا يسمح بالاجابة الخالية
                if(_AnswersList==null|| _AnswersList.Length==0)
                    throw new ArgumentNullException("The answerlist is empty");//التاكد من وجود المصفوفة
                bool flag = false;
                for (int i = 0; i < _AnswersList.Length; i++)
                {
                    if (value.answerid == _AnswersList[i].answerid)
                        flag = true;
                }
                if (flag)
                    _RightAnswer = value;
                else
                    throw new InvalidOperationException("Incorrect answer");


            }
            
        }

        #endregion
        #region constarctor
        public Question(string? header, string? body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        } 
        public Question(string? header, string? body, int mark, Answer[] answersList, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswersList = answersList;
            RightAnswer = rightAnswer;

        } 
        #endregion

    }
}
