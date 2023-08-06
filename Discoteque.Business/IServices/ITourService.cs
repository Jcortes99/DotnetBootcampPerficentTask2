using Discoteque.Data.Models;
namespace Discoteque.Business.IServices;

public interface ITourService
{
/// <summary>
/// Finds all Songs in the EF DB
/// </summary>
/// <param name="areReferencesLoaded">Returns associated Album per Song if true</param>
/// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
Task<IEnumerable<Tour>> GetTourAsync(bool areReferencesLoaded);
/// <summary>
/// Returns a song with an especific Id.
/// </summary>
/// <param name="id">PK of the song in the DB</param>
/// <returns>A <see cref="Song" /> </returns>
Task<Tour> GetTourById(int id);

/// <summary>
/// creates an album
/// </summary>
/// <param name="album"></param>
/// <returns></returns>
Task<Tour> CreateTour(Tour tour);

}
