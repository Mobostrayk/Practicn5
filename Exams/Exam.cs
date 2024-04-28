using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Exam : INotifyPropertyChanged
    {
        private string _nameofdiscipline;
        private string _nameofprofessor;
        private string _difficulty = "Легкий";
        private DateTime _dateofexam = DateTime.Now;

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
        public string DateOfStartWork
        {
            get

            {
                return Dateofexam.AddDays(-14).ToString("M/d/yyyy").Replace('.', '/');
            }
            set { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
