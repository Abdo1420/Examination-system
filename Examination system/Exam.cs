namespace Examination_system
{
    public abstract class Exam
    {
        #region filds
        protected int _timeOfExam;//وقت الامتحان
        protected int _numberOfQuestion;//عدد اسئلة الامتحان
        protected Question[] _questionsOfExam;//مصفوفة بالاسئلة الامتحان نفسها

        public int TimeOfExam
        {
            get
            {
                return _timeOfExam;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("A negative or zero value cannot be entered."); 

                _timeOfExam = value;
            }
        }
        public int NumberOfQuestion
        {
            get
            {
                return _numberOfQuestion;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("A negative or zero value cannot be entered.");

                _numberOfQuestion = value;
            }
        }

        public Question[] QuestionsOfExam { get => _questionsOfExam; set => _questionsOfExam = value; }

        #endregion
        #region methods
        public abstract void ShowExam();
        #endregion
    }
}
