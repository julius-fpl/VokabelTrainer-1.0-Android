using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;

namespace VokabelTrainer
{
    public partial class MainPage : ContentPage
    {
        private int Anzahl;
        string filenameanzahl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Anzahl.txt");

        public MainPage()
        {
            InitializeComponent();

            auslesen();

        }
        public int anzahlderPakete;

        public void auslesen()
        {
            try
            {
                Anzahl = int.Parse(File.ReadAllText(filenameanzahl));
                Buttonserzeugen();
            }
            catch
            {
                Anzahl = 0;
                File.WriteAllText(filenameanzahl, Anzahl.ToString());
                Buttonserzeugen();
            }
        }

        private void Buttonserzeugen()
        {
            Paket01.IsVisible = false;
            Paket02.IsVisible = false;
            Paket03.IsVisible = false;
            Paket04.IsVisible = false;
            Paket05.IsVisible = false;
            Paket06.IsVisible = false;
            Paket07.IsVisible = false;
            Paket08.IsVisible = false;
            Paket09.IsVisible = false;
            Paket10.IsVisible = false;

            if (Anzahl >= 1)
            {
                if (Anzahl >= 1)
                {
                    Paket01.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname1.txt");
                        Paket01.Text = File.ReadAllText(paketname);
                    }
                    catch{ }
                }
                if (Anzahl >= 2)
                {
                    Paket02.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname2.txt");
                        Paket02.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 3)
                {
                    Paket03.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname3.txt");
                        Paket03.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 4)
                {
                    Paket04.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname4.txt");
                        Paket04.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 5)
                {
                    Paket05.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname5.txt");
                        Paket05.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 6)
                {
                    Paket04.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname6.txt");
                        Paket06.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 7)
                {
                    Paket07.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname7.txt");
                        Paket07.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 8)
                {
                    Paket08.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname8.txt");
                        Paket08.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 9)
                {
                    Paket09.IsVisible = true;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname9.txt");
                        Paket09.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }
                if (Anzahl >= 10)
                {
                    Paket10.IsVisible = true;
                    Hinzufuegen.IsEnabled = false;
                    try
                    {
                        string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname10.txt");
                        Paket10.Text = File.ReadAllText(paketname);
                    }
                    catch { }
                }

            }
        }

        private int Ladenoderloeschen = 0;

        private void Loeschen_Clicked(object sender, EventArgs e)
        {
            if(Ladenoderloeschen != 1)
            {
                Ladenoderloeschen = 1;
                Loeschen.Background = new SolidColorBrush(Color.Red);
                Loeschen.Text = "Löschen";
            }
            else
            {
                Ladenoderloeschen = 0;
                Loeschen.Text = "Lernen";
                Loeschen.Background = new SolidColorBrush(Color.FromHex("#00A3FF"));
            }
        }

        private async void PaketHinzufuegen(object sender, EventArgs e)
        {
            auslesen();
            await Navigation.PushAsync(new PaketeNameFestlegen());
        }

        private async void Paket01_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname1.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 1.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket02_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname2.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 2.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket03_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname3.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 3.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket04_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname4.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 4.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket05_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname5.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 5.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket06_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname6.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 6.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket07_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname7.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 7.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket08_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname8.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");
            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 8.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket09_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname9.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 9.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }

        private async void Paket010_Clicked(object sender, EventArgs e)
        {
            string paketname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paketname10.txt");
            string Paket = File.ReadAllText(paketname);
            string Paketladen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketname.txt");
            File.WriteAllText(Paketladen, Paket);
            string Paketnummer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Paketnummer.txt");

            if (Ladenoderloeschen == 1)
            {
                File.WriteAllText(Paketnummer, 10.ToString());
                await Navigation.PushAsync(new Loeschen());
            }
            else
            {
                await Navigation.PushAsync(new Vokabeluebersicht());
            }
        }
    }
}