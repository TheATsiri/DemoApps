using CnCDemoApp.Enums;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CnCDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public E_ComPortStatus ComPortStatus { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            cbxComPorts.ItemsSource = LoadComPorts();
            ComPortStatus = E_ComPortStatus.None;
            ConnectionSymbol.Fill = new SolidColorBrush(Colors.Transparent);
        }
        private void btnConnectDisconnet_Click(object sender, RoutedEventArgs e)
        {
            SetColorToComStatus(sender);
        }
        private List<string> LoadComPorts()
        {
            List<string> comports = new();
            comports = SerialPort.GetPortNames().ToList();
            return comports;
        }
        private void SetColorToComStatus(object sender)
        {
            var ConnectToPortButton = (Button)sender;
            if (ConnectToPortButton.Content.ToString() == "Connect")
            {
                ConnectionSymbol.Fill = new SolidColorBrush(Colors.Green);
                btnConnectDisconnet.Content = "Disconnect";

            }
            else if (ConnectToPortButton.Content.ToString() == "Disconnect")
            {
                ConnectionSymbol.Fill = new SolidColorBrush(Colors.Red);
                btnConnectDisconnet.Content = "Connect";
            }
        }
    }
}