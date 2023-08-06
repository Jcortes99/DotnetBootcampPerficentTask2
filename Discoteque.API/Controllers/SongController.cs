using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;

namespace Discoteque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("GetAllSongs")]
        public async Task<IActionResult> GetAllSongs(bool areReferencesLoaded = false)
        {
            var songs = await _songService.GetSongAsync(areReferencesLoaded);
            return Ok(songs);
        }


        [HttpPost]
        [Route("CreateSongAsync")]
        public async Task<IActionResult> CreateSongAsync(Song song)
        {
            var result = await _songService.CreateSong(song);
            return Ok(result);
        }

        // [HttpPatch]
        // [Route("UpdateArtistAsync")]
        // public async Task<IActionResult> UpdateSongAsync(Artist artist)
        // {

        //     return Ok();
        // }

        [HttpGet]
        [Route("GetSongById")]
        public async Task<IActionResult> GetSongById(int id)
        {
            var song = await _songService.GetSongById(id);
            return Ok(song);
        }
    }
}
