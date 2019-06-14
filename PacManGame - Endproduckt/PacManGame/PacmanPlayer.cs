using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PacManGame
{
     public partial class PacmanPlayer : Game
    {

        public static List<Rectangle> Bloecke = new List<Rectangle>();
        //public static List<Punkt> ListPunkte = new List<Punkt>();
        public static List<int> X = new List<int>();
        public static List<int> Y = new List<int>();
        public static string richtung { get; set; }
        public static bool fertig;
        
        
        //public static void ListePunktfüllen()
        //{
        //    Punkt punkt = new Punkt();
        //    punkt.Konstrucktor(12, 5);
        //    ListPunkte.Add(punkt);
        //}
        //public static void Punktefärben(List<Punkt>  Liste)
        //{
        //    foreach (var item in Liste)
        //    {
        //        Rectangle PunktBlock = new Rectangle();
        //        PunktBlock.Fill = Brushes.Red;
        //        PunktBlock.
                


        //    }
        //}

        public static Rectangle BlockErzeugen() //neuer Block bzw. neues Label wird erzeugt und zurückgegeben
        {
            Rectangle newBlock = new Rectangle();
            newBlock.Fill = Brushes.Yellow; //Farbe des vorleufigen pacmans
            return newBlock;
        }

        public static void Bewegen(string Richtung) //bewegt den block in die gewünschte Richtung
        {
            if (Bloecke.Count > 1)
            {
                for (int i = Bloecke.Count - 1; i > 0; i--)
                {
                    X[i] = X[i - 1];
                    Y[i] = Y[i - 1];
                    Grid.SetRow(Bloecke[i], Y[i]);
                    Grid.SetColumn(Bloecke[i], X[i]);
                }
            }
            if (Richtung == "X+")
            {
                 if (X[0] + 1 < 24)
                {
                    X[0]++;
                    Grid.SetColumn(Bloecke[0], X[0]);
                }
            }
            else if (Richtung == "X-")
            {
                if (X[0] - 1 > -1)
                {
                    X[0]--;
                    Grid.SetColumn(Bloecke[0], X[0]);
                }
            }
            else if (Richtung == "Y+")
            {
                 if (Y[0] + 1 < 24)
                {
                    Y[0]++;
                    Grid.SetRow(Bloecke[0], Y[0]);
                }
            }
            else if (Richtung == "Y-")
            {
                 if (Y[0] - 1 > -1)
                {
                    Y[0]--;
                    Grid.SetRow(Bloecke[0], Y[0]);
                }
            }

        }

        //public static void CheckPunkte()
        //{
        //    //int counter = 0;
        //    //foreach (var item in Punkt.SpielfeldPunkteX)
        //    //{
        //    //    if (PacmanPlayer.X[0] == Punkt.SpielfeldPunkteX[counter] && PacmanPlayer.Y[0] == Punkt.SpielfeldPunkteY[counter])
        //    //    {
        //    //        PacmanPlayer.Y.Add(PacmanPlayer.Y[PacmanPlayer.Bloecke.Count - 1]);
        //    //        PacmanPlayer.X.Add(PacmanPlayer.X[PacmanPlayer.Bloecke.Count - 1]);


        //    //    }
        //    //    counter++;
        //    //}
            
            
        //        if (PacmanPlayer.X[0] == 5 && PacmanPlayer.Y[0] == 5)
        //        {
        //        /*
        //            PacmanPlayer.Y.Add(PacmanPlayer.Y[PacmanPlayer.Bloecke.Count - 1]);
        //            PacmanPlayer.X.Add(PacmanPlayer.X[PacmanPlayer.Bloecke.Count - 1]);
        //            */
               

                
                    
        //         }
            
        //}

        public static void PacmanBewegung()
        {
            fertig = false;
            if (richtung == "Unten")
            {
                Bewegen("Y+");
                
            }
            if (richtung == "Oben")
            {
                Bewegen("Y-");
                
            }
            if (richtung == "Links")
            {
                Bewegen("X-");
               
            }
            if (richtung == "Rechts")
            {
                Bewegen("X+");
              
            }
        }


    }
}
