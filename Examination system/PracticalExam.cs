
namespace Examination_system
{
    public class Practical_Exam : Exam
    {
        #region constractor
        public Practical_Exam(int time,int numberqustion)
        {
             TimeOfExam = time;
             NumberOfQuestion = numberqustion;
        }

        public override void ShowExam()
        {
            
        }
        #endregion
    }
}
