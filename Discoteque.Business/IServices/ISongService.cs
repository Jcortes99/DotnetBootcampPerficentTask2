using System;
using Discoteque.Data.Models;

namespace Discoteque.Business.IServices
{
    public interface ISongService
    {
    /// <summary>
    /// Finds all Songs in the EF DB
    /// </summary>
    /// <param name="areReferencesLoaded">Returns associated Album per Song if true</param>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Album>> GetSongAsync(bool areReferencesLoaded);
    /// <summary>
    /// Returns a song with an especific Id.
    /// </summary>
    /// <param name="id">PK of the song in the DB</param>
    /// <returns>A <see cref="Song" /> </returns>
    Task<IEnumerable<Album>> GetSongById(int id);
    /// <summary>
    /// Returns all songs with an especific name.
    /// </summary>
    /// <param name="name">A string with the name of the song you are looking for</param>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Album>> GetSongByName(string name);
    
    /// <summary>
    /// Returns all albums published by the artist.
    /// </summary>
    /// <param name="artist">A string with the name of an <see cref="Artist"/> Repo</param>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Album>> GetSongByArtist(Artist artist);
    
    /// <summary>
    /// returns all songs with a duration between initialDuration and finalDuration
    /// </summary>
    /// <param name="initialDuration">The initial year, min value 1900</param>
    /// <param name="finalDuration">the latest year, max value 2025</param>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Album>> GetSongByDuration(int initialDuration, int finalDuration);
    
    /// <summary>
    /// Returns all songs that belong an album
    /// </summary>
    /// <param name="album">A album from the <see cref="Album"/> list</param>
    /// <returns>A <see cref="List" /> of <see cref="Album"/> </returns>
    Task<IEnumerable<Album>> GetAlbumsByAlbum(Album album);
    
    }
}