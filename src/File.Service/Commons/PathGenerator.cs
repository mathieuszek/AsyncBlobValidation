using System.Globalization;

namespace File.Service.Commons;

public static class PathGenerator
{
    /// <summary>
    /// Parse <paramref name="dateTime"/> to Path string with minutes accuracy.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>Minutes accuracy path string.</returns>
    public static string GenerateDateTimePathUpToMinutes(DateTime dateTime)
        => dateTime.ToString("yyyy/MM/dd/HH/mm", CultureInfo.InvariantCulture);
}