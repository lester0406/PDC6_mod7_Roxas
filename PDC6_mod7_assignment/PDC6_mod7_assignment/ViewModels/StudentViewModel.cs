using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PDC6_mod7_Roxas.Models;
using PDC6_mod7_Roxas.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PDC6_mod7_Roxas.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Section { get; set; }

        private DBFirebase services;
        public Command AddStudentCommand { get; set; }
        public ObservableCollection<Students> _students = new ObservableCollection<Students>();
        public ObservableCollection<Students> Student
        {
            get { return _students; }
            set 
            {
                _students = value;
                OnPropertyChanged();
            }      
        }

        public StudentViewModel()
        {
            services = new DBFirebase();
            Student = services.getStudents();
            AddStudentCommand = new Command(async () => await addStudentAsync(StudentID, Name, Section, YearLevel, Course));

        }

        

        public async Task addStudentAsync(int StudentID, string Name, string Section, string YearLevel, string Course) 
        {
            await services.AddStudent(StudentID, Name, Section, YearLevel, Course);
        }
    }
}
