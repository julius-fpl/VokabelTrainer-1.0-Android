using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VokabelTrainer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaketeNameFestlegen : ContentPage
    {
        public PaketeNameFestlegen()
        {
            InitializeComponent();
        }

        string filenameanzahl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Anzahl.txt");
        int AnzahlderPakete;

        private string paketname;

        private void Dateinamegenerator()
        {
            AnzahlderPakete = int.Parse(File.ReadAllText(filenameanzahl));

            paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname" + AnzahlderPakete.ToString() + ".txt");
            File.WriteAllText(paketname, PaketName.Text);
        }

        private async void Erstellen_Clicked(object sender, EventArgs e)
        {
            if (PaketName.Text != "")
            {
                int Anzahl = int.Parse(File.ReadAllText(filenameanzahl));
                Anzahl++;
                File.WriteAllText(filenameanzahl, Anzahl.ToString());
                Dateinamegenerator();
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}