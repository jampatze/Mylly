using System.Windows;
using System.Windows.Input;
using System.Media;
using System;

namespace Mylly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Attribuutti, joka määrittää onko peli käynnissä
        bool GameOn = false;

        // Ääni joka soi kun 5 nappia on asetettu laudalle
        SoundPlayer BoardFullSound = new SoundPlayer(Mylly.Properties.Resources.heres_your_winner);

        /// <summary>
        /// Konstruktori MainWindowlle
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            myllyBoard1.BoardFullHandler += BoardIsFull; 
        }

        /// <summary>
        /// Avaa About-ikkunan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Program = "GKO harjoitustyö - taso 1";
            about.Author = "Jami Laamanen";
            about.Version = "0.9.9";
            about.Show();
        }


        /// <summary>
        /// Avaa Asetukset-ikkunan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            ColorPick cp = new ColorPick();

            Nullable<bool> result = cp.ShowDialog();

            if (result == true)
            {
                if (cp.PieceColor != null) myllyBoard1.pieceColor = cp.PieceColor;
                if (cp.BoardColor != null) myllyBoard1.BackgroundFill = cp.BoardColor;
            }
        }

        /// <summary>
        /// Tapahtuu kun pelilauta on täynnä
        /// BoardIsFull-event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardIsFull(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            BoardFullSound.Play();
        }

        /// <summary>
        /// Uuden pelinappulan lisäämisen komento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPiece_Executed(object sender, RoutedEventArgs e)
        {
            myllyBoard1.AddPiece(sender, e);
            GameOn = true;
        }


        /// <summary>
        /// Voidaanko uusi nappula lisätä
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPiece_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (myllyBoard1.pieces.Count <= 4) e.CanExecute = true;
        }

        /// <summary>
        /// CanExecute-metodi, joka tarkistaa voidaanko pelinappula poistaa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemovePiece_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (myllyBoard1.CurrentExists) e.CanExecute = true;
        }

        /// <summary>
        /// Pelinappulan poistamisen komento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemovePiece_Executed(object sender, RoutedEventArgs e)
        {
            myllyBoard1.RemovePiece(sender, e);
        }

        /// <summary>
        /// Tarkistaa, voidaanko nappulaa liikuttaa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovePiece_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (myllyBoard1.CurrentExists) e.CanExecute = true;
        }

        /// <summary>
        /// Pelinappulan siirtämisen komento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovePiece_Executed(object sender, RoutedEventArgs e)
        {
            myllyBoard1.MovePiece(sender, e);
        }


        /// <summary>
        /// Tarkistaa voidaanko uusi peli aloittaa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (GameOn) e.CanExecute = true;
        }

        /// <summary>
        /// Pelin aloittamisen komento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame_Executed(object sender, RoutedEventArgs e)
        {
            myllyBoard1.NewGame(sender, e);
            GameOn = false;
        }

        /// <summary>
        /// Pelialueen tulostamisen komento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Executed(object sender, RoutedEventArgs e)
        {
            myllyBoard1.Print(sender, e);
        }

        /// <summary>
        /// Avaa web-sivun jossa on ohjeita ohjleman käytöstä
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://users.jyu.fi/~jaanella/ITKP212/harkka/Ohje.html");
        }
    }
}
