
namespace Examination_system
{
    public class Answer
    {
        #region Filds
        private int _AnswerId;
        private string? _AnswerText;
        #endregion
        #region properts
        public int answerid 
        {
            get
            {
                return _AnswerId;
            }
            set
            {
                if (value < 0||value==0)
                    throw new ArgumentException("Please Enter the negative number");
                _AnswerId = value;
            }
        }
        public string? answertext
        {
            get
            {
                return _AnswerText;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The text cannot be left empty.");
                _AnswerText = value;
            }
        }
        #endregion
        #region constarctor
        public Answer(int answerId, string? answerText)
        {
            answerid = answerId;
            answertext = answerText;
        }
        #region methods
        public override string ToString()
        {
            return $"{_AnswerId}==>{_AnswerText}";
        }
        #endregion
        #endregion
    }
}
