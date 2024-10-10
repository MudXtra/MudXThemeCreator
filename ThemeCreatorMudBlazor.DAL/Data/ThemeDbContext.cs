using Microsoft.EntityFrameworkCore;
using ThemeCreatorMudBlazor.DAL.Models;

namespace ThemeCreatorMudBlazor.DAL.Data
{
    public class ThemeDbContext(DbContextOptions<ThemeDbContext> options) : DbContext(options)
    {
        public void Initialize()
        {
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
            {
                //var seed = SeedData.GetData();
                //foreach (var s in seed)
                //{
                //	s.Id = 0;
                //}
                //TableName!.AddRange(seed);
                //SaveChanges();
            }
            else
            {
                this.Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding
            modelBuilder.Entity<ThemeOption>().HasData(SeedData.GetInitialOptions());
            modelBuilder.Entity<ThemePalette>().HasData(SeedData.GetInitialPalettes());
            modelBuilder.Entity<ThemeSelection>().HasData(SeedData.GetThemeSelection());
            modelBuilder.Entity<CustomLayoutProperty>().HasData(SeedData.GetCustomLayoutProperties());
            modelBuilder.Entity<CustomShadow>().HasData(SeedData.GetCustomShadows());
            modelBuilder.Entity<CustomTheme>().HasData(SeedData.GetCustomThemes());
            modelBuilder.Entity<CustomTypography>().HasData(SeedData.GetCustomTypographies());
            modelBuilder.Entity<CustomZIndex>().HasData(SeedData.GetCustomZIndexes());
            modelBuilder.Entity<MappedTheme>().HasData(SeedData.GetMappedThemes());
            modelBuilder.Entity<MappedCssVariables>().HasData(SeedData.GetMappedCssVariables());
            // Create Indexes
            // index css variables

            // Auto Include Statements

            // Restricted all Cascading Delete Functions
        }

        // public DbSet<ModelName> PluralModelName {get;set;}
        public DbSet<ThemeOption> ThemeOptions { get; set; }
        public DbSet<ThemePalette> ThemePalettes { get; set; }
        public DbSet<ThemeSelection> ThemeSelections { get; set; }
        public DbSet<CustomLayoutProperty> CustomLayoutProperties { get; set; }
        public DbSet<CustomShadow> CustomShadows { get; set; }
        public DbSet<CustomTheme> CustomThemes { get; set; }
        public DbSet<CustomTypography> CustomTypographies { get; set; }
        public DbSet<CustomZIndex> CustomZIndexes { get; set; }
        public DbSet<MappedTheme> MappedThemes { get; set; }
        public DbSet<MappedCssVariables> MappedCssVariables { get; set; }
    }
}