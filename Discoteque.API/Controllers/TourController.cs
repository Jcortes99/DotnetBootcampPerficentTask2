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
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        [Route("GetAllTours")]
        public async Task<IActionResult> GetAllTours(bool areReferencesLoaded = false)
        {
            var tours = await _tourService.GetTourAsync(areReferencesLoaded);
            return Ok(tours);
        }


        [HttpPost]
        [Route("CreateTourAsync")]
        public async Task<IActionResult> CreateTourAsync(Tour tour)
        {
            var result = await _tourService.CreateTour(tour);
            return Ok(result);
        }

        // [HttpPatch]
        // [Route("UpdateArtistAsync")]
        // public async Task<IActionResult> UpdateArtistAsync(Artist artist)
        // {
        //     return Ok();
        // }
    }
}
