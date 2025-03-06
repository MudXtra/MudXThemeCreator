using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Extensions;
using MudBlazor.Services;

namespace MudBlazorThemes.UnitTest
{
    public static class TestContextExtensions
    {
        public static void AddTestServices(this Bunit.TestContext ctx)
        {
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;
            ctx.Services.AddMudServices(options =>
            {
                options.SnackbarConfiguration.ShowTransitionDuration = 0;
                options.SnackbarConfiguration.HideTransitionDuration = 0;
                options.PopoverOptions.CheckForPopoverProvider = false;
            });
            ctx.Services.AddMudExtensions();
            ctx.Services.AddOptions();
        }
    }
}
