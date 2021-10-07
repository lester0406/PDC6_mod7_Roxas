using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using PDC6_mod7_Roxas.Services;
using PDC6_mod7_Roxas.Models;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC6_mod7_Roxas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetails : ContentPage
    {

        DBFirebase services;


        public StudentDetails(Students student)
        {
            InitializeComponent();
            BindingContext = student;

            services = new DBFirebase();

        }

        public async void BtnDelete (object sender, EventArgs e)
        {

            await services.DeleteStudent(int.Parse(StudentID.Text), Name.Text, Course.Text, Yearlevel.Text, Section.Text);
            await Navigation.PushAsync(new StudentView());
        }



        public async void  BtnUpdate (Object sender, EventArgs e)
        {
            await services.UpdateStudent(int.Parse(StudentID.Text), Name.Text, Course.Text, Yearlevel.Text, Section.Text);
            await Navigation.PushAsync(new StudentView());

        }
    }
}