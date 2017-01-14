using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Mylly
{
    /// <summary>
    /// Interaction logic for GamePiece.xaml
    /// </summary>
    public partial class GamePiece : UserControl
    {
        // Eventti, joka lähtee MyllyBoardille kun GamePiece on valittuna
        public static readonly RoutedEvent Checked = EventManager.RegisterRoutedEvent(
            "Checked",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(GamePiece));

        // Add/Remove Checked-eventille
        public event RoutedEventHandler CheckedHandler
        {
            add { AddHandler(Checked, value); }
            remove { RemoveHandler(Checked, value); }
        }

        // Pelinappuloiden värin DependencyProperty
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.Register(
                "FillColor",
                typeof(String),
                typeof(GamePiece),
                new PropertyMetadata("#FA8072")
                );

        // Pelinappulan värin get/set
        public String FillColor
        {
            get { return (String)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        /// <summary>
        /// Konstruktori GamePiece:lle
        /// </summary>
        public GamePiece()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Metodi, joka laukaisee Checked-eventin kun GamePieceä painetaan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GamePiece_Checked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Checked));
        } 
    }
}
