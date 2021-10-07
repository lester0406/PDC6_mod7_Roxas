using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PDC6_mod7_Roxas.Models;
using System.Collections.ObjectModel;
using MvvmHelpers;
using System.Linq;

namespace PDC6_mod7_Roxas.Services
{
   public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase() 
        {
            client = new FirebaseClient("https://xamarindatabase-1d283-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<Students> getStudents()
        {
            var StudentData = client
                .Child("Students")
                .AsObservable<Students>()
                .AsObservableCollection();

            return StudentData;
        
        }
        public async Task AddStudent(int StudentId, string Name, string Course, string YearLevel, string Section) 
        {

            Students std = new Students() { StudentID = StudentId, Course = Course, YearLevel = YearLevel, Section = Section };
            await client
                .Child("Students")
                .PostAsync(std);
        }

        public async Task DeleteStudent(int StudentId, string Name, string Course, string YearLevel, string Section) 
        {

            var toDeleteStudent = (await client
                .Child("Student")
                .OnceAsync<Students>()).FirstOrDefault
                (a => a.Object.Name == Name || a.Object.Course == Course);
            await client.Child("Student").Child(toDeleteStudent.Key).DeleteAsync();

        
        }

        public async Task UpdateStudent(int StudentId, string Name, string Course, string YearLevel, string Section)
        {
            var toUpdateStudent = (await client
                .Child("Student")
                .OnceAsync<Students>()).FirstOrDefault
                (a => a.Object.Name == Name);

            Students e = new Students() { StudentID = StudentId, Course = Course, Name = Name, YearLevel = YearLevel, Section = Section };
            await client
                .Child("Student")
                .Child(toUpdateStudent.Key)
                .PutAsync(e);

        }
        }
    }
