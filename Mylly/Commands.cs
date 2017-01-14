using System.Windows.Input;

namespace Mylly
{
    /// <summary>
    /// Luokka, joka sisältää pääikkunan käyttämät komennot
    /// </summary>
    public static class Commands
    {
        // Komento uuden nappulan lisäämiseen
        public static readonly RoutedCommand NewPiece = new RoutedCommand(
            "NewPiece",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Control)
            });

        // Komento nappulan poistamiselle
        public static readonly RoutedCommand RemovePiece = new RoutedCommand(
            "RemovePiece",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            });

        // Komento uuden pelin aloittamiselle
        public static readonly RoutedCommand NewGame = new RoutedCommand(
            "NewGame",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.N, ModifierKeys.Control)
            });

        // Komento nappulan siirtämiselle
        public static readonly RoutedCommand MovePiece = new RoutedCommand(
            "NewPiece",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control)
            });

        // Komento MyllyBoardin tulostamiselle
        public static readonly RoutedCommand Print = new RoutedCommand(
            "Print",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.P, ModifierKeys.Control)
            });
    }
}
