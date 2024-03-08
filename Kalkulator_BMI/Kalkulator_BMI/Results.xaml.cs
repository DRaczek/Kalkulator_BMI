using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalkulator_BMI
{
    public class ListViewItem
    {
        public string Title { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public BMI Bmi { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Results : ContentPage
    {
        public Results()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            string[] files =  Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            List<ListViewItem> list = new List<ListViewItem>();
            foreach(string file in files) {
                list.Add(
                        new ListViewItem()
                        {
                            Bmi = BMI.fromString(File.ReadAllText(file)),
                            Title =Path.GetFileName(file),
                            Date = File.GetCreationTime(file),
                            FullName = file,
                        }    
                    );
            }
            lstView.ItemsSource = list;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ListViewItem lvi = (sender as Button).BindingContext as ListViewItem;
            File.Delete(lvi.FullName);
            OnAppearing();
        }
    }
}