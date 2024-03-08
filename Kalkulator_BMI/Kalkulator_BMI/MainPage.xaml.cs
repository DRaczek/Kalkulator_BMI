using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kalkulator_BMI
{
    public partial class MainPage : ContentPage
    {
        private double bmi = 0;
        private string result = "";
        private int weight = 0;
        private double height = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //masa/wzrost^2
             weight = Convert.ToInt32(weightEntry.Text);
             height = Convert.ToInt32(heightEntry.Text)/100.0;
             bmi = weight / Math.Pow(height, 2);
             result = "";
            if (bmi < 18.5) result = "Niedowaga";
            else if (bmi >= 18.5 && bmi <= 24.99) result = "Waga prawidłowa";
            else if (bmi >= 25 && bmi <= 29.99) result = "Nadwaga";
            else if (bmi >= 30 && bmi <= 34.99) result = "Otyłość I stopnia";
            else if (bmi >= 35 && bmi <= 39.99) result = "Otyłość II stopnia";
            else if (bmi >= 40) result = "Otyłość III stopnia";

            BmiLabel.Text = bmi.ToString();
            ResultLabel.Text = result;
            saveButton.IsVisible = true;
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            string title = await DisplayPromptAsync("Zapis", "Podaj tytuł pliku", "OK", "Anuluj", "Tytul", 250, initialValue: "defaultTitle");
            if (title == null || string.IsNullOrEmpty(title))
            {
                await DisplayAlert("Zapisywanie nie powiodło się" ,"Podaj prawidłowy tytuł","OK");
                return;
            }
            title += ".txt";
            BMI nowe = new BMI()
            {
                Guid = Guid.NewGuid(),
                Bmi = bmi,
                Height = height,
                Weight = weight,
                Sex = (maleRadio.IsChecked == true ? "Mężczyzna" : "Kobieta"),
                Score = result
            };
            try
            {
                File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), title), nowe.ToString());
            }
            catch (Exception)
            {
                await DisplayAlert("Błąd", "Nie udało się zapisać pliku", "OK");
            }
            await DisplayAlert("Sukces", "Udało się zapisać plik", "OK");
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Results());
        }
    }
}
