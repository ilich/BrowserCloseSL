using System.Windows;
using System.Windows.Controls;

namespace BrowserCloseSL.Sample
{
    public partial class MainPage : UserControl
    {
        private readonly App _app = (App)Application.Current;

        public MainPage()
        {
            InitializeComponent();
            _app.BrowserCloseListener.BeforeClose += OnBeforeBrowserClose;
            SetupView();
        }

        private void OnBeforeBrowserClose(object sender, BeforeCloseEventArgs e)
        {
            e.CanClose = string.IsNullOrEmpty(SampleText.Text);
            if (!e.CanClose)
            {
                e.Confirmation = "Sample Text has been modified. Are you sure you want to exit the application?";
            }
        }

        private void OnStartCloseListening(object sender, RoutedEventArgs e)
        {
            _app.BrowserCloseListener.IsEnabled = true;
            SetupView();
        }

        private void OnStopCloseListening(object sender, RoutedEventArgs e)
        {
            _app.BrowserCloseListener.IsEnabled = false;
            SetupView();
        }

        private void SetupView()
        {
            Start.IsEnabled = !_app.BrowserCloseListener.IsEnabled;
            Stop.IsEnabled = _app.BrowserCloseListener.IsEnabled;
            Status.Text = _app.BrowserCloseListener.IsEnabled ?
                "Browser Close Listening is running" :
                "Browser Close Listening has been stopped";
        }
    }
}
