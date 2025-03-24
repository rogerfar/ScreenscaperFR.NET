namespace ScreenScraperFR;

public interface IScreenScraperFRClient
{
    /// <summary>
    /// Retrieves information about the ScreenScraper server infrastructure.
    /// </summary>
    /// <param name="cached">Retrieve the cached version, updated each time a search or get game request is made.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<ServerInfrastructureInfo> GetInfrastructureInfo(Boolean cached = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves information about the authenticated ScreenScraper user.
    /// </summary>
    /// <param name="cached">Retrieve the cached version, updated each time a search or get game request is made.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<UserInfo?> GetUserInfo(Boolean cached = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of user levels on ScreenScraper.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<UserLevel>> GetUserLevels(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported player counts (e.g., 1-4 players, multiplayer, etc.).
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<PlayerCount>> GetPlayerCounts(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported media types (e.g., box, screenshot, title screen).
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<String>> GetMediaTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of ROM types recognized by ScreenScraper.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<String>> GetRomTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of game genres.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<Genre>> GetGenres(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported regions (e.g., Europe, USA, Japan).
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<Region>> GetRegions(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported languages.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<Language>> GetLanguages(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of game content ratings/classifications (e.g., ESRB, PEGI).
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<Classification>> GetClassifications(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available media types for game platform.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<PlatformMediaType>> GetPlatformMediaTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available media types for games.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<GameMediaType>> GetGameMediaTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available text information fields for games (e.g., summary, developer).
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<GameInfoField>> GetGameInfoFields(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available text information fields for ROMs.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<RomInfoField>> GetRomInfoFields(CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads media images for game groups (e.g., genres, families, themes).
    /// If the hash (CRC, MD5, SHA1) of the local image matches the server, returns "CRCOK", "MD5OK", or "SHA1OK".
    /// Returns "NOMEDIA" if no media is found.
    /// </summary>
    /// <param name="groupId">Numeric group ID (genre, family, theme, etc.).</param>
    /// <param name="media">Media identifier (e.g., logo-monochrome).</param>
    /// <param name="mediaFormat">Optional: File extension of the media (e.g., jpg, png).</param>
    /// <param name="crc">Optional: CRC32 checksum of the local file.</param>
    /// <param name="md5">Optional: MD5 checksum of the local file.</param>
    /// <param name="sha1">Optional: SHA1 checksum of the local file.</param>
    /// <param name="maxWidth">Optional: Maximum width of the returned image.</param>
    /// <param name="maxHeight">Optional: Maximum height of the returned image.</param>
    /// <param name="outputFormat">Optional: Format of the returned image (png or jpg).</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<MediaResponse> GetGroupImage(Int32 groupId,
                                      String media,
                                      String? mediaFormat = null,
                                      String? crc = null,
                                      String? md5 = null,
                                      String? sha1 = null,
                                      Int32? maxWidth = null,
                                      Int32? maxHeight = null,
                                      String? outputFormat = null,
                                      CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads media images for a company (e.g., publisher or developer logo).
    /// Supports hash checking and resizing options.
    /// </summary>
    /// <param name="companyId">Numeric ID of the company.</param>
    /// <param name="media">Media identifier (e.g., logo-monochrome).</param>
    /// <param name="mediaFormat">Optional: File extension of the media.</param>
    /// <param name="crc">Optional: CRC32 checksum of the local file.</param>
    /// <param name="md5">Optional: MD5 checksum of the local file.</param>
    /// <param name="sha1">Optional: SHA1 checksum of the local file.</param>
    /// <param name="maxWidth">Optional: Maximum width of the returned image.</param>
    /// <param name="maxHeight">Optional: Maximum height of the returned image.</param>
    /// <param name="outputFormat">Optional: Format of the returned image (png or jpg).</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<MediaResponse> GetCompanyImage(Int32 companyId,
                                        String media,
                                        String? mediaFormat = null,
                                        String? crc = null,
                                        String? md5 = null,
                                        String? sha1 = null,
                                        Int32? maxWidth = null,
                                        Int32? maxHeight = null,
                                        String? outputFormat = null,
                                        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of platforms and associated platform/media information.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<Platform>> GetPlatforms(CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads image media (e.g., logos or artwork) for a platform.
    /// Uses checksums to optionally skip downloading if the local version is current.
    /// </summary>
    /// <param name="platformId">ID of the target platform.</param>
    /// <param name="media">Media identifier (e.g., wheel, logo, etc.).</param>
    /// <param name="mediaFormat">Optional: File extension format.</param>
    /// <param name="crc">Optional: CRC32 of the local file.</param>
    /// <param name="md5">Optional: MD5 of the local file.</param>
    /// <param name="sha1">Optional: SHA1 of the local file.</param>
    /// <param name="maxWidth">Optional: Maximum image width.</param>
    /// <param name="maxHeight">Optional: Maximum image height.</param>
    /// <param name="outputFormat">Optional: Desired output image format.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<MediaResponse> GetPlatformImage(Int32 platformId,
                                         String media,
                                         String? mediaFormat = null,
                                         String? crc = null,
                                         String? md5 = null,
                                         String? sha1 = null,
                                         Int32? maxWidth = null,
                                         Int32? maxHeight = null,
                                         String? outputFormat = null,
                                         CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads video media (e.g., intro video) for a platform.
    /// Uses checksum comparison to return status-only when possible.
    /// </summary>
    /// <param name="platformId">Platform ID.</param>
    /// <param name="media">Media type to download.</param>
    /// <param name="mediaFormat">Optional file format (mp4, etc.).</param>
    /// <param name="crc">Optional CRC checksum of the local video.</param>
    /// <param name="md5">Optional MD5 checksum.</param>
    /// <param name="sha1">Optional SHA1 checksum.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<MediaResponse> GetPlatformVideo(Int32 platformId,
                                         String media,
                                         String? mediaFormat = null,
                                         String? crc = null,
                                         String? md5 = null,
                                         String? sha1 = null,
                                         CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for a game by name. Returns a list of up to 30 games ranked by match probability.
    /// </summary>
    Task<List<Game>> SearchGames(String name, Int32? platformId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for a game based on a ROM file's checksum(s), platform ID, and additional metadata.
    /// </summary>
    /// <param name="crc">CRC32 checksum of the ROM/ISO/folder.</param>
    /// <param name="md5">MD5 checksum of the ROM/ISO/folder.</param>
    /// <param name="sha1">SHA1 checksum of the ROM/ISO/folder.</param>
    /// <param name="platformId">Numeric platform ID.</param>
    /// <param name="romType">Type of ROM: file / iso / folder.</param>
    /// <param name="romName">Name of the file (with extension) or folder.</param>
    /// <param name="romSize">Size in bytes of the file or folder.</param>
    /// <param name="serialNumber">Force game search with this serial number (ISO only).</param>
    /// <param name="gameId">Force game search with a known game ID (bypasses rom data).</param>
    /// <param name="cancellationToken"></param>
    Task<Game?> GetGame(Int32 platformId,
                        String romType,
                        String? romName = null,
                        Int32? romSize = null,
                        String? serialNumber = null,
                        Int32? gameId = null,
                        String? crc = null,
                        String? md5 = null,
                        String? sha1 = null,
                        CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads image media for a specific game.
    /// May return a status string (e.g., MD5OK) instead of media if local hash matches server.
    /// </summary>
    Task<MediaResponse> GetGameImage(Int32 platformId,
                                     Int32 gameId,
                                     String media,
                                     String? mediaFormat = null,
                                     String? crc = null,
                                     String? md5 = null,
                                     String? sha1 = null,
                                     Int32? maxWidth = null,
                                     Int32? maxHeight = null,
                                     String? outputFormat = null,
                                     CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads video content for a game (e.g., gameplay trailer).
    /// Returns a hash match status if the file is already up to date locally.
    /// </summary>
    Task<MediaResponse> GetGameVideo(Int32 platformId,
                                     Int32 gameId,
                                     String media,
                                     String? mediaFormat = null,
                                     String? crc = null,
                                     String? md5 = null,
                                     String? sha1 = null,
                                     CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads the PDF manual for a specific game.
    /// Includes optional hash checks for optimized sync.
    /// </summary>
    Task<MediaResponse> GetGameManual(Int32 platformId,
                                      Int32 gameId,
                                      String media,
                                      String? mediaFormat = null,
                                      String? crc = null,
                                      String? md5 = null,
                                      String? sha1 = null,
                                      CancellationToken cancellationToken = default);
}

/// <summary>
///     https://screenscraper.fr/webapi2.php
/// </summary>
public class ScreenScraperFRClient : IScreenScraperFRClient
{
    private readonly Store _store = new();
    private readonly Requests _requests;

    private ServerInfrastructureInfo? _serverInfrastructureInfo = null;
    private UserInfo? _userInfo = null;

    /// <summary>
    ///     Initialize the ScreenScraperFR API.
    /// </summary>
    public ScreenScraperFRClient(String softName, String devId, String devPassword, String? userName = null, String? userPassword = null, HttpClient? httpClient = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(softName);
        ArgumentException.ThrowIfNullOrWhiteSpace(devId);
        ArgumentException.ThrowIfNullOrWhiteSpace(devPassword);

        var client = httpClient ?? new HttpClient();

        _store.Softname = softName;
        _store.DevId = devId;
        _store.DevPassword = devPassword;
        _store.UserName = userName;
        _store.UserPassword = userPassword;

        _requests = new(client, _store);
    }

    public async Task<ServerInfrastructureInfo> GetInfrastructureInfo(Boolean cached = true, CancellationToken cancellationToken = default)
    {
        if (cached && _serverInfrastructureInfo != null)
        {
            return _serverInfrastructureInfo;
        }

        var response = await _requests.GetRequestAsync<ServerInfrastructureInfoResponse>("ssinfraInfos.php", false, null, cancellationToken);

        _serverInfrastructureInfo = response.ServerInfrastructureInfo;

        return response.ServerInfrastructureInfo;
    }

    public async Task<UserInfo?> GetUserInfo(Boolean cached = true, CancellationToken cancellationToken = default)
    {
        if (cached && _userInfo != null)
        {
            return _userInfo;
        }

        var response = await _requests.GetRequestAsync<UserInfoResponse>("ssuserInfos.php", true, null, cancellationToken);
        
        _userInfo = response.UserInfo;

        return response.UserInfo;
    }

    public async Task<List<UserLevel>> GetUserLevels(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<UserLevelsResponse>("userlevelsListe.php", false, null, cancellationToken);

        return [.. response.UserLevels.Values];
    }

    public async Task<List<PlayerCount>> GetPlayerCounts(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<PlayerCountsResponse>("nbJoueursListe.php", false, null, cancellationToken);

        return [.. response.PlayerCounts.Values];
    }

    public async Task<List<String>> GetMediaTypes(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<MediaTypesResponse>("supportTypesListe.php", false, null, cancellationToken);

        return response.MediaTypes;
    }

    public async Task<List<String>> GetRomTypes(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<RomTypesResponse>("romTypesListe.php", false, null, cancellationToken);

        return response.RomTypes;
    }

    public async Task<List<Genre>> GetGenres(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<GenresResponse>("genresListe.php", false, null, cancellationToken);

        return [.. response.Genres.Values];
    }

    public async Task<List<Region>> GetRegions(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<RegionsResponse>("regionsListe.php", false, null, cancellationToken);

        return [.. response.Regions.Values];
    }

    public async Task<List<Language>> GetLanguages(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<LanguagesResponse>("languesListe.php", false, null, cancellationToken);

        return [.. response.Languages.Values];
    }

    public async Task<List<Classification>> GetClassifications(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<ClassificationsResponse>("classificationListe.php", false, null, cancellationToken);

        return [.. response.Classifications.Values];
    }

    public async Task<List<PlatformMediaType>> GetPlatformMediaTypes(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<PlatformMediaResponse>("mediasSystemeListe.php", false, null, cancellationToken);

        return [.. response.Media.Values];
    }
    
    public async Task<List<Platform>> GetPlatforms(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<PlatformsResponse>("systemesListe.php", false, null, cancellationToken);

        if (response.ServerInfrastructureInfo != null)
        {
            _serverInfrastructureInfo = response.ServerInfrastructureInfo;
        }

        if (response.UserInfo != null)
        {
            _userInfo = response.UserInfo;
        }

        return response.Platforms;
    }

    public async Task<List<GameMediaType>> GetGameMediaTypes(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<GameMediaResponse>("mediasJeuListe.php", false, null, cancellationToken);

        return [.. response.Media.Values];
    }

    public async Task<List<GameInfoField>> GetGameInfoFields(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<GameInfoFieldsResponse>("infosJeuListe.php", false, null, cancellationToken);

        return [.. response.Infos.Values];
    }

    public async Task<List<RomInfoField>> GetRomInfoFields(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<RomInfoFieldsResponse>("infosRomListe.php", false, null, cancellationToken);

        return [.. response.Infos.Values];
    }

    public async Task<MediaResponse> GetCompanyImage(Int32 companyId,
                                                     String media,
                                                     String? mediaFormat = null,
                                                     String? crc = null,
                                                     String? md5 = null,
                                                     String? sha1 = null,
                                                     Int32? maxWidth = null,
                                                     Int32? maxHeight = null,
                                                     String? outputFormat = null,
                                                     CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "groupid", companyId.ToString()
            },
            {
                "media", media
            }
        };

        if (!String.IsNullOrWhiteSpace(mediaFormat))
        {
            parameters.Add("mediaformat", mediaFormat);
        }

        if (!String.IsNullOrWhiteSpace(crc))
        {
            parameters.Add("crc", crc);
        }

        if (!String.IsNullOrWhiteSpace(md5))
        {
            parameters.Add("md5", md5);
        }

        if (!String.IsNullOrWhiteSpace(sha1))
        {
            parameters.Add("sha1", sha1);
        }

        if (maxWidth.HasValue)
        {
            parameters.Add("maxwidth", maxWidth.Value.ToString());
        }

        if (maxHeight.HasValue)
        {
            parameters.Add("maxheight", maxHeight.Value.ToString());
        }

        if (!String.IsNullOrWhiteSpace(outputFormat))
        {
            parameters.Add("outputformat", outputFormat);
        }

        var response = await _requests.GetMediaRequestAsync("mediaCompagnie.php", true, parameters, cancellationToken);

        return response;
    }

    public async Task<MediaResponse> GetGameImage(Int32 platformId,
                                                  Int32 gameId,
                                                  String media,
                                                  String? mediaFormat = null,
                                                  String? crc = null,
                                                  String? md5 = null,
                                                  String? sha1 = null,
                                                  Int32? maxWidth = null,
                                                  Int32? maxHeight = null,
                                                  String? outputFormat = null,
                                                  CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "systemeid", platformId.ToString()
            },
            {
                "jeuid", gameId.ToString()
            },
            {
                "media", media
            }
        };

        if (!String.IsNullOrWhiteSpace(mediaFormat))
        {
            parameters.Add("mediaformat", mediaFormat);
        }

        if (!String.IsNullOrWhiteSpace(crc))
        {
            parameters.Add("crc", crc);
        }

        if (!String.IsNullOrWhiteSpace(md5))
        {
            parameters.Add("md5", md5);
        }

        if (!String.IsNullOrWhiteSpace(sha1))
        {
            parameters.Add("sha1", sha1);
        }

        if (maxWidth.HasValue)
        {
            parameters.Add("maxwidth", maxWidth.Value.ToString());
        }

        if (maxHeight.HasValue)
        {
            parameters.Add("maxheight", maxHeight.Value.ToString());
        }

        if (!String.IsNullOrWhiteSpace(outputFormat))
        {
            parameters.Add("outputformat", outputFormat);
        }

        var response = await _requests.GetMediaRequestAsync("mediaJeu.php", true, parameters, cancellationToken);

        return response;
    }

    public async Task<MediaResponse> GetGroupImage(Int32 groupId,
                                                   String media,
                                                   String? mediaFormat = null,
                                                   String? crc = null,
                                                   String? md5 = null,
                                                   String? sha1 = null,
                                                   Int32? maxWidth = null,
                                                   Int32? maxHeight = null,
                                                   String? outputFormat = null,
                                                   CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "groupid", groupId.ToString()
            },
            {
                "media", media
            }
        };

        if (!String.IsNullOrWhiteSpace(mediaFormat))
        {
            parameters.Add("mediaformat", mediaFormat);
        }

        if (!String.IsNullOrWhiteSpace(crc))
        {
            parameters.Add("crc", crc);
        }

        if (!String.IsNullOrWhiteSpace(md5))
        {
            parameters.Add("md5", md5);
        }

        if (!String.IsNullOrWhiteSpace(sha1))
        {
            parameters.Add("sha1", sha1);
        }

        if (maxWidth.HasValue)
        {
            parameters.Add("maxwidth", maxWidth.Value.ToString());
        }

        if (maxHeight.HasValue)
        {
            parameters.Add("maxheight", maxHeight.Value.ToString());
        }

        if (!String.IsNullOrWhiteSpace(outputFormat))
        {
            parameters.Add("outputformat", outputFormat);
        }

        var response = await _requests.GetMediaRequestAsync("mediaGroup.php", true, parameters, cancellationToken);

        return response;
    }

    public async Task<MediaResponse> GetPlatformImage(Int32 platformId,
                                                      String media,
                                                      String? mediaFormat = null,
                                                      String? crc = null,
                                                      String? md5 = null,
                                                      String? sha1 = null,
                                                      Int32? maxWidth = null,
                                                      Int32? maxHeight = null,
                                                      String? outputFormat = null,
                                                      CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "systemeid", platformId.ToString()
            },
            {
                "media", media
            }
        };

        if (!String.IsNullOrWhiteSpace(mediaFormat))
        {
            parameters.Add("mediaformat", mediaFormat);
        }

        if (!String.IsNullOrWhiteSpace(crc))
        {
            parameters.Add("crc", crc);
        }

        if (!String.IsNullOrWhiteSpace(md5))
        {
            parameters.Add("md5", md5);
        }

        if (!String.IsNullOrWhiteSpace(sha1))
        {
            parameters.Add("sha1", sha1);
        }

        if (maxWidth.HasValue)
        {
            parameters.Add("maxwidth", maxWidth.Value.ToString());
        }

        if (maxHeight.HasValue)
        {
            parameters.Add("maxheight", maxHeight.Value.ToString());
        }

        if (!String.IsNullOrWhiteSpace(outputFormat))
        {
            parameters.Add("outputformat", outputFormat);
        }

        var response = await _requests.GetMediaRequestAsync("mediaSysteme.php", true, parameters, cancellationToken);

        return response;
    }

    public async Task<MediaResponse> GetPlatformVideo(Int32 platformId,
                                                      String media,
                                                      String? mediaFormat = null,
                                                      String? crc = null,
                                                      String? md5 = null,
                                                      String? sha1 = null,
                                                      CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "systemeid", platformId.ToString()
            },
            {
                "media", media
            }
        };

        if (!String.IsNullOrWhiteSpace(mediaFormat))
        {
            parameters.Add("mediaformat", mediaFormat);
        }

        if (!String.IsNullOrWhiteSpace(crc))
        {
            parameters.Add("crc", crc);
        }

        if (!String.IsNullOrWhiteSpace(md5))
        {
            parameters.Add("md5", md5);
        }

        if (!String.IsNullOrWhiteSpace(sha1))
        {
            parameters.Add("sha1", sha1);
        }

        var response = await _requests.GetMediaRequestAsync("mediaVideoSysteme.php", true, parameters, cancellationToken);

        return response;
    }

    public async Task<MediaResponse> GetGameVideo(Int32 platformId,
                                                  Int32 gameId,
                                                  String media,
                                                  String? mediaFormat = null,
                                                  String? crc = null,
                                                  String? md5 = null,
                                                  String? sha1 = null,
                                                  CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "systemeid", platformId.ToString()
            },
            {
                "jeuid", gameId.ToString()
            },
            {
                "media", media
            }
        };

        if (!String.IsNullOrWhiteSpace(mediaFormat))
        {
            parameters.Add("mediaformat", mediaFormat);
        }

        if (!String.IsNullOrWhiteSpace(crc))
        {
            parameters.Add("crc", crc);
        }

        if (!String.IsNullOrWhiteSpace(md5))
        {
            parameters.Add("md5", md5);
        }

        if (!String.IsNullOrWhiteSpace(sha1))
        {
            parameters.Add("sha1", sha1);
        }

        var response = await _requests.GetMediaRequestAsync("mediaVideoJeu.php", true, parameters, cancellationToken);

        return response;
    }

    public async Task<MediaResponse> GetGameManual(Int32 platformId,
                                                   Int32 gameId,
                                                   String media,
                                                   String? mediaFormat = null,
                                                   String? crc = null,
                                                   String? md5 = null,
                                                   String? sha1 = null,
                                                   CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "systemeid", platformId.ToString()
            },
            {
                "jeuid", gameId.ToString()
            },
            {
                "media", media
            }
        };

        if (!String.IsNullOrWhiteSpace(mediaFormat))
        {
            parameters.Add("mediaformat", mediaFormat);
        }

        if (!String.IsNullOrWhiteSpace(crc))
        {
            parameters.Add("crc", crc);
        }

        if (!String.IsNullOrWhiteSpace(md5))
        {
            parameters.Add("md5", md5);
        }

        if (!String.IsNullOrWhiteSpace(sha1))
        {
            parameters.Add("sha1", sha1);
        }

        var response = await _requests.GetMediaRequestAsync("mediaManuelJeu.php", true, parameters, cancellationToken);

        return response;
    }

    public async Task<List<Game>> SearchGames(String name, Int32? platformId = null, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "recherche", name
            }
        };

        if (platformId != null)
        {
            parameters.Add("systemeid", platformId.Value.ToString());
        }

        var response = await _requests.GetRequestAsync<SearchGamesResponse>("jeuRecherche.php", true, parameters, cancellationToken);

        if (response.ServerInfrastructureInfo != null)
        {
            _serverInfrastructureInfo = response.ServerInfrastructureInfo;
        }

        if (response.UserInfo != null)
        {
            _userInfo = response.UserInfo;
        }

        return [.. response.Games];
    }

    public async Task<Game?> GetGame(Int32 platformId,
                                     String romType,
                                     String? romName = null,
                                     Int32? romSize = null,
                                     String? serialNumber = null,
                                     Int32? gameId = null,
                                     String? crc = null,
                                     String? md5 = null,
                                     String? sha1 = null,
                                     CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "systemeid", platformId.ToString()
            },
            {
                "romtype", romType
            }
        };

        if (romName != null)
        {
            parameters.Add("romnom", romName);
        }

        if (romSize != null)
        {
            parameters.Add("romtaille", romSize.Value.ToString());
        }

        if (serialNumber != null)
        {
            parameters.Add("serialnum", serialNumber);
        }

        if (gameId != null)
        {
            parameters.Add("gameid", gameId.Value.ToString());
        }

        if (crc != null)
        {
            parameters.Add("crc", crc);
        }

        if (md5 != null)
        {
            parameters.Add("md5", md5);
        }

        if (sha1 != null)
        {
            parameters.Add("sha1", sha1);
        }

        var response = await _requests.GetRequestAsync<GetGameResponse>("jeuInfos.php", true, parameters, cancellationToken);

        if (response.ServerInfrastructureInfo != null)
        {
            _serverInfrastructureInfo = response.ServerInfrastructureInfo;
        }

        if (response.UserInfo != null)
        {
            _userInfo = response.UserInfo;
        }

        return response.Game;
    }
}
