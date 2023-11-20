using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lab13
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengersPage : ContentPage
    {

        public PassengersPage()
        {
            InitializeComponent();
        }

        private void SaveCar(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;
            if (!String.IsNullOrEmpty(car.Model))
            {
                using (AppDbContext db = new AppDbContext())
                {

                    if (car.CarId == 0)
                        db.Cars.Add(car);
                    else
                    {
                        db.Cars.Update(car);
                    }
                    db.SaveChanges();
                }
            }
            this.Navigation.PopAsync();
        }
        private void DeleteCar(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;
            using (AppDbContext db = new AppDbContext())
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
    }
}

