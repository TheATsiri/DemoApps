using ApiConsumerLibrary;
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

namespace ApiConsumerUI
{
    /// <summary>
    /// Interaction logic for SunInfo.xaml
    /// </summary>
    public partial class SunInfo : Window
    {
        public SunInfo()
        {
            InitializeComponent();
        }

        private async void loadSunInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var sunInfo = await SunResultProcessor.LoadSunInformation();

            sunriseText.Text = sunInfo.Sunrise.ToLocalTime().ToShortTimeString();
            sunsetText.Text = sunInfo.Sunset.ToLocalTime().ToShortTimeString();

        }
    }
}
