namespace SuperHeroApi.Data
{
    /*
        * PM> cd .\SuperHeroApi
          PM> dotnet ef migrations add InitialCreate
              Build started...
              Build succeeded.
              Done. To undo this action, use 'ef migrations remove'
        * dotnet ef database update
    */
    public class DataContext : DbContext
    {
        public DbSet<SuperHero> SuperHeroes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2BUVSP5;Initial Catalog=TestDb;User ID=user;Password=user;TrustServerCertificate=true"); 
        }


    }
}
