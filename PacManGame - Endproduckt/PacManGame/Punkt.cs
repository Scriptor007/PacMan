using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame
{
    class Punkt:Game
    {
       static public int PunktX;
       static public int PunktY;

        static public void Konstruktor(int X , int Y)
        {
            PunktX = X;
            PunktY = Y;
        }

        public static List<int> SpielfeldPunkteX = new List<int>();
        public static List<int> SpielfeldPunkteY = new List<int>();
               

        public static void neuePosition()
        {

            SpielfeldPunkteX.Add(5);
            SpielfeldPunkteX.Add(5);
            SpielfeldPunkteX.Add(5);
            SpielfeldPunkteX.Add(5);
            SpielfeldPunkteX.Add(5);
            SpielfeldPunkteX.Add(5);
            SpielfeldPunkteX.Add(5);
            SpielfeldPunkteX.Add(6);
            SpielfeldPunkteX.Add(7);
            SpielfeldPunkteX.Add(8);
            SpielfeldPunkteX.Add(9);
            SpielfeldPunkteX.Add(10);

            SpielfeldPunkteY.Add(5);
            SpielfeldPunkteY.Add(6);
            SpielfeldPunkteY.Add(7);
            SpielfeldPunkteY.Add(8);
            SpielfeldPunkteY.Add(9);
            SpielfeldPunkteY.Add(10);
            SpielfeldPunkteY.Add(11);
            SpielfeldPunkteY.Add(11);
            SpielfeldPunkteY.Add(11);
            SpielfeldPunkteY.Add(11);
            SpielfeldPunkteY.Add(11);
            SpielfeldPunkteY.Add(11);
            
        }

        

    }
}
