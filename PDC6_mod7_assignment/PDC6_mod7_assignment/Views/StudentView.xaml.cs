using PDC6_mod7_Roxas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDC6_mod7_Roxas.Models;
using PDC6_mod7_Roxas.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC6_mod7_Roxas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentView : ContentPage
    {
        public StudentView()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }

        public async void OnItemSelected(Object sender, ItemTappedEventArgs args)
        {
            var student = args.Item as Students;
            if (student == null) return;

            await Navigation.PushAsync(new StudentDetails(student));
            lstStudents.SelectedItem = null;
        }
    }
}