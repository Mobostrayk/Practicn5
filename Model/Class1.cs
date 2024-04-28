using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Exam : INotifyPropertyChanged
    {
        private string _nameofdiscipline = "";
        private string _nameofprofessor = "";
        private string _difficulty = "" ;
        private DateTime _dateofexam = DateTime.Today;

        public string Nameofdiscipline
        {
            get { return _nameofdiscipline; }
            set
            {
                _nameofdiscipline = value;
                OnPropertyChanged("NameOfDiscipline");
            }
        }
        public string Nameofprofessor
        {
            get { return _nameofprofessor; }
            set
            {
                _nameofprofessor = value;
                OnPropertyChanged("NameOfProfessor");
            }
        }
        public string Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }
        public DateTime Dateofexam
        {
            get { return _dateofexam; }
            set
            {
                _dateofexam = value;
                OnPropertyChanged("DateOfExam");
            }
        }
        public string StrDate
        {
            get { return Dateofexam.ToString("d/M/yyyy").Replace('.', '/'); }
            set
            {
                OnPropertyChanged("StrDate");
            }
        }
        public string DateOfStartWork
        {
            get

            {
                if (_difficulty == "Легкий") return Dateofexam.ToString("d/M/yyyy").Replace('.', '/');
                else if (_difficulty == "Пойдёт") return Dateofexam.AddDays(-14).ToString("d/M/yyyy").Replace('.', '/');
                else if (_difficulty == "Тяжелый") return Dateofexam.AddDays(-30).ToString("d/M/yyyy").Replace('.', '/');
                else return Dateofexam.AddDays(-60).ToString("d/M/yyyy").Replace('.', '/');
            }
            set { OnPropertyChanged("DateOfStartWork"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
