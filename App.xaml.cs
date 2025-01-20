using ExamenP3SC.Views;

namespace ExamenP3SC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new CharacterListPage());
        }
    }


}
