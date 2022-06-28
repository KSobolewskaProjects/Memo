using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Memo
{
    public partial class form1 : Form
    {
        //Inicjalizacja zmiennych
        bool czyMoznaKliknac = false;
        PictureBox pierwszeOdkryte;
        Random random = new Random();
        int czas = 60;
        Timer zegar = new Timer { Interval = 1000 };
        Timer klikZegar = new Timer();



        public form1()
        {
            InitializeComponent();            
        }
        
        private void ukladanieKafelkow() {
            //Zmienna do wprowadzania numerów w nazwach kafelków
            int licznikKafelkow = 1;            
            //Tworze planszę 4x4 z PictureBoxów
            for (int polozenieWysokosc = 50; polozenieWysokosc < 426; polozenieWysokosc = polozenieWysokosc+125)
            { 
                for (int polozenieSzerokosc = 50; polozenieSzerokosc < 426; polozenieSzerokosc = polozenieSzerokosc+125)
                {
                    //Tworzenie nowego obiektu danej klasy
                    Kontrolki nowyPictureBox = new Kontrolki();
                    //Stworzenie PictureBoxa za pomocą metody nowo powstałej klasy
                    PictureBox PicBox = nowyPictureBox.stworzPictureBox(polozenieSzerokosc, polozenieWysokosc, licznikKafelkow);
                    //Dopisanie do eventu clik odpowiedniej metody
                    PicBox.Click += new EventHandler(boxObrazkaKlik);
                    //Dodanie kontrolki na ekran
                    Controls.Add(PicBox);
                    //Zwiększenie licznika kafelków w celu stworzenia innej nazwy dla kolejnego kafelka
                    licznikKafelkow++;
                }
            }
        }

        //Tworzenie tablicy obrazków/kart
        private PictureBox[] boxyObrazkow
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }


        //Pobieranie obrazków z zasobów
        private static IEnumerable<Image> obrazki
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.obrazek1,
                    Properties.Resources.obrazek2,
                    Properties.Resources.obrazek3,
                    Properties.Resources.obrazek4,
                    Properties.Resources.obrazek5,
                    Properties.Resources.obrazek6,
                    Properties.Resources.obrazek7,
                    Properties.Resources.obrazek8
                };
            }
        }


        //Metoda do odpalenia gry
        private void startGryZegar()
        {
            //Odpalenie zegara
            zegar.Start();           
            //Zwiększanie licznika
            zegar.Tick += delegate
            {
                //Zmiana wartości zmiennej odpowiadającej za odlicznie do końca gry
                czas--;
                //Warunek przegranej
                if (czas < 0)
                {
                    //Zastopowanie zegara
                    zegar.Stop();
                    //Wyświetlenie komunikatu o przegranej
                    MessageBox.Show("Przegrałeś... Koniec gry.");
                    //Wyjście z aplikacji
                    Application.Exit();

                }
                var czasSekundy = TimeSpan.FromSeconds(czas);
                //Wyświetlanie czasu na ekranie gry
                licznikCzasu.Text = "00: " + czas.ToString();
            };
        }
        

        //Metoda odpowiedzialna za ukrywanie obrazków
        private void ukryjObrazki()
        {
            //Dla każdego obrazka zamiana wyglądu na znak zapytania, czyli ukrycie karty
            foreach (var obrazki in boxyObrazkow)
            {
                //Zakrywanie kart, które możemy jeszcze kilkać
                if (obrazki.Enabled==true)
                {
                    obrazki.Image = Properties.Resources.obrazek0;
                }
            }
        }


        //Metoda zwracająca karty bez przypisanego obrazka
        private PictureBox pobierzWolnySlot()
        {
            //Zmienna niezbędna w pętli do szukania wolnych slotów
            int numer;          
            do
            {
                numer = random.Next(0, boxyObrazkow.Count());
            } while (boxyObrazkow[numer].Tag != null);
            return boxyObrazkow[numer];
        }


        //Metoda do ustawiania obrazków na kartach
        private void ustawRandomoweObrazki()
        {
            //Dla każdego obrotu pętli ustawia się po dwie karty z tym samym obrazkiem
            foreach (var obrazki in obrazki)
            {
                PictureBox pomocniczy = pobierzWolnySlot();
                pomocniczy.Enabled = true;
                pomocniczy.Tag = obrazki;
                pomocniczy = pobierzWolnySlot();
                pomocniczy.Enabled = true;
                pomocniczy.Tag = obrazki;
            }
        }


        //Metoda odpowiadająca za odczekanie do zakrycia kart po złym trafieniu
        private void klikZegaraTik(object sender, EventArgs e)
        {

            ukryjObrazki();
            czyMoznaKliknac = true;
            klikZegar.Stop();
        }


        //Metoda wykonywana po kliknięciu w obrazek
        private void boxObrazkaKlik(object sender, EventArgs e)
        {
            //Jeżeli wartość zmiennej czyMoznaKliknac jest fałszem to wychodzimy z metody, bo nie można wtedy klikać w karty
            if (!czyMoznaKliknac) return;
            var obrazek = (PictureBox)sender;
            //Instrukcja warunkowa odpowiadająca za przypisanie do zmiennej pierwszeOdkryte wartości, a dokładniej odkrytego obrazka i ustawienie obrazka zgodnego z tagiem
            if (pierwszeOdkryte == null)
            {
                pierwszeOdkryte = obrazek;
                obrazek.Image = (Image)obrazek.Tag;
                return;
            }
            //Kiedy wartość zmiennej pierwszeOdkryte jest różna od null, to znaczy że już pierwsza karta została odkryta
            //w takim przypadku do zmiennej ustaiwamy wygląd odkrytej karty zgodny z jej tagiem
            obrazek.Image = (Image)obrazek.Tag;
            //Instrukcja warunkowa odpowiedzialna za sprawdzenie czy podniesione karty mają takie różne obrazki
            if (obrazek.Image == pierwszeOdkryte.Image && obrazek != pierwszeOdkryte)
            {
                //Obrazki sa takie same więc zostają odkryte
                obrazek.Enabled = pierwszeOdkryte.Enabled = false;
                {
                    pierwszeOdkryte = obrazek;
                }
            }
            else
            {
                //Jeżeli obrazki są takie same nie można ich już więcej wybrać
                czyMoznaKliknac = false;
                //Odliczanie do kliknięcia kolejnej karty
                klikZegar.Start();
            }
            //Ponowne ustawienie zmiennej pierwszeOdkryte na null, ponieważ znów możemy odkrywac nowe pary
            pierwszeOdkryte = null;
            //Ustawienie warunku wygrania gry
            //Jeżeli jakikolwiek obrazek jest widoczny gra dalej trwa
            if (boxyObrazkow.Any(p => p.Enabled)) return;
            //Jeżeli wszystkie obrazki są dopasowane w pary pokazuje się informacja, że wygraliśmy grę.
            zegar.Stop();
            //Wyświetlenie komunikatu o przegranej
            MessageBox.Show("Wygrałeś! Koniec gry.");
            Application.Exit();

        }


        //Metoda wywoływana po kliknięciu w przycisk start
        private void przyciskStartKlik(object sender, EventArgs e)
        {
            //Zmiana wartości zmiennej czyMoznaKliknac na true w celu odblokowania możliwości klikania w kolejne karty
            czyMoznaKliknac = true;
            //Ukrycie przycisku start
            przyciskStart.Visible = false;
            //Ustawienie widoczności przycisku stop
            przyciskStop.Visible = true;
            //Ustawianie kafelkow
            ukladanieKafelkow();
            //Ustawienie obrazków na kartach
            ustawRandomoweObrazki();
            //Zakrycie kart znakami zapytania
            ukryjObrazki();
            //odpalenie zegara gry
            startGryZegar();
            //Ustawienie zegara
            klikZegar.Interval = 3000;
            klikZegar.Tick += klikZegaraTik;        
        }


        //Metoda wywoływana po naciśnięciu przycisku stop
        private void przyciskStopKlik(object sender, EventArgs e)
        {
            //Ukrycie przycisku stop
            przyciskStop.Visible = false;
            //Odblokowanie widoczności przycisku reset
            przyciskReset.Visible = true;
            //Zablokowanie możliwości klikania w karty
            czyMoznaKliknac = false;
            //Zablokowanie zegara
            zegar.Stop();
        }


        //Metoda wywoływana po kliknięciu przycisku reset
        private void przyciskResetKlik(object sender, EventArgs e)
        {
            //Ukrycie przycisku stop
            przyciskReset.Visible = false;
            //Odblokowanie widoczności przycisku reset
            przyciskStop.Visible = true;
            //Odblokowanie możliwości klikania w karty
            czyMoznaKliknac = true;
            //Ponowne uruchomienie zegara
            zegar.Start();
        }


        //Wywołanie metody odpowiedzialnej za zamykanie aplikacji
        private void przyciskExitKlik(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}