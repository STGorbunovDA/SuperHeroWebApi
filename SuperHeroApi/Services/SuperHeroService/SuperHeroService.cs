namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync(); 
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null) return null; // Следует воспользоваться паттерном Null Object Pattern (Паттерн "Пустой объект")

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return null; // Следует воспользоваться паттерном Null Object Pattern (Паттерн "Пустой объект")
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(request.Id);

            if (hero is null) return null; // Следует воспользоваться паттерном Null Object Pattern (Паттерн "Пустой объект")

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
