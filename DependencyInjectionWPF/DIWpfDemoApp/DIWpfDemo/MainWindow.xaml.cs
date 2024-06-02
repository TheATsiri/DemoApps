using DIWpfDemo.StartupHelpers;
using DIWpfDemoApp.Library;
using System.Windows;

namespace DIWpfDemo;

public partial class MainWindow : Window
{
    private readonly IDataAccess _dataAccess;
    private readonly IAbstractFactory<ChildForm> _factory;

    public MainWindow(IDataAccess dataAccess, IAbstractFactory<ChildForm> factory)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
        _factory = factory;

    }

    private void GetDataBtn_Click(object sender, RoutedEventArgs e)
    {
        txtGetDataAccess.Text = _dataAccess.GetData();
    }

    private void OpenChildFormBtn_Click(object sender, RoutedEventArgs e)
    {
        _factory.Create().Show();
    }
}