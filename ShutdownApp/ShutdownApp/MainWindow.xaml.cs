using System.Windows;
using ShutdownApp.Program;

namespace ShutdownApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            int minutes = 0;
            if (!int.TryParse(textSet.Text, out minutes))
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else
            {
                ShautdownProcess processShutdown = new ShautdownProcess();
                processShutdown.SetSutdown(minutes);
            }

        }
    }
}
