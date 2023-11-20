using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;

namespace lab13
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            using (AppDbContext db = new AppDbContext())
            {
                passengersList.ItemsSource = db.Cars.ToList();
            }
            base.OnAppearing();
        }

        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Car selectedPassenger = (Car)e.SelectedItem;
            PassengersPage passengersPage = new PassengersPage();
            passengersPage.BindingContext = selectedPassenger;
            await Navigation.PushAsync(passengersPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreatePassenger(object sender, EventArgs e)
        {
            Car passenger = new Car();
            PassengersPage passengersPage = new PassengersPage();
            passengersPage.BindingContext = passenger;
            await Navigation.PushAsync(passengersPage);
        }
    }
}

