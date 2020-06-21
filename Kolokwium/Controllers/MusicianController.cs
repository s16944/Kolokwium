using Kolokwium.DTO;
using Kolokwium.Mappers;
using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IDbService _dbService;
        private readonly IMapper<Musician, MusicianResponse> _musicianToResponseMapper;

        public MusicianController(IDbService dbService, IMapper<Musician, MusicianResponse> musicianToResponseMapper)
        {
            _dbService = dbService;
            _musicianToResponseMapper = musicianToResponseMapper;
        }

        [HttpGet("{musicianId}")]
        public IActionResult GetMusicianDetails(int musicianId)
        {
            try
            {
                var musician = _dbService.GetMusicianWithTracksById(musicianId);
                var response = _musicianToResponseMapper.Map(musician);
                return Ok(response);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}