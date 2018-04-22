using System;
namespace PokemonMVCApp.Models
{
    public class Note
    {

        public Guid NoteId { get; set; }

        public Guid Id { get; set; }

        public string NoteText { get; set; }

    }
}
