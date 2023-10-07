namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;

        public SuperHeroController(ISuperHeroService superHeroService) =>
            _service = superHeroService;

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _service.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _service.GetSingleHero(id);

            if (result is null)
                return NotFound("Hero not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _service.AddHero(hero);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var result = await _service.UpdateHero(request);

            if (result is null)
                return NotFound("Hero not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _service.DeleteHero(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }
    }
}
