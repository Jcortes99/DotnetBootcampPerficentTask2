using System.Security.Cryptography.X509Certificates;
using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;

namespace Discoteque.Business.Services;

public class TourService : ITourService
{
    private IUnitOfWork _unitOfWork;

    public TourService(IUnitOfWork unitofWork)
    {
        _unitOfWork = unitofWork;
    }

    /// <summary>
    /// Get the list of songs.
    /// Could be group by Album
    /// </summary>
    /// <param name="areReferencesLoaded">If true return the album</param>
    /// <returns>The list of songs</returns>
    public async Task<IEnumerable<Tour>> GetTourAsync(bool areReferencesLoaded)
    { 
        IEnumerable<Tour> tour;
        if(areReferencesLoaded)
        {
            tour = await _unitOfWork.TourRepository.GetAllAsync(null, x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
        }
        else
        {
            tour = await _unitOfWork.TourRepository.GetAllAsync();
        }

        return tour;
        
    }

    /// <summary>
    /// Get the song with an especific id
    /// </summary>
    /// <param name="id">The primary key of the song, an integer gt 0</param>
    /// <returns>The song with the id</returns>
    public async Task<Tour> GetTourById(int id)
    {
        var tour = await _unitOfWork.TourRepository.FindAsync(id);
        return tour;
    }

    public async Task<Tour> CreateTour(Tour tour)
    {
        var newTour = new Tour{
            Name = tour.Name,
            City = tour.City,
            IsSoldOut = tour.IsSoldOut,
            Date = tour.Date,
            ArtistId = tour.ArtistId
        };
        
        await _unitOfWork.TourRepository.AddAsync(newTour);
        await _unitOfWork.SaveAsync();
        return newTour;
    }
}