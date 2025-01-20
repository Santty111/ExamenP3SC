using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3SC.Model
{
    public class MarvelCharactersc
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string DetailUrl { get; set; }
    }

    public class LocalMarvelCharacter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
    }

}
