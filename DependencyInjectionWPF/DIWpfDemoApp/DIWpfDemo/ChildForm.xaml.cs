using DIWpfDemoApp.Library;
using System.Windows;

namespace DIWpfDemo;

public partial class ChildForm : Window
{
    private readonly IDataAccess _dataAccess;

    public ChildForm(IDataAccess dataAccess)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
        txtDataAccessInfo.Text = _dataAccess.GetData();
    }
}
