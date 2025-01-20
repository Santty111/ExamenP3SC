using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using ExamenP3SC.Model;

namespace ExamenP3SC.ViewModels
{
    public class CharacterDetailViewModel : INotifyPropertyChanged
    {
        private Character _selectedCharacter;
        private readonly SQLiteConnection _database;

        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged();
            }
        }

        public CharacterDetailViewModel()
        {
            _database = new SQLiteConnection(System.IO.Path.Combine(FileSystem.AppDataDirectory, "characters.db"));
            _database.CreateTable<LocalCharacter>();
        }

        public void SaveCharacter()
        {
            if (SelectedCharacter != null)
            {
                var localCharacter = new LocalCharacter
                {
                    Name = SelectedCharacter.Name,
                    Description = SelectedCharacter.Description,
                    ImageUrl = SelectedCharacter.ImageUrl
                };
                _database.Insert(localCharacter);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
