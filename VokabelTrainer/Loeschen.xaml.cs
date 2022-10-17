using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VokabelTrainer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loeschen : ContentPage
    {
        private string Paketladen;
        private string AnzahlderVokabelPfad;
        private string PaketName;

        public Loeschen()
        {
            InitializeComponent();
            Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            PaketName = File.ReadAllText(Paketladen);
            PaketText.Text = "Möchtest du das Paket mit dem Namen " + File.ReadAllText(Paketladen) + " wirklich löschen?";
            AnzahlderVokabelPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnzahlderVokabel" + PaketName + ".txt");

        }

        private async void Ja_Clicked(object sender, EventArgs e)
        {
            if (NeuerName.Text != "")
            {
                try
                {
                    int Vokabelanzahl = int.Parse(File.ReadAllText(AnzahlderVokabelPfad));

                    while (Vokabelanzahl != 0)
                    {
                        string Vokabelpfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), PaketName + "Fremdsprache01" + Vokabelanzahl.ToString() + ".txt");
                        File.Delete(Vokabelpfad);
                        Vokabelanzahl = Vokabelanzahl - 1;
                    }
                    File.Delete(AnzahlderVokabelPfad);
                }
                catch { }
                string PaketnummerPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");
                int Nummer = int.Parse(File.ReadAllText(PaketnummerPfad));
                string Paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname" + Nummer.ToString() + ".txt");
                File.WriteAllText(Paketname, NeuerName.Text);
                File.Delete(PaketnummerPfad);
                this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
                this.Navigation.PopAsync();
            }
        }

        private async void Nein_Clicked(object sender, EventArgs e)
        {
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
            this.Navigation.PopAsync();
        }
    }
}