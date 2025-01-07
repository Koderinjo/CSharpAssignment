using Presentation.MAUI.ViewModels;
using Business.Models;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.MAUI.Views;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var contact = e.SelectedItem as Business.Models.Contact;
            ((MainPageViewModel)BindingContext).GoToContactDetailsPage(contact);
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}