using System;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;


namespace Mylly
{
    /// <summary>
    /// Interaction logic for ColorPick.xaml
    /// </summary>
    public partial class ColorPick : Window
    {
        // Attribuutti pelinappuloiden värille
        private String pieceColor;

        // Pelinappuloiden värin get/set
        public String PieceColor
        {
            get { return pieceColor; }
            set { pieceColor = value; }
        }

        // Attribuutti kentän värille
        private String boardColor;

        // Kentän värin get/set
        public String BoardColor
        {
            get { return boardColor; }
            set { boardColor = value; }
        }

        /// <summary>
        /// Konstruktori ColorPick-ikkunalle
        /// </summary>
        public ColorPick()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Valitsee värit kun OK-painiketta painetaan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ColorPick_SetColors(object sender, RoutedEventArgs e)
        {
            if (colorPiece.SelectedColor != null)
            {
                Color c1 = (Color)colorPiece.SelectedColor;
                PieceColor = ConvertToHex(c1);
            }
               
            if (colorBoard.SelectedColor != null)
            {
                Color c2 = (Color)colorBoard.SelectedColor;
                BoardColor = ConvertToHex(c2);
            }

            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Sulkee ikkunan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ColorPick_Close(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Muuntaa halutun värin hexaluvuksi
        /// </summary>
        /// <param name="c">Haluttu väri</param>
        /// <returns>Väriä vastaava hexaluku</returns>
        private static String ConvertToHex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}
