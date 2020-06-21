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
        private readonly IMapper<MusicianRequest, Musician> _requestToMusicianMapper;

        public MusicianController(IDbService dbService, IMapper<Musician, MusicianResponse> musicianToResponseMapper,
            IMapper<MusicianRequest, Musician> requestToMusicianMapper)
        {
            _dbService = dbService;
            _musicianToResponseMapper = musicianToResponseMapper;
            _requestToMusicianMapper = requestToMusicianMapper;
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

        [HttpPost]
        public IActionResult AddMusician(MusicianRequest request)
        {
            var musician = _requestToMusicianMapper.Map(request);
            _dbService.AddMusicianWithTracks(musician);
            var response = _musicianToResponseMapper.Map(musician);
            return Created($"/api/musicians/{musician.IdMusician}", response);
        }
    }
}