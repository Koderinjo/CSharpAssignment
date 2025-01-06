using Presentation.MAUI.ViewModels;
using Business.Models;
using System.Windows.Input;

namespace Presentation.MAUI.Views;

public partial class MainPage : ContentPage
{
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
            ((MainPageViewModel)BindingContext).EditContactCommand.Execute(contact);
        }
    }
}