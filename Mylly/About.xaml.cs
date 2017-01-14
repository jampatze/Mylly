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

namespace Mylly
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        // Attribuutti ohjelman nimelle
        private string program;

        // Konstruktori ohjelman nimelle
        public string Program
        {
            get { return program; }
            set { program = value; label_Program.Content = program; }
        }

        // Attribuutti ohjelman tekijälle
        private string author;

        // Konstruktori ohjelman tekijälle
        public string Author
        {
            get { return author; }
            set { author = value; label_Author.Content = author; }
        }

        // Attribuutti ohjelman versiolle
        private string version;

        // Konstruktori ohjelman veriolle
        public string Version
        {
            get { return version; }
            set { version = value; label_Version.Content = version; }
        }

        /// <summary>
        /// About-ikkuna
        /// </summary>
        public About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sulkee About-ikkunan Sulje-nappia painettaessa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
