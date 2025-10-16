namespace MudXtra.ThemeCreator.UI.Extensions;

public static class StringExtensions
{
    public static string ToUpper(this string input, bool firstCharOnly)
    {
        if (!firstCharOnly)
        {
            return input.ToUpper();
        }

        string text = input.Substring(0, 1);
        return text.ToUpper() + input.Remove(0, 1);
    }
}
