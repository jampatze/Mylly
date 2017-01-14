using System;
using System.Windows;
using System.Windows.Controls;


namespace Mylly
{
    /// <summary>
    /// Interaction logic for CustomCanvas.xaml
    /// </summary>
    public partial class CustomCanvas : Canvas
    {

        // Puolikkaan canvaksen leveyden DependencyProperty
        public static readonly DependencyProperty HalfWidthProperty =
            DependencyProperty.Register(
                "HalfWidth", 
                typeof(double), 
                typeof(CustomCanvas), 
                new PropertyMetadata(0.0));

        // Puolikkaan canvaksen propertyn get/set
        public double HalfWidth
        {
            get { return (double)GetValue(HalfWidthProperty); }
            set { SetValue(HalfWidthProperty, value); }
        }

        // Puolikkaan canvaksen korkeuden DependencyProperty
        public static readonly DependencyProperty HalfHeightProperty =
            DependencyProperty.Register(
                "HalfHeight",
                typeof(double),
                typeof(CustomCanvas),
                new PropertyMetadata(0.0));

        // Puolikkaan canvaksen korkeuden DependencyPropertyn get/set
        public double HalfHeight
        {
            get { return (double)GetValue(HalfHeightProperty); }
            set { SetValue(HalfHeightProperty, value); }
        }

        // DependencyProperty, joka määrittää voiko CustomCanvakselle lisätä pelinappulan
        public static readonly DependencyProperty CanAddPieceProperty = 
            DependencyProperty.RegisterAttached(
                "CanAddPiece",
                typeof(bool),
                typeof(CustomCanvas),
                new FrameworkPropertyMetadata(false));

        // Setteri CanAddPiecePropertylle
        public static void SetCanAddPiece(UIElement element, bool value)
        {
            element.SetValue(CanAddPieceProperty, value);
        }

        // Getteri CanAddPiecePropertylle
        public static bool GetCanAddPiece(UIElement element)
        {
            return (bool)element.GetValue(CanAddPieceProperty);
        }

        // DependencyProperty sille, onko CustomCanvaksella pelinappula
        public static readonly DependencyProperty HasPieceProperty = 
            DependencyProperty.RegisterAttached(
                "HasPiece",
                typeof(bool),
                typeof(CustomCanvas),
                new FrameworkPropertyMetadata(false));

        // DependencyPropertyn set
        public static void SetHasPiece(UIElement element, bool value)
        {
            element.SetValue(HasPieceProperty, value);
        }

        // DependencyPropertyn get
        public static bool GetHasPiece(UIElement element)
        {
            return (bool)element.GetValue(HasPieceProperty);
        }


        /// <summary>
        /// Konstruktori CustomCanvakselle
        /// </summary>
        public CustomCanvas()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            SizeChanged += CustomCanvas_SizeChanged;
        }

        /// <summary>
        /// Tapahtuma, joka tapahtuu kun CustomCanvaksen koko muuttuu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CustomCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            HalfWidth = ActualWidth / 2;
            HalfHeight = ActualHeight / 2;
        }
    }
}
