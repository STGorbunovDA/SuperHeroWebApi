﻿namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();

        Task<SuperHero?> GetSingleHero(int id);

        Task<List<SuperHero>> AddHero(SuperHero hero);

        Task<List<SuperHero>?> UpdateHero(SuperHero request);

        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
