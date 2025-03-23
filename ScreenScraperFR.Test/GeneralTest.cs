using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;

namespace ScreenScraperFR.Test;

public class GeneralTest
{
    [Fact]
    public async Task GetInfrastructureInfo()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var serverStatus = await client.GetInfrastructureInfo();

        Assert.Equal(0, serverStatus.CpuUsageServer1);
    }

    [Fact]
    public async Task GetUserInfo()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos", "test", "test");

        var userInfo = await client.GetUserInfo();

        Assert.NotNull(userInfo!.Username);
    }
    
    [Fact]
    public async Task GetUserLevels()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var userLevels = await client.GetUserLevels();

        Assert.NotNull(userLevels);
    }

    [Fact]
    public async Task GetPlayerCounts()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var playerCounts = await client.GetPlayerCounts();

        Assert.Contains(playerCounts, p => p.Name == "1");
    }

    [Fact]
    public async Task GetSupportTypes()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var supportTypes = await client.GetSupportTypes();

        Assert.NotEmpty(supportTypes);
    }

    [Fact]
    public async Task GetRomTypes()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var romTypes = await client.GetRomTypes();

        Assert.NotEmpty(romTypes);
    }

    [Fact]
    public async Task GetGenres()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var genres = await client.GetGenres();

        Assert.NotEmpty(genres);
    }

    [Fact]
    public async Task GetRegions()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var regions = await client.GetRegions();

        Assert.NotEmpty(regions);
    }

    [Fact]
    public async Task GetLanguages()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var languages = await client.GetLanguages();

        Assert.NotEmpty(languages);
    }

    [Fact]
    public async Task GetClassifications()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var classifications = await client.GetClassifications();

        Assert.NotEmpty(classifications);
    }
    
    [Fact]
    public async Task GetSystemMedias()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var systemMedias = await client.GetSystemMedias();

        Assert.NotEmpty(systemMedias);
    }
    
    [Fact]
    public async Task GetGameMedias()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var gameMedias = await client.GetGameMedias();

        Assert.NotEmpty(gameMedias);
    }
    
    [Fact]
    public async Task GetGameInfoFields()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var gameInfos = await client.GetGameInfoFields();

        Assert.NotEmpty(gameInfos);
    }
    
    [Fact]
    public async Task GetRomInfoFields()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var romInfoFields = await client.GetRomInfoFields();

        Assert.NotEmpty(romInfoFields);
    }
    
    [Fact]
    public async Task GetGroupMedia()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var groupMedia = await client.GetGroupMedia(1, "logo-monochrome");

        await File.WriteAllBytesAsync("GetGroupMedia.png", groupMedia.Data!);

        Assert.NotNull(groupMedia);
    }
    
    [Fact]
    public async Task GetCompanyMedia()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var companyMedia = await client.GetCompanyMedia(1, "logo-monochrome");

        await File.WriteAllBytesAsync("GetCompanyMedia.png", companyMedia.Data!);

        Assert.NotNull(companyMedia);
    }
    
    [Fact]
    public async Task GetSystems()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var systems = await client.GetSystems();

        Assert.NotEmpty(systems);
    }
    
    [Fact]
    public async Task GetSystemMedia()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var systemMedia = await client.GetSystemMedia(1, "wheel(wor)");

        await File.WriteAllBytesAsync("GetSystemMedia.png", systemMedia.Data!);

        Assert.NotNull(systemMedia);
    }

    [Fact]
    public async Task GetSystemVideo()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var systemMedia = await client.GetSystemVideo(1, "video");

        await File.WriteAllBytesAsync("GetSystemMedia.mp4", systemMedia.Data!);

        Assert.NotNull(systemMedia);
    }
    
    [Fact]
    public async Task SearchGame()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var searchResults = await client.SearchGames("sonic", 1);

        Assert.NotNull(searchResults);
    }
    
    [Fact]
    public async Task GetGame()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var game = await client.GetGame(1, "rom", "Sonic The Hedgehog 2 (World).zip", 749652, null, null, "50ABC90A");

        Assert.NotNull(game);
    }

    [Fact]
    public async Task GetGameMedia()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");
        
        var gameMedia = await client.GetGameMedia(1, 3, "wheel-hd(wor)");

        await File.WriteAllBytesAsync("GetGameMedia.png", gameMedia.Data!);

        Assert.NotNull(gameMedia);
    }

    [Fact]
    public async Task GetGameMediaMd5()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var md5 = await CreateMd5("GetGameMedia.png");
        
        var gameMedia = await client.GetGameMedia(1, 3, "wheel-hd(wor)", null, null, md5);

        Assert.Equal(MediaResponseType.Md5Ok, gameMedia.Result);
    }
    
    [Fact]
    public async Task GetGameVideo()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var gameVideo = await client.GetGameVideo(1, 3, "video");

        await File.WriteAllBytesAsync("GetGameVideo.mp4", gameVideo.Data!);

        Assert.NotNull(gameVideo);
    }
    
    [Fact]
    public async Task GetGameManual()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var gameVideo = await client.GetGameManual(1, 3, "manuel(eu)");

        await File.WriteAllBytesAsync("GetGameManual.pdf", gameVideo.Data!);

        Assert.NotNull(gameVideo);
    }

    private static async Task<String> CreateMd5(String fileName)
    {
        var input = await File.ReadAllBytesAsync(fileName);
        using var md5 = MD5.Create();

        var byteHash = md5.ComputeHash(input);
        var hash = BitConverter.ToString(byteHash).Replace("-", "");

        return hash.ToLower();
    }
}