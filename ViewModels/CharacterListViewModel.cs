using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamenP3SC.Model;
using ExamenP3SC.Services;

namespace ExamenP3SC.ViewModels
{
    public class CharacterListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Character> _characters;
        private readonly ApiService _apiService;

        public ObservableCollection<Character> Characters
        {
            get => _characters;
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }

        public CharacterListViewModel()
        {
            _apiService = new ApiService();
            LoadCharacters();
        }

        public async Task LoadCharacters()
        {
            var characters = await _apiService.GetCharactersAsync();
            Characters = new ObservableCollection<Character>(characters);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
