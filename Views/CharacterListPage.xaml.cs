using ExamenP3SC.ViewModels;
using ExamenP3SC.Model;


namespace ExamenP3SC.Views;

public partial class CharacterListPage : ContentPage
{
    public CharacterListPage()
    {
        InitializeComponent();
        BindingContext = new CharacterListViewModel();
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Character selectedCharacter)
        {
            var detailPage = new CharacterDetailPage();
            detailPage.BindingContext = new CharacterDetailViewModel { SelectedCharacter = selectedCharacter };
            await Navigation.PushAsync(detailPage);
        }
    }
}