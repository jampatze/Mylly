using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Mylly
{
    /// <summary>
    /// Interaction logic for MyllyBoard.xaml
    /// </summary>
    public partial class MyllyBoard : UserControl
    {
        // Event, joka tapahtuu kun lauta on täynnä
        public static readonly RoutedEvent BoardFull = 
            EventManager.RegisterRoutedEvent(
                "BoardFull",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(MyllyBoard));

        // Add/Remove BoardFull-eventille
        public event RoutedEventHandler BoardFullHandler
        {
            add { AddHandler(BoardFull, value); }
            remove { RemoveHandler(BoardFull, value); }
        }

        // DependencyProperty pelialueen taustavärille
        public static readonly DependencyProperty BackgroundFillProperty =
            DependencyProperty.Register(
                "BackgroundFill",
                typeof(String),
                typeof(MyllyBoard),
                new PropertyMetadata("#F5F5DC")
                );

        // BackgroundFillPropertyn get/set
        public String BackgroundFill
        {
            get { return (String)GetValue(BackgroundFillProperty); }
            set { SetValue(BackgroundFillProperty, value); }
        }

        // Valitun pelinappulan attribuutti
        GamePiece current;

        // bool sille, onko nappula valittuna
        public bool CurrentExists;

        // bool sille, ollaanko nappulaa lisäämässä
        bool IsBeingAdded = false;

        // bool sille, ollaanko nappulaa siirtämässä
        bool IsBeingMoved = false;

        // Lista, joka sisältää pelinappulat
        public List<GamePiece> pieces = new List<GamePiece>();

        // Pelinappuloiden värin attribuutti
        public String pieceColor;

        /// <summary>
        /// MyllyBoard-konstruktori
        /// </summary>
        public MyllyBoard()
        {
            InitializeComponent();
            grid1.MouseLeftButtonDown += Grid1_MouseLeftButtonDown;
        }

        /// <summary>
        /// Tapahtuma, joka tapahtuu kun hiiren vasenta painiketta painetaan pelilaudalla
        /// Ehkä olisi voinut tehdä kahdella tapahtumalla, mutta tein näin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridC point = GetGridC(this, e);

            CustomCanvas canv = (CustomCanvas)grid1.Children.Cast<UIElement>().First(i => Grid.GetRow(i) == point.X && Grid.GetColumn(i) == point.Y);

            if (IsBeingAdded) AddingPiece(canv);

            if (IsBeingMoved) MovingPiece(canv);              
        }

        /// <summary>
        /// Lisää pelinappulan kentälle haluttuun paikkaan
        /// </summary>
        /// <param name="canv">CustomCanvas, johon nappula lisätään</param>
        public void AddingPiece(CustomCanvas canv)
        {
            if (CustomCanvas.GetCanAddPiece(canv) && !CustomCanvas.GetHasPiece(canv))
            {
                GamePiece gp = new GamePiece();
                if (pieceColor != null) gp.FillColor = pieceColor;
                pieces.Add(gp);

                canv.Children.Add(gp);

                gp.CheckedHandler += UpdateCurrent;

                CustomCanvas.SetHasPiece(canv, true);
                if (pieces.Count > 4)
                {
                    RaiseEvent(new RoutedEventArgs(BoardFull));
                }
                IsBeingAdded = false;
            }
            else IsBeingAdded = false;
        }

        /// <summary>
        /// Siirtää pelinappulan paikasta toiseen
        /// Luo uuden nappulan, jotta sirretty nappula ei olisi valittu
        /// </summary>
        /// <param name="canv">CustomCanvas, johon nappula siirretään</param>
        public void MovingPiece(CustomCanvas canv)
        {
            String oldC = current.FillColor;
            CustomCanvas canvOrg = (CustomCanvas)current.Parent;
            CustomCanvas.SetHasPiece(canvOrg, false);
            canvOrg.Children.Remove(current);
            pieces.Remove(current);
            CurrentExists = false;

            if (CustomCanvas.GetCanAddPiece(canv) && !CustomCanvas.GetHasPiece(canv))
            {
                GamePiece gp = new GamePiece();
                gp.FillColor = oldC;
                pieces.Add(gp);

                canv.Children.Add(gp);

                gp.CheckedHandler += UpdateCurrent;
            }

                IsBeingMoved = false;
        }
    

        /// <summary>
        /// Metodi nappulan lisäämiselle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddPiece(object sender, RoutedEventArgs e)
        {
            IsBeingAdded = true;
        }

        /// <summary>
        /// Metodi nappulan siirtämiselle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MovePiece(object sender, RoutedEventArgs e)
        {
            IsBeingMoved = true;
        }


        /// <summary>
        /// Hakee hiirellä painetun pelineliön koordinantit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Hiirellä painetun pelineliön koordinaatit GridC-oliona</returns>
        private GridC GetGridC(object sender, MouseButtonEventArgs e)
        {
                var point = Mouse.GetPosition(grid1);

                int row = 0;
                int col = 0;
                double accumulatedH = 0.0;
                double accumulatedW = 0.0;

                foreach (var rowDefinition in grid1.RowDefinitions)
                {
                    accumulatedH += rowDefinition.ActualHeight;
                    if (accumulatedH >= point.Y) break;
                    row++;
                }

                foreach (var columnDefinition in grid1.ColumnDefinitions)
                {
                    accumulatedW += columnDefinition.ActualWidth;
                    if (accumulatedW >= point.X) break;
                    col++;
                }

           return new GridC(row, col);
         }

        /// <summary>
        /// Poistaa valittuna olevan (current) pelinappulan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RemovePiece(object sender, RoutedEventArgs e)
        {
            CustomCanvas canv = (CustomCanvas)current.Parent;
            CustomCanvas.SetHasPiece(canv, false);
            canv.Children.Remove(current);
            pieces.Remove(current);
            CurrentExists = false;
        }

        /// <summary>
        /// Päivittää valitun pelinappulan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCurrent(object sender, RoutedEventArgs e)
        {
            CurrentExists = true;
            current = sender as GamePiece;
        }

        /// <summary>
        /// Aloittaa uuden pelin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NewGame(object sender, RoutedEventArgs e)
        {
            foreach (GamePiece gp in pieces)
            {
                CustomCanvas canv = (CustomCanvas)gp.Parent;
                CustomCanvas.SetHasPiece(canv, false);
                canv.Children.Remove(gp);
            }

            pieces = new List<GamePiece>();
        }

        /// <summary>
        /// Avaa pelialueen tulostusdialogin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Print(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { dialog.PrintVisual(this, "Tulostusalue"); }
        }
    }
}
