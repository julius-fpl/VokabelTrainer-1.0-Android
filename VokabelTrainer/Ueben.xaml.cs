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
    public partial class Ueben : ContentPage
    {
        private int Modus;
        private int RichtigCounter = 0;
        private int FalschCounter = 0;
        private int VokabelAnzahl;
        private string Paket;
        private int Zahl;
        private int Welchermodus;

        public Ueben()
        {
            InitializeComponent();
        }

        private void ModusOne(object sender, EventArgs e)
        {
            Modus = 1;
            Modus01.IsVisible = false;
            Modus02.IsVisible = false;
            Modus03.IsVisible = false;
            StacklayoutKorektur.IsVisible = true;
            Auslesen();
        }

        private void ModusTwo(object sender, EventArgs e)
        {
            Modus = 2;
            Modus01.IsVisible = false;
            Modus02.IsVisible = false;
            Modus03.IsVisible = false;
            StacklayoutKorektur.IsVisible = true;
            Auslesen();
        }

        private void ModusThree(object sender, EventArgs e)
        {
            Modus = 3;
            Modus01.IsVisible = false;
            Modus02.IsVisible = false;
            Modus03.IsVisible = false;
            StacklayoutKorektur.IsVisible = true;
            Auslesen();
        }

        private void Auslesen()
        {
            string Paketpfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            Paket = File.ReadAllText(Paketpfad);
            string AnzahlderVokabelPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnzahlderVokabel" + Paket + ".txt");
            VokabelAnzahl = int.Parse(File.ReadAllText(AnzahlderVokabelPfad));
            VokabelAnzahl++;
            NeueVokabelAnzeigen();
        }

        private void NeueVokabelAnzeigen()
        {
            if (Modus == 1)
            {
                Random Anzahl = new Random();
                Zahl = Anzahl.Next(1, VokabelAnzahl);
                string Fremdsprache01Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + Zahl + ".txt");
                AnzeigeText.Text = File.ReadAllText(Fremdsprache01Pfad);
            }
            else if (Modus == 2)
            {
                Random Anzahl = new Random();
                Zahl = Anzahl.Next(1, VokabelAnzahl);
                string Fremdsprache02Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + Zahl + ".txt");
                AnzeigeText.Text = File.ReadAllText(Fremdsprache02Pfad);
            }
            else if (Modus == 3)
            {
                Random Modusint = new Random();
                Welchermodus = Modusint.Next(1, 3);
                Random Anzahl = new Random();
                Zahl = Anzahl.Next(1, VokabelAnzahl);
                if (Welchermodus == 1)
                {
                    string Fremdsprache01Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + Zahl + ".txt");
                    AnzeigeText.Text = File.ReadAllText(Fremdsprache01Pfad);
                }
                else
                {
                    string Fremdsprache02Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + Zahl + ".txt");
                    AnzeigeText.Text = File.ReadAllText(Fremdsprache02Pfad);
                }
            }
            AnzeigeText.IsVisible = true;
            LoesungAnzeigen.IsVisible = true;
            Antwort.IsVisible = true;
        }

        private void Richtig_Clicked(object sender, EventArgs e)
        {
            RichtigCounter++;
            Counter.Text = "Richtig: " + RichtigCounter.ToString() + " Falsch: " + FalschCounter.ToString();
            Richtig.IsVisible = false;
            Falsch.IsVisible = false;
            AntwortText.IsVisible = false;
            Antwort.Text = "";
            NeueVokabelAnzeigen();
        }

        private void Falsch_Clicked(object sender, EventArgs e)
        {
            FalschCounter++;
            Counter.Text = "Richtig: " + RichtigCounter.ToString() + " Falsch: " + FalschCounter.ToString();
            Richtig.IsVisible = false;
            Falsch.IsVisible = false;
            AntwortText.IsVisible = false;
            Antwort.Text = "";
            NeueVokabelAnzeigen();
        }

        private void LoesungAnzeigen_Clicked(object sender, EventArgs e)
        {
            if (Autokoregieren.IsToggled == true)
            {
                if(Modus == 1)
                {
                    string Fremdsprache02Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + Zahl + ".txt");
                    AntwortText.Text = File.ReadAllText(Fremdsprache02Pfad);
                }
                else if (Modus == 2)
                {
                    string Fremdsprache01Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + Zahl + ".txt");
                    AntwortText.Text = File.ReadAllText(Fremdsprache01Pfad);
                }
                else if (Modus == 3)
                {
                    if (Welchermodus == 1)
                    {
                        string Fremdsprache02Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + Zahl + ".txt");
                        AntwortText.Text = File.ReadAllText(Fremdsprache02Pfad);
                    }
                    else
                    {
                        string Fremdsprache01Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + Zahl + ".txt");
                        AntwortText.Text = File.ReadAllText(Fremdsprache01Pfad);
                    }
                }

                if(AntwortText.Text == Antwort.Text)
                {
                    RichtigCounter++;
                    Counter.Text = "Richtig: " + RichtigCounter.ToString() + " Falsch: " + FalschCounter.ToString();
                }
                else
                {
                    FalschCounter++;
                    Counter.Text = "Richtig: " + RichtigCounter.ToString() + " Falsch: " + FalschCounter.ToString();
                }
                LoesungAnzeigen.IsVisible = false;
                AntwortText.IsVisible = true;
                Weiter.IsVisible = true;
                Counter.IsVisible = true;
            }
            else
            {
                //Wenn selbst korriegeren
                if (Modus == 1)
                {
                    string Fremdsprache02Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + Zahl + ".txt");
                    AntwortText.Text = File.ReadAllText(Fremdsprache02Pfad);
                }
                else if (Modus == 2)
                {
                    string Fremdsprache01Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + Zahl + ".txt");
                    AntwortText.Text = File.ReadAllText(Fremdsprache01Pfad);
                }
                else if (Modus == 3)
                {
                    if (Welchermodus == 1)
                    {
                        string Fremdsprache02Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache02" + Zahl + ".txt");
                        AntwortText.Text = File.ReadAllText(Fremdsprache02Pfad);
                    }
                    else
                    {
                        string Fremdsprache01Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Paket + "Fremdsprache01" + Zahl + ".txt");
                        AntwortText.Text = File.ReadAllText(Fremdsprache01Pfad);
                    }
                }

                LoesungAnzeigen.IsVisible = false;
                AntwortText.IsVisible = true;
                Richtig.IsVisible = true;
                Falsch.IsVisible = true;
                Counter.IsVisible = true;
            }
        }

        private void Weiter_Clicked(object sender, EventArgs e)
        {
            Weiter.IsVisible = false;
            Antwort.Text = "";
            AntwortText.IsVisible = false;
            NeueVokabelAnzeigen();
        }
    }
}