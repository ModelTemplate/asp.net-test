/// <summary>
/// Simple POCO for managing the application's settings.
/// </summary>
namespace MVCWebAppTest
{
    public class AppSettings
    {
        public Application Application { get; set; }
    }

    public class Application
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
