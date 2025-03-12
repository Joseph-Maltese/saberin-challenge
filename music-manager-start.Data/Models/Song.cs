using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Data.Models
{
    public sealed class Song
    {
        /*(*NEWBYME*) updating Song class fields 'Title', 'Artist', 'Album', and 'Genre' to contain 
        'Required' validation attributes; to make sure each field gets a value (cannot be whitespace)
        Help with validation attributes here: https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-9.0 */
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Album { get; set; }
        [Required]
        public string Genre { get; set; }
        //(*NEWBYME*) adding field for Art; if the user wishes to upload album art when adding a Song
        public byte[]? Art { get; set; } 
    }
}
