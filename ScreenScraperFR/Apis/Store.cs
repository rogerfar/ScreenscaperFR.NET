namespace ScreenScraperFR;

internal class Store
{
    public const String API_URL = "https://api.screenscraper.fr/";
    public const String API_VERSION = "api2/";

    public String? Softname { get; set; }
    public String? DevId { get; set; }
    public String? DevPassword { get; set; }
    public String? UserName { get; set; }
    public String? UserPassword { get; set; }
}