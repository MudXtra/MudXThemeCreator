using Microsoft.EntityFrameworkCore;
using MudXtra.ThemeCreator.Infrastructure.Models;

namespace MudXtra.ThemeCreator.Infrastructure.Data
{
    public class ThemeDbContext(DbContextOptions<ThemeDbContext> options) : DbContext(options)
    {

        public void Initialize()
        {
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
            {
                SeedInMemoryDatabase();
            }
            else
            {
                // if it's a fresh DB build it will need updated, if not it will error 
                // due to migrations
                try
                {
                    Database.Migrate();
                }
                catch { }
            }
        }

        private void SeedInMemoryDatabase()
        {
            SeedSet(SeedData.GetInitialPalettes());
            SeedSet(SeedData.GetInitialOptions());
            SeedSet(SeedData.GetCustomThemes());
            SeedSet(SeedData.GetThemeSelection());
            SeedSet(SeedData.GetCustomLayoutProperties());
            SeedSet(SeedData.GetCustomShadows());
            SeedSet(SeedData.GetCustomTypographies());
            SeedSet(SeedData.GetCustomZIndexes());
            SeedSet(SeedData.GetMappedThemes());
            SeedSet(SeedData.GetMappedCssVariables());
            SaveChanges();
        }

        private void SeedSet<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (var entity in entities)
            {
                var idProperty = typeof(TEntity).GetProperty("Id");
                if (idProperty is { CanWrite: true })
                {
                    idProperty.SetValue(entity, 0);
                }
            }

            Set<TEntity>().AddRange(entities);
        }

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
        public DbSet<UserMax> UserMaxes { get; set; }

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

            // Create Indexes each one should have themeId indexed
            modelBuilder.Entity<CustomLayoutProperty>().HasIndex(x => x.CustomThemeId);
            modelBuilder.Entity<CustomShadow>().HasIndex(x => x.CustomThemeId);
            modelBuilder.Entity<CustomTypography>().HasIndex(x => x.CustomThemeId);
            modelBuilder.Entity<CustomZIndex>().HasIndex(x => x.CustomThemeId);
            modelBuilder.Entity<ThemeSelection>().HasIndex(x => x.CustomThemeId);

            // index css variables
            modelBuilder.Entity<CustomLayoutProperty>().HasIndex(x => x.CssVariable);
            modelBuilder.Entity<CustomShadow>().HasIndex(x => x.CssVariable);
            modelBuilder.Entity<CustomTypography>().HasIndex(x => x.CssVariable);
            modelBuilder.Entity<CustomZIndex>().HasIndex(x => x.CssVariable);
            modelBuilder.Entity<ThemeSelection>().HasIndex(x => x.CssVariable);

            // Auto Include Statements

            // Restricted all Cascading Delete Functions
        }
    }
}
