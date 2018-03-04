using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class Form1 : Form
    {
        int[,] tablica = null;
        bool[,] tablicaOdblokowane = null;
        List<Pola> listaPol = new List<Pola>();
        int _x, _y, _iloscBomb;
        Stopwatch stopwatch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }
        #region Funkcje startu
        private void start()
        {
            listaPol.Clear();
            label2.Text = "";
            label3.Text = "";
            stopwatch.Reset();
        }

        private void dodajPrzyciski(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Pola pole = new Pola();
                    pole.pozX = i;
                    pole.pozY = j;
                    pole.wartosc = tablica[i, j].ToString();
                    if (pole.wartosc == 0.ToString())
                        pole.wartosc = "";
                    if (pole.wartosc == 9.ToString())
                        pole.wartosc = "*";
                    pole.przycisk.Text = "";
                    pole.przycisk.Height = 20;
                    pole.przycisk.Width = 20;
                    pole.przycisk.Top = 50 + i * 25;
                    pole.przycisk.Left = 10 + j * 25;
                    //pole.przycisk.MouseEnter += wejscie;
                    //pole.przycisk.MouseLeave += wyjscie;
                    pole.przycisk.MouseUp += klik;
                    this.Controls.Add(pole.przycisk);
                    listaPol.Add(pole);
                }
            }
        }

        private void sprawdzTablce(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (tablica[i, j] != 9)
                    {
                        for (int liczX = -1; liczX < 2; liczX++)
                        {
                            for (int liczY = -1; liczY < 2; liczY++)
                            {
                                try
                                {
                                    if (tablica[i + liczX, j + liczY] == 9)
                                        tablica[i, j] += 1;
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                    }
                }
               
            }
        }

        private void zerujTablce(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    tablica[i, j] = 0;
                    tablicaOdblokowane[i, j] = false;
                }
            }
        }

        private void losujBomby(int iloscBomb)
        {
            int pozX, pozY;
            int i = 0;
            while (i < iloscBomb)
            {
                Random rand = new Random();
                pozX = rand.Next(0, _x );
                pozY = rand.Next(0, _y );
                if (tablica[pozX, pozY] == 0)
                {
                    tablica[pozX, pozY] = 9;
                    i++;
                }
            }
        }
        #endregion

        #region Obsługa formy
        private void buttonStart_Click(object sender, EventArgs e)
        {
            start();
            int y = Convert.ToInt32(textBoxRozmiarX.Text);
            int x = Convert.ToInt32(textBoxRozimarY.Text);
            int iloscBomb = Convert.ToInt32(textBoxLiczbaBomb.Text);

            _x = x;
            _y = y;
            _iloscBomb = iloscBomb;

            if (iloscBomb >= 10 && y >= 8 && x >= 8 && iloscBomb <= (x-1)*(y-1) && y<=30 && x<=24)
            {
                tablica = new int[x, y];
                tablicaOdblokowane = new bool[x, y];
                zerujTablce(x, y);
                losujBomby(iloscBomb);
                sprawdzTablce(x, y);
                dodajPrzyciski(x, y);
                timer1.Start();
                stopwatch.Start();
                buttonStart.Enabled = false;

                if (50 + x * (30) + 10 > 350)
                    ActiveForm.Height = 50 + x * (30) + 10;
                else
                    ActiveForm.Height = 350;
                if (50 + y * (30) + 10 > 370)
                    ActiveForm.Width = 50 + y * (30) + 10;
                else
                    ActiveForm.Width = 370;
                ActiveForm.Refresh();
            }
            else
                MessageBox.Show("Błąd \nZmień dane","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            label3.Text = elapsedTime;
            int pom = 0;
            sprawdzCzyWygrana();
            foreach (var item in listaPol)
            {
                if (item.przycisk.Text == "B")
                    pom++;

            }

        }
        #endregion

        #region Funkcje gry
        private void klik(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var button = (Button)sender;
                foreach (var item in listaPol)
                {
                    if (button == item.przycisk)
                    {
                        if (button.Text == "")
                            button.Text = "B";
                        else if (button.Text == "B")
                            button.Text = "?";
                        else if (button.Text == "?")
                            button.Text = "";
                    }
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                var button = (Button)sender;
                foreach (var item in listaPol)
                {
                    if (button == item.przycisk)
                    {
                        button.Text = item.wartosc;
                        if (item.wartosc != "*" && item.wartosc != "")
                        {
                            button.ForeColor = ustawKolor(item.wartosc);
                        }

                        button.MouseUp -= klik;
                        sprawdzPole(button.Text, item.pozX, item.pozY);

                    }
                }
            }
        }

        //private void wejscie(object sender, EventArgs e)
        //{
        //    var button = (Button)sender;
        //    foreach (var item in listaPol)
        //    {
        //        if (button == item.przycisk)
        //        {
        //            tekst = button.Text;
        //            button.Text = item.wartosc;
        //        }
        //    }
        //}
        //private void wyjscie(object sender, EventArgs e)
        //{
        //    var button = (Button)sender;
        //    foreach (var item in listaPol)
        //    {
        //        if (button == item.przycisk)
        //        {
        //            if(tekst =="")
        //                button.Text = item.wartosc;
        //            else
        //                button.Text = tekst;
        //        }
        //    }
        //}

        private Color ustawKolor(string wartosc)
        {
            switch ( wartosc)
            {
                case "1":
                    return Color.Blue;
                case "2":
                    return Color.Green;
                case "3":
                    return Color.Red;
                case "4":
                    return Color.Brown;
                case "5":
                    return Color.Purple;
                case "6":
                    return Color.DarkOrange;
                case "7":
                    return Color.Gray;
                case "8":
                    return Color.Black;
                default:
                    return Color.Black;

            }
        }

        private void sprawdzCzyWygrana()
        {
            int pom = 0;
            for(int i =0; i< _x;i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    if (tablica[i, j] != 9 && tablicaOdblokowane[i, j] == false)
                    {
                        pom = 1;
                        break;
                    }
                }
            }
            if(pom == 0 )
            {
                koniecGry("Wygrałeś");
            }
        }

        private void sprawdzPole(string text, int x, int y)
        {
            if(text == "*")
            {
                pokazBomby();
                koniecGry("Przegrałeś");
            }
            else if(text != "*")
            {
                odblokujOtoczenie(x, y);
                tablicaOdblokowane[x, y] = true;
            }
        }

        private void odblokujOtoczenie(int x, int y)
        {
            for (int liczX = -1; liczX < 2; liczX++)
            {
                for (int liczY = -1; liczY < 2; liczY++)
                {
                    try
                    {
                        var a = tablica[x + liczX, y + liczY];
                        if ((tablica[x + liczX, y + liczY] == 0 && tablicaOdblokowane[x + liczX, y + liczY] == false))
                        {
                            foreach (var item in listaPol)
                            {
                                if (item.pozX == x + liczX && item.pozY == y + liczY)
                                {
                                    item.przycisk.Text = item.wartosc;
                                    item.przycisk.MouseUp -= klik;
                                    item.przycisk.Enabled = false;
                                    tablicaOdblokowane[x + liczX, y + liczY] = true;
                                    odblokujOtoczenie(x + liczX, y + liczY);
                                    odblokujOtoczenieGraniczne(x + liczX, y + liczY);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void odblokujOtoczenieGraniczne(int x, int y)
        {
            for (int liczX = -1; liczX < 2; liczX++)
            {
                for (int liczY = -1; liczY < 2; liczY++)
                {
                    foreach (var item in listaPol)
                    {
                        if (item.pozX == x + liczX && item.pozY == y + liczY)
                        {
                            item.przycisk.Text = item.wartosc;
                            item.przycisk.MouseUp -= klik;
                            item.przycisk.ForeColor = ustawKolor(item.wartosc);
                            tablicaOdblokowane[x + liczX, y + liczY] = true;
                        }
                    }
                }
            }
        }

        private void koniecGry(string text)
        {
            timer1.Stop();
            stopwatch.Stop();
            DialogResult dl = MessageBox.Show(text + "\nGrasz jeszcze raz?", "Koniec gry", MessageBoxButtons.YesNo);
            if (dl == DialogResult.Yes)
            {
                buttonStart.Enabled = true;

                foreach (var item in listaPol)
                {
                    this.Controls.Remove(item.przycisk);
                }
            }
            else
            {
                this.Close();
            }
        }

        private void pokazBomby()
        {
            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j <_y; j++)
                {
                    if(tablica[i,j]==9)
                    {
                        foreach (var item in listaPol)
                        {
                            if(item.pozX == i && item.pozY==j && item.przycisk.Text =="")
                            {
                                item.przycisk.Text = item.wartosc;
                                item.przycisk.Enabled = false;
                            }
                            if(item.wartosc != "*" && item.przycisk.Text == "B")
                            {
                                item.przycisk.BackColor = Color.MediumVioletRed;
                            }
                        }
                    }
                }
            }
        }
        #endregion
  
    }
}
