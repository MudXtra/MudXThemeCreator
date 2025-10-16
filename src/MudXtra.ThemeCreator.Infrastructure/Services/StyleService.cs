using Microsoft.JSInterop;

namespace MudXtra.ThemeCreator.Infrastructure.Services;
public class StyleService(IJSRuntime jsRuntime)
{
    private readonly IJSRuntime _jsRuntime = jsRuntime;

    public async Task<string> GetComputedStylePropertyAsync(string propertyName)
    {
        return await _jsRuntime.InvokeAsync<string>("getComputedStyleProperty", propertyName);
    }
}
