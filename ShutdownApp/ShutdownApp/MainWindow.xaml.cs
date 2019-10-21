using System.Windows;
using ShutdownApp.Program;

namespace ShutdownApp
{
    public partial class MainWindow : Window
    {

        private ShutdownProcess _shutdownProcess = new ShutdownProcess();

        public MainWindow()
        {
            InitializeComponent();
            timer.Content = _shutdownProcess.InitializeTaskSheduler();
        }

        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            int minutes;

            if (!int.TryParse(textSet.Text, out minutes))
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else
            {
                _shutdownProcess.SetShutdownTaskSheduler(minutes);

                buttonCancel.IsEnabled = true;
            }

            
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            _shutdownProcess.CancelShutdownTaskSheduler();

            buttonCancel.IsEnabled = false;
        }
    }
}
