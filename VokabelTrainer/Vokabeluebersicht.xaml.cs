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
    public partial class Vokabeluebersicht : ContentPage
    {
        private string Paketpfad;
        private string Paket;

        public Vokabeluebersicht()
        {
            InitializeComponent();
            Paketpfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            Paket = File.ReadAllText(Paketpfad);

            Vokabel();
        }

        private int VokabelAnzahl;

        private void Vokabel()
        {
            try
            {
                string AnzahlderVokabelPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnzahlderVokabel" + Paket + ".txt");
                VokabelAnzahl = int.Parse(File.ReadAllText(AnzahlderVokabelPfad));
                Vokabelanzeigen();
            }
            catch { }
        }

        private void Vokabelanzeigen() 
        {
            int Button = 1;
            if(VokabelAnzahl != 0)
            {
                VokabelButton.IsVisible = true;
                while (Button <= VokabelAnzahl)
                {
                    string Fremdsprache01Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + Button.ToString() + ".txt");
                    string Fremdsprache02Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + Button.ToString() + ".txt");
                    VokabelButton.Text += Button.ToString() + ". " + File.ReadAllText(Fremdsprache01Pfad) + " - " + File.ReadAllText(Fremdsprache02Pfad) + Environment.NewLine;
                    Button++;
                }
            }
        }

        private string filenameanzahl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bearbeiten.txt");
        private int Bearbeiten;

        private async void Ueben_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ueben());
        }

        private async void Hinzufuegen_Clicked(object sender, EventArgs e)
        {
            Bearbeiten = 0;
            File.WriteAllText(filenameanzahl, Bearbeiten.ToString());
            await Navigation.PushAsync(new Vokabelbennen());
        }

        private async void VokabelButton_CLicked(object sender, EventArgs e)
        {
            Bearbeiten = 1;
            File.WriteAllText(filenameanzahl, Bearbeiten.ToString());
            await Navigation.PushAsync(new Vokabelbennen());
        }
    }
}