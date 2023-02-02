namespace ISTQBQuiz.Services;

public static class AppSettingsService
{
    private static IConfiguration _config;

    public static void AppSettingsConfigure(IConfiguration config)
    {
        _config = config;
    }

    public static string GetConnectionString(string key)
    {
        var connectionString = _config.GetConnectionString(key);
        return connectionString;
    }
}