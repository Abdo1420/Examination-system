namespace Examination_system
{
    internal class Subject
    {
        #region filds
        private int _id;
        private string? _name;
        private Exam _examOfSubject;


        #endregion

        #region properts
        public int Id { get; set; }
        public string? Name { get; set; }
        #endregion

        #region constarcetor
        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
            
        }
        #endregion
        #region methods
        public void CreateExam()
        {

        }
        #endregion
    }
}
