using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamenP3SC.Model;

namespace ExamenP3SC.ViewModels
{
    public class SavedCharacterListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<LocalCharacter> _savedCharacters;
        private readonly SQLiteConnection _database;

        public ObservableCollection<LocalCharacter> SavedCharacters
        {
            get => _savedCharacters;
            set
            {
                _savedCharacters = value;
                OnPropertyChanged();
            }
        }

        public SavedCharacterListViewModel()
        {
            _database = new SQLiteConnection(System.IO.Path.Combine(FileSystem.AppDataDirectory, "characters.db"));
            _database.CreateTable<LocalCharacter>();
            LoadSavedCharacters();
        }

        private void LoadSavedCharacters()
        {
            SavedCharacters = new ObservableCollection<LocalCharacter>(_database.Table<LocalCharacter>().ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
