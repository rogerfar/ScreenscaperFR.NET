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
    public async Task GetMediaTypes()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var mediaTypes = await client.GetMediaTypes();

        Assert.NotEmpty(mediaTypes);
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
    public async Task GetPlatformMediaTypes()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var platformMediaTypes = await client.GetPlatformMediaTypes();

        Assert.NotEmpty(platformMediaTypes);
    }
    
    [Fact]
    public async Task GetGameMedia()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var gameMedia = await client.GetGameMediaTypes();

        Assert.NotEmpty(gameMedia);
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
    public async Task GetGroupImage()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var groupMedia = await client.GetGroupImage(1, "logo-monochrome");

        await File.WriteAllBytesAsync("GetGroupImage.png", groupMedia.Data!);

        Assert.NotNull(groupMedia);
    }
    
    [Fact]
    public async Task GetCompanyImage()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var companyMedia = await client.GetCompanyImage(1, "logo-monochrome");

        await File.WriteAllBytesAsync("GetCompanyImage.png", companyMedia.Data!);

        Assert.NotNull(companyMedia);
    }
    
    [Fact]
    public async Task GetPlatforms()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var platforms = await client.GetPlatforms();

        Assert.NotEmpty(platforms);
    }
    
    [Fact]
    public async Task GetPlatformImage()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var platformImage = await client.GetPlatformImage(1, "wheel(wor)");

        await File.WriteAllBytesAsync("GetPlatformImage.png", platformImage.Data!);

        Assert.NotNull(platformImage);
    }

    [Fact]
    public async Task GetPlatformVideo()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var platformVideo = await client.GetPlatformVideo(1, "video");

        await File.WriteAllBytesAsync("GetPlatformVideo.mp4", platformVideo.Data!);

        Assert.NotNull(platformVideo);
    }
    
    [Fact]
    public async Task SearchGames()
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
    public async Task GetGameImage()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");
        
        var gameMedia = await client.GetGameImage(1, 3, "wheel-hd(wor)");

        await File.WriteAllBytesAsync("GetGameImage.png", gameMedia.Data!);

        Assert.NotNull(gameMedia);
    }

    [Fact]
    public async Task GetGameImageByMd5()
    {
        var client = new ScreenScraperFRClient("ScreenScraperFR.NET", "jelos", "jelos");

        var md5 = await CreateMd5("GetGameImage.png");
        
        var gameMedia = await client.GetGameImage(1, 3, "wheel-hd(wor)", null, null, md5);

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

        var byteHash = MD5.HashData(input);
        var hash = Convert.ToHexString(byteHash);

        return hash.ToLower();
    }
}