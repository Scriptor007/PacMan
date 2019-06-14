using System;
using System.Collections.Generic;
using System.IO;
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

namespace PacManGame
{
    /// <summary>
    /// Interaktionslogik für EndeWindow.xaml
    /// </summary>
    public partial class EndeWindow : Window
    {
        public EndeWindow()
        {
            InitializeComponent();
            int Punkte = Game.AnzahlDerPunkte * 10;

            LBL_Punkte.Content = Punkte;


        }

        private void Button_Click(object sender, RoutedEventArgs e) // speichern
        {

            
            string Punkte = Convert.ToString(LBL_Punkte.Content);
            string Name = Convert.ToString(TXT_name.Text);

            string ÜbergebeneInfos = (Name+","+Punkte);

            using (StreamWriter writetext = new StreamWriter("highscores.txt", append: true))
            {
                writetext.WriteLine(ÜbergebeneInfos);

            }







        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Game Spieleseite = new Game();

            Spieleseite.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();

            Main.Show();
            this.Close();
        }
    }
}
