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
    public partial class Vokabelbennen : ContentPage
    {
        private string Paket;

        public Vokabelbennen()
        {
            InitializeComponent();
            string PaketPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            Paket = File.ReadAllText(PaketPfad);
            Vokabelneuoderalt();
        }

        private string filenameanzahl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bearbeiten.txt");
        private int welchevokabelmodus;

        private string Fremdsprache01Text;
        private string Fremdsprache02Text;

        private string AnzahlderVokabelPfad;
        private int AnzahlderVokabel;

        private void Vokabelneuoderalt()
        {
            welchevokabelmodus = int.Parse(File.ReadAllText(filenameanzahl));

            if (welchevokabelmodus != 0)
            {
                ID.IsVisible = true;
                Laden.IsVisible = true; 
            }
            else
            {
                AnzahlderVokabelPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnzahlderVokabel" + Paket + ".txt");
                Debug.WriteLine(AnzahlderVokabelPfad);
                try
                {
                    AnzahlderVokabel = int.Parse(File.ReadAllText(AnzahlderVokabelPfad));
                }
                catch
                {
                }
            }
        }

        private async void Vokabelspeichern_Clicked(object sender, EventArgs e)
        {
            if (Fremdsprache01.Text != "" && Fremdsprache02.Text != "")
            {
                if (welchevokabelmodus != 0 && Number == 1)
                {
                    File.WriteAllText(Fremdsprache01Text, Fremdsprache01.Text);
                    File.WriteAllText(Fremdsprache02Text, Fremdsprache02.Text);
                }
                else
                {
                    AnzahlderVokabel++;
                    File.WriteAllText(AnzahlderVokabelPfad, AnzahlderVokabel.ToString());
                    string Speicherpfad01 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + AnzahlderVokabel + ".txt");
                    string Speicherpfad02 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + AnzahlderVokabel + ".txt");
                    File.WriteAllText(Speicherpfad01, Fremdsprache01.Text);
                    File.WriteAllText(Speicherpfad02, Fremdsprache02.Text);
                }
                Navigation.InsertPageBefore(new Vokabeluebersicht(), Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
                await Navigation.PopAsync();
            }
        }

        private int Number;

        private void Laden_Clicked(object sender, EventArgs e)
        {
            if(ID.Text != "")
            {
                try
                {
                    Fremdsprache01Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + ID.Text + ".txt");
                    Fremdsprache02Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + ID.Text + ".txt");
                    Fremdsprache01.Text = File.ReadAllText(Fremdsprache01Text);
                    Fremdsprache02.Text = File.ReadAllText(Fremdsprache02Text);
                    Number = 1;
                }
                catch
                {
                    ID.Text = "Nummer ungültig!";
                    Number = 0;
                }
            }
        }
    }
}