using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections;
using System.IO;

namespace PacManGame
{
    /// <summary>
    /// Interaktionslogik für Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        Rectangle newBlock = new Rectangle();

        public List<Rectangle> Blockliste = new List<Rectangle>();
       
        static public int AnzahlDerPunkte;
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("spielfeld.txt"))
            {
                string spieler;
                List<string[]> spielfeldliste = new List<string[]>();
                while ((spieler = sr.ReadLine()) != null)
                {
                    if (spieler != "")
                    {
                        string[] Reihe = spieler.Split(',');
                        spielfeldliste.Add(Reihe);
                    }
                }
                Spielfeld.Background = Brushes.Blue;
                int x = 0;
                int y = 0;

                //Map spawn
                foreach (var item in spielfeldliste)
                {
                    y = 0;
                    foreach (var pos in item)
                    {
                        
                        if (pos == "x")
                        {
                            Rectangle Wand = new Rectangle();
                            Wand.Fill = Brushes.Gray;
                            Grid.SetRow(Wand, x);
                            Grid.SetColumn(Wand, y);
                            Spielfeld.Children.Add(Wand);
                            Blockliste.Add(Wand);
                           
                        }

                        if (pos == "o")
                        {
                            
                            Rectangle Punkt = new Rectangle();
                            Punkt.Fill = new ImageBrush
                            {
                                ImageSource = new BitmapImage(new Uri(@"dot2.png", UriKind.Relative))
                            };
                            Grid.SetRow(Punkt, x);
                            Grid.SetColumn(Punkt, y);
                            Spielfeld.Children.Add(Punkt);
                            Blockliste.Add(Punkt);
                        }

                        if (pos == "a")
                        {
                            Rectangle Pacmanspieler = new Rectangle();
                            Pacmanspieler.Fill = new ImageBrush
                            {
                                ImageSource = new BitmapImage(new Uri(@"pacmangif.gif", UriKind.Relative))
                            };
                            PacmanPlayer.Bloecke.Add(Pacmanspieler); //erstes neu erstellter Block bzw. Label wird in die Liste hinzugefügt
                            PacmanPlayer.Y.Add(y); //erster Y-Wert für pacman wird in die Liste hinzugefügt
                            PacmanPlayer.X.Add(x); //ebenso der X-Wert für pacman
                            Spielfeld.Children.Add(PacmanPlayer.Bloecke[0]); //Pacman wird ebenso in das Spielfeld eingefügt
                            Grid.SetRow(Pacmanspieler, x);
                            Grid.SetColumn(Pacmanspieler, y);
                            
                        }

                        if(pos == "y")
                        {
                            Rectangle leeresfeld = new Rectangle();
                            Grid.SetRow(leeresfeld, x);
                            Grid.SetColumn(leeresfeld, y);
                            Spielfeld.Children.Add(leeresfeld);
                            Blockliste.Add(leeresfeld);
                            
                        }
                        y += 1;

                        
                    }
                    x += 1;
                }
            }
            
            Timer = new DispatcherTimer(); //ein Dispatcher wird hier initialisiert

            Timer.Interval = new TimeSpan(1500000); //Ticks
            Timer.Tick += Timer_Tick; //Verweis, was er wiederholt ausführen soll
            Timer.Start(); //Dispachter wird gestartet
        }

        public static Grid window; //damit man auf das Grid in der Klasse zugreifen kann
        DispatcherTimer Timer;

        public Game()
        {
           InitializeComponent();
           
            window = Spielfeld; // Steuert das grit iM Widow an
        }

        
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                PacmanPlayer.richtung = "Oben";
               
            }
            if (e.Key == Key.Down)
            {
                
                PacmanPlayer.richtung = "Unten";
            }
            if (e.Key == Key.Right)
            {
                
                PacmanPlayer.richtung = "Rechts";
                

            }
            if (e.Key == Key.Left)
            {
                PacmanPlayer.richtung = "Links";

            }
        
         }
         public void removeBlock()
        {
            foreach (var item in Blockliste)
            {
                
            }
        }
       
        public void checkfertig()
        {
            int truecounter = 0;
            foreach (var item in Blockliste )
            {
                if(item.Visibility == Visibility.Hidden)
                {
                    truecounter += 1;
                }
            }
            if (truecounter == Blockliste.Count())
            {
                PacmanPlayer.fertig = true;
            }
        }
    
       

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Grid.SetRow(PunkteBlock, Punkt.YPunkt);
            //Grid.SetColumn(PunkteBlock, Punkt.XPunkt);
            //PacmanPlayer.CheckPunkte();
            removeBlock();

            checkfertig();
            if (PacmanPlayer.fertig) //Wenn das Spiel vorbei ist bzw. der User verloren hat, springt er hier rein
            {
                Timer.Stop(); //Dispatcher wird gestoppt
                Spielfeld.Children.Remove(PacmanPlayer.Bloecke[0]);
                EndeWindow Ende = new EndeWindow();

                Ende.Show();
                this.Close();
            }
            PacmanPlayer.PacmanBewegung();
        }

        
    }
}
