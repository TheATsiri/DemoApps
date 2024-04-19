using ApiConsumerLibrary;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ApiConsumerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNumber = 0;
        private int currentNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            previousImageButton.IsEnabled = true;
            nextImageButton.IsEnabled = false;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadComicImage();
        }
        private async Task LoadComicImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadImageComic(imageNumber);

            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
            }
            currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource);
        }

        private async void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 1)
            {
                currentNumber -= 1;
                nextImageButton.IsEnabled = true;
                await LoadComicImage(currentNumber);

                if (currentNumber == 1)
                {
                    previousImageButton.IsEnabled = false;
                }
            }
        }

        private async void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber < maxNumber)
            {
                currentNumber += 1;
                previousImageButton.IsEnabled = true;
                await LoadComicImage(currentNumber);

                if (currentNumber == maxNumber)
                {
                    nextImageButton.IsEnabled = false;
                }
            }
        }

        private void sunInformationButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}