using System.Security.Cryptography.X509Certificates;
using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;

namespace Discoteque.Business.Services;

public class SongService : ISongService
{
    private IUnitOfWork _unitOfWork;

    public SongService(IUnitOfWork unitofWork)
    {
        _unitOfWork = unitofWork;
    }

    /// <summary>
    /// Get the list of songs.
    /// Could be group by Album
    /// </summary>
    /// <param name="areReferencesLoaded">If true return the album</param>
    /// <returns>The list of songs</returns>
    public async Task<IEnumerable<Song>> GetSongAsync(bool areReferencesLoaded)
    {
        IEnumerable<Song> songList;
        if(areReferencesLoaded)
        {
            songList = await _unitOfWork.SongRepository.GetAllAsync(null, x => x.OrderBy(x => x.Id), new Album().GetType().Name);
        }
        else
        {
            songList = await _unitOfWork.SongRepository.GetAllAsync();
        }

        return songList;
        
    }

    /// <summary>
    /// Get the song with an especific id
    /// </summary>
    /// <param name="id">The primary key of the song, an integer gt 0</param>
    /// <returns>The song with the id</returns>
    public async Task<Song> GetSongById(int id)
    {
        var song = await _unitOfWork.SongRepository.FindAsync(id);
        return song;
    }

    /// <summary>
    /// Get the list of song with that name
    /// </summary>
    /// <param name="name">String, the name of the song</param>
    /// <returns>A <see cref="List"/> of songs</returns>
    public async Task<IEnumerable<Song>> GetSongByName(string name)
    {
        IEnumerable<Song> songs;        
        songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Name.Equals(name), x => x.OrderBy(x => x.Id), new Song().GetType().Name);
        return songs;
    }


    public async Task<Song> CreateSong(Song song)
    {
        try
        {
            var newSong = new Song{
                Name = song.Name,
                Duration = song.Duration,
                AlbumId = song.AlbumId
            };
            
            await _unitOfWork.SongRepository.AddAsync(newSong);
            await _unitOfWork.SaveAsync();
            return newSong;
        }
        catch (Exception ex)
        {
            var newSong = new Song{
                Name = "null",
                Duration = 0,
                AlbumId = -1
            };
            return newSong;
        }
    }

    public async Task<IEnumerable<Song>> GetSongByDuration(int duration)
    {
        IEnumerable<Song> songs;
        songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Duration.Equals(duration));
        return songs;
    }
}