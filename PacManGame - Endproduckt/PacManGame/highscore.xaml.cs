using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PacManGame
{
    /// <summary>
    /// Interaktionslogik für highscore.xaml
    /// </summary>
    public partial class highscore : Window
    {
        public highscore()
        {
            InitializeComponent();
            Reader();
        }

        //füll die Textboxen mit den Highscores
        private void highscorefill(List<string[]> Liste)
        {
            List<TextBox> Textboxlist = new List<TextBox>();
            Textboxlist.Add(highscore1);
            Textboxlist.Add(highscore2);
            Textboxlist.Add(highscore3); 
            Textboxlist.Add(highscore4);
            Textboxlist.Add(highscore5);
            Textboxlist.Add(highscore6);
            Textboxlist.Add(highscore7);
            Textboxlist.Add(highscore8);
            Textboxlist.Add(highscore9);
            Textboxlist.Add(highscore10);

            int counter = 0;
            foreach (var textboxitem in Textboxlist)
            {
                
                if (counter < Liste.Count()-1)
                {
                    textboxitem.Text = $"{Liste[counter][0]}: {Liste[counter][1]}  ";
                    counter += 1;
                }

            }


        }

        public void Reader()
        {
            using (StreamReader sr = new StreamReader("highscores.txt"))
            {
                string spieler;
                List<string[]> Spielerliste = new List<string[]>();
                while ((spieler = sr.ReadLine()) != null)
                {
                    if (spieler != "")
                    {
                        string[] Spielerarray = spieler.Split(',');
                        Spielerliste.Add(Spielerarray);
                    }

                }
                List<int> Highscoreliste = new List<int>();
                //selection sort
                //try-catch
                int counter = 0;
                try
                {
                    foreach (var item in Spielerliste)
                    {
                        Highscoreliste.Add(Convert.ToInt32(item[1]));
                        counter += 1;
                    }
                    int stellevonzahl = 0;
                    for (int i = 0; i <= Highscoreliste.Count() - 1; i++)
                    {
                        int kleinstezahl = Highscoreliste[i];
                        int x = i + 1;
                        while (x < Highscoreliste.Count())
                        {
                            if (kleinstezahl >= Highscoreliste[x])
                            {
                                kleinstezahl = Highscoreliste[x];
                                stellevonzahl = x;
                            }
                            x += 1;
                        }
                        int zahlausarray = Highscoreliste[i];
                        Highscoreliste[i] = kleinstezahl;
                        Highscoreliste[stellevonzahl] = zahlausarray;
                    }
                }
                catch (System.FormatException)
                {
                    foreach (var item in Spielerliste)
                    {
                        if (item.Count() != 2)
                        {
                            Spielerliste.Remove(item);
                            break;
                        }
                    }

                    Highscoreliste.Clear();
                    foreach (var item in Spielerliste)
                    {
                        Highscoreliste.Add(Convert.ToInt32(item[1]));
                    }
                    int stellevonzahl = 0;
                    for (int i = 0; i <= Highscoreliste.Count() - 1; i++)
                    {
                        int kleinstezahl = Highscoreliste[i];
                        int x = i + 1;
                        while (x < Highscoreliste.Count())
                        {
                            if (kleinstezahl >= Highscoreliste[x])
                            {
                                kleinstezahl = Highscoreliste[x];
                                stellevonzahl = x;
                            }
                            x += 1;
                        }
                        int zahlausarray = Highscoreliste[i];
                        Highscoreliste[i] = kleinstezahl;
                        Highscoreliste[stellevonzahl] = zahlausarray;
                    }
                }
                //try-catch
                //fügt der Liste die Highscores in geordneter reihenfolge hinzu
                List<string[]> geordnetspieler = new List<string[]>();
                Highscoreliste.Reverse();
                try
                {
                    foreach (var zahl in Highscoreliste)
                    {
                        foreach (var item in Spielerliste)
                        {
                            if (zahl == Convert.ToInt32(item[1]))
                            {
                                geordnetspieler.Add(item);
                            }
                        }
                    }
                }
                catch (System.FormatException)
                {

                }
                highscorefill(geordnetspieler);
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            highscores.Close();
            MainWindow Main = new MainWindow();

            Main.Show();



        }
    }
}
