using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kalkulator_BMI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //masa/wzrost^2
            int weight = Convert.ToInt32(weightEntry.Text);
            double height = Convert.ToInt32(heightEntry.Text)/100.0;
            double bmi = weight / Math.Pow(height, 2);
            string result = "";
            if (bmi < 18.5) result = "Niedowaga";
            else if (bmi >= 18.5 && bmi <= 24.99) result = "Waga prawidłowa";
            else if (bmi >= 25 && bmi <= 29.99) result = "Nadwaga";
            else if (bmi >= 30 && bmi <= 34.99) result = "Otyłość I stopnia";
            else if (bmi >= 35 && bmi <= 39.99) result = "Otyłość II stopnia";
            else if (bmi >= 40) result = "Otyłość III stopnia";

            BmiLabel.Text = bmi.ToString();
            ResultLabel.Text = result;
        }
    }
}
