using System;
using Xamarin.Forms;

namespace MathUnadm_AOA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Init(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Game());
        }

        private void ExitApp(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
