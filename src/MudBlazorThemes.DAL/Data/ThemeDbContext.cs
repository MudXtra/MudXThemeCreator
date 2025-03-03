using Microsoft.EntityFrameworkCore;
using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.DAL.Data
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
                //Does not play nice with Postgresql
                //Database.Migrate();
            }
        }

        private void SeedInMemoryDatabase()
        {
            var seedData = new Dictionary<Type, Func<IEnumerable<object>>>
            {
                { typeof(ThemePalette), () => SeedData.GetInitialPalettes() },
                { typeof(ThemeOption), () => SeedData.GetInitialOptions() },
                { typeof(CustomTheme), () => SeedData.GetCustomThemes() },
                { typeof(ThemeSelection), () => SeedData.GetThemeSelection() },
                { typeof(CustomLayoutProperty), () => SeedData.GetCustomLayoutProperties() },
                { typeof(CustomShadow), () => SeedData.GetCustomShadows() },
                { typeof(CustomTypography), () => SeedData.GetCustomTypographies() },
                { typeof(CustomZIndex), () => SeedData.GetCustomZIndexes() },
                { typeof(MappedTheme), () => SeedData.GetMappedThemes() },
                { typeof(MappedCssVariables), () => SeedData.GetMappedCssVariables() }
            };

            foreach (var (type, getData) in seedData)
            {
                var entities = getData().ToList();

                // Reset Id to 0 for in-memory use
                foreach (var entity in entities)
                {
                    var idProperty = entity.GetType().GetProperty("Id");
                    if (idProperty != null && idProperty.CanWrite)
                    {
                        idProperty.SetValue(entity, 0);
                    }
                }

                // Dynamically get the correct DbSet<TEntity> and add entities
                var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)!
                                                 .MakeGenericMethod(type);
                var dbSet = setMethod.Invoke(this, null);
                var addRangeMethod = dbSet!.GetType().GetMethod(nameof(DbSet<object>.AddRange));

                addRangeMethod!.Invoke(dbSet, [entities]);
            }

            SaveChanges();
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
