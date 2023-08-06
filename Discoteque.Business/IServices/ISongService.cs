using Discoteque.Data.Models;
namespace Discoteque.Business.IServices;

public interface ISongService
{
/// <summary>
/// Finds all Songs in the EF DB
/// </summary>
/// <param name="areReferencesLoaded">Returns associated Album per Song if true</param>
/// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
Task<IEnumerable<Song>> GetSongAsync(bool areReferencesLoaded);
/// <summary>
/// Returns a song with an especific Id.
/// </summary>
/// <param name="id">PK of the song in the DB</param>
/// <returns>A <see cref="Song" /> </returns>
Task<Song> GetSongById(int id);
/// <summary>
/// Returns all songs with an especific name.
/// </summary>
/// <param name="name">A string with the name of the song you are looking for</param>
/// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
Task<IEnumerable<Song>> GetSongByName(string name);

/// <summary>
/// Returns all albums published by the artist.
/// </summary>
/// <param name="artist">A string with the name of an <see cref="Artist"/> Repo</param>
/// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
// Task<IEnumerable<Song>> GetSongByArtist(Artist artist);

/// <summary>
/// returns all songs with a duration between initialDuration and finalDuration
/// </summary>
/// <param name="initialDuration">The initial year, min value 1900</param>
/// <param name="finalDuration">the latest year, max value 2025</param>
/// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
Task<IEnumerable<Song>> GetSongByDuration(int initialDuration);

/// <summary>
/// creates an album
/// </summary>
/// <param name="album"></param>
/// <returns></returns>
Task<Song> CreateSong(Song song);

}
