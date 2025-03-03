namespace MudBlazorThemes.UnitTest
{
    public abstract class MudBlazorThemeContext
    {
        protected Bunit.TestContext Context { get; private set; } = null!;

        [SetUp]
        public virtual void Setup()
        {
            Context = new();
            Context.AddTestServices();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                Context.Dispose();
            }
            catch (Exception)
            {
                /*ignore*/
            }
        }
    }
}
