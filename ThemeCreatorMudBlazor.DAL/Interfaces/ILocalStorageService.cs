namespace ThemeCreatorMudBlazor.DAL.Interfaces
{
    public interface ILocalStorageService
    {
        ValueTask<bool> ContainKeyAsync(string key);

        ValueTask<T> GetItemAsync<T>(string key);

        ValueTask SetItemAsync<T>(string key, T value);

        ValueTask DeleteItemAsync(string key);
    }
}
