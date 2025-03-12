using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }

            //(*NEWBYME*) checking for duplicate songs (matching Title, Artist, Album, and Genre)
            //Help from: https://learn.microsoft.com/en-us/answers/questions/1403250/avoiding-duplicate-inserts-with-entity-framework
            string title = song.Title.ToLower();
            string artist = song.Artist.ToLower();
            string album = song.Album.ToLower();
            string genre = song.Genre.ToLower();

            var existingRecord = await _context.Songs.FirstOrDefaultAsync(s => 
                s.Title.ToLower() == title &&
                s.Artist.ToLower() == artist &&
                s.Album.ToLower() == album &&
                s.Genre.ToLower() == genre);

            if(existingRecord != null){
                return Conflict("A song with this Title, Artist, Album, and Genre already exists.");
            }
            
            //at this point, the Song to add is valid
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
