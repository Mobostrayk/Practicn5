using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Model;

namespace ViewModel
{
    public class ViewModel1 : INotifyPropertyChanged
    {
        public ObservableCollection<Exam> Exams { set; get; }

        private Exam _newExam;
        public Exam NewExam
        {
            get
            {
                return _newExam;
            }
            set
            {
                _newExam = value;
                OnPropertyChanged("NewExam");
            }
        }
        private Exam _selectedExam;
        public Exam SelectedExam
        {
            get
            {
                return _selectedExam;
            }
            set
            {
                _selectedExam = value;
                OnPropertyChanged("SelectedExam");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ViewModel1()
        {
            Exams = new ObservableCollection<Exam>()
            {
                new Exam { Nameofdiscipline = "МатАнализ", Nameofprofessor = "Ленин", Difficulty = "Невозможный",Dateofexam = new DateTime(2024,5,25)},
                new Exam { Nameofdiscipline = "МатАнализ", Nameofprofessor = "Cталин", Difficulty = "Невозможный",Dateofexam = new DateTime(2024,5,25)}
            };
            NewExam = new Exam();

        }


        private ICommand addCommand;
        private ICommand removeCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddEmployee));
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new RelayCommand(RemoveEmployee));

        public void AddEmployee()
        {
            if (Exams.Contains(NewExam) == false)
            {
                if (NewExam.Nameofdiscipline != "" && NewExam.Nameofprofessor != "" &&
                    NewExam.Difficulty != "" && NewExam.Dateofexam >= DateTime.Today)
                {
                    Exams.Add(NewExam);
                    NewExam = new Exam();
                }
            }
        }


        public void RemoveEmployee()
        {
            if (_selectedExam != null)
            {
                if (Exams.Contains(SelectedExam))
                {
                    Exams.Remove(SelectedExam); 
                }
            }
        }


      

    }
}