using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ThemeCreatorMudBlazor.DAL.Interfaces;

namespace ThemeCreatorMudBlazor.DAL.Services
{
    public class LocalStorageService(ProtectedLocalStorage localStorage) : ILocalStorageService
    {
        private readonly ProtectedLocalStorage _localStorage = localStorage;

        public async ValueTask<bool> ContainKeyAsync(string key) => (await _localStorage.GetAsync<object>(key)).Success;

        public async ValueTask<T> GetItemAsync<T>(string key)
        {
            try
            {
                return (await _localStorage.GetAsync<T>(key)).Value!;
            }
            catch (CryptographicException)
            {
                // corrupted result, clear it
                await _localStorage.DeleteAsync(key);
            }
            return (await _localStorage.GetAsync<T>(key)).Value!;
        }

        public async ValueTask SetItemAsync<T>(string key, T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            await _localStorage.SetAsync(key, value);
        }
        public async ValueTask DeleteItemAsync(string key) => await _localStorage.DeleteAsync(key);
    }
}
