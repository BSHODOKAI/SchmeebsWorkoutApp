using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SchmeebsWorkoutApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SeeWorkoutButton_Pressed(object sender, EventArgs e)
        {
            string alertString = string.Format("Deadlift: {0}, Squat: {1}, Bench: {2}, Overhead Press: {3}", Deadlift1RM.Text, Squat1RM.Text, Bench1RM.Text, OverheadPress1RM.Text);
            DisplayAlert("These are your One Rep Maxes", alertString, "Ok");
        }
    }
}
