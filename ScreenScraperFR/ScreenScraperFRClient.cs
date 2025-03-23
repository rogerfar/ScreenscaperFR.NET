using ScreenScraperFR.Models;

namespace ScreenScraperFR;

public interface IScreenScraperFRClient
{
    /// <summary>
    /// Retrieves information about the ScreenScraper server infrastructure.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<ServerInfrastructureInfo> GetInfrastructureInfo(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves information about the authenticated ScreenScraper user.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<UserInfo?> GetUserInfo(CancellationToken cancellationToken = default);

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
    Task<List<String>> GetSupportTypes(CancellationToken cancellationToken = default);

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
    /// Retrieves the list of available media types for game systems.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<SystemMedia>> GetSystemMedia(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available media types for games.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<GameMedia>> GetGameMedia(CancellationToken cancellationToken = default);

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
    /// Retrieves the list of systems and associated system/media information.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<List<System>> GetSystems(CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads image media (e.g., logos or artwork) for a system.
    /// Uses checksums to optionally skip downloading if the local version is current.
    /// </summary>
    /// <param name="systemId">ID of the target system.</param>
    /// <param name="media">Media identifier (e.g., wheel, logo, etc.).</param>
    /// <param name="mediaFormat">Optional: File extension format.</param>
    /// <param name="crc">Optional: CRC32 of the local file.</param>
    /// <param name="md5">Optional: MD5 of the local file.</param>
    /// <param name="sha1">Optional: SHA1 of the local file.</param>
    /// <param name="maxWidth">Optional: Maximum image width.</param>
    /// <param name="maxHeight">Optional: Maximum image height.</param>
    /// <param name="outputFormat">Optional: Desired output image format.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<MediaResponse> GetSystemImage(Int32 systemId,
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
    /// Downloads video media (e.g., intro video) for a system.
    /// Uses checksum comparison to return status-only when possible.
    /// </summary>
    /// <param name="systemId">System ID.</param>
    /// <param name="media">Media type to download.</param>
    /// <param name="mediaFormat">Optional file format (mp4, etc.).</param>
    /// <param name="crc">Optional CRC checksum of the local video.</param>
    /// <param name="md5">Optional MD5 checksum.</param>
    /// <param name="sha1">Optional SHA1 checksum.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<MediaResponse> GetSystemVideo(Int32 systemId,
                                       String media,
                                       String? mediaFormat = null,
                                       String? crc = null,
                                       String? md5 = null,
                                       String? sha1 = null,
                                       CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for a game by name. Returns a list of up to 30 games ranked by match probability.
    /// </summary>
    Task<List<SearchGame>> SearchGames(String name, Int32? systemId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for a game based on a ROM file's checksum(s), system ID, and additional metadata.
    /// </summary>
    /// <param name="crc">CRC32 checksum of the ROM/ISO/folder.</param>
    /// <param name="md5">MD5 checksum of the ROM/ISO/folder.</param>
    /// <param name="sha1">SHA1 checksum of the ROM/ISO/folder.</param>
    /// <param name="systemId">Numeric system ID.</param>
    /// <param name="romType">Type of ROM: file / iso / folder.</param>
    /// <param name="romName">Name of the file (with extension) or folder.</param>
    /// <param name="romSize">Size in bytes of the file or folder.</param>
    /// <param name="serialNumber">Force game search with this serial number (ISO only).</param>
    /// <param name="gameId">Force game search with a known game ID (bypasses rom data).</param>
    /// <param name="cancellationToken"></param>
    Task<GetGame?> GetGame(Int32 systemId,
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
    Task<MediaResponse> GetGameImage(Int32 systemId,
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
    Task<MediaResponse> GetGameVideo(Int32 systemId,
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
    Task<MediaResponse> GetGameManual(Int32 systemId,
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

    public async Task<ServerInfrastructureInfo> GetInfrastructureInfo(CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>();
        var response = await _requests.GetRequestAsync<ServerInfrastructureInfoResponse>("ssinfraInfos.php", false, parameters, cancellationToken);

        return response.ServerInfrastructureInfo;
    }

    public async Task<UserInfo?> GetUserInfo(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<UserInfoResponse>("ssuserInfos.php", true, null, cancellationToken);

        return response.UserInfo;
    }

    public async Task<List<UserLevel>> GetUserLevels(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<UserLevelsResponse>("userlevelsListe.php", false, null, cancellationToken);

        return response.UserLevels.Values.ToList();
    }

    public async Task<List<PlayerCount>> GetPlayerCounts(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<PlayerCountsResponse>("nbJoueursListe.php", false, null, cancellationToken);

        return response.PlayerCounts.Values.ToList();
    }

    public async Task<List<String>> GetSupportTypes(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<SupportTypesResponse>("supportTypesListe.php", false, null, cancellationToken);

        return response.SupportTypes;
    }

    public async Task<List<String>> GetRomTypes(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<RomTypesResponse>("romTypesListe.php", false, null, cancellationToken);

        return response.RomTypes;
    }

    public async Task<List<Genre>> GetGenres(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<GenresResponse>("genresListe.php", false, null, cancellationToken);

        return response.Genres.Values.ToList();
    }

    public async Task<List<Region>> GetRegions(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<RegionsResponse>("regionsListe.php", false, null, cancellationToken);

        return response.Regions.Values.ToList();
    }

    public async Task<List<Language>> GetLanguages(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<LanguagesResponse>("languesListe.php", false, null, cancellationToken);

        return response.Languages.Values.ToList();
    }

    public async Task<List<Classification>> GetClassifications(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<ClassificationsResponse>("classificationListe.php", false, null, cancellationToken);

        return response.Classifications.Values.ToList();
    }

    public async Task<List<SystemMedia>> GetSystemMedia(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<SystemMediasResponse>("mediasSystemeListe.php", false, null, cancellationToken);

        return response.Medias.Values.ToList();
    }
    
    public async Task<List<System>> GetSystems(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<SystemsResponse>("systemesListe.php", false, null, cancellationToken);

        return response.Systems;
    }

    public async Task<List<GameMedia>> GetGameMedia(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<GameMediasResponse>("mediasJeuListe.php", false, null, cancellationToken);

        return response.Medias.Values.ToList();
    }

    public async Task<List<GameInfoField>> GetGameInfoFields(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<GameInfoFieldsResponse>("infosJeuListe.php", false, null, cancellationToken);

        return response.Infos.Values.ToList();
    }

    public async Task<List<RomInfoField>> GetRomInfoFields(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<RomInfoFieldsResponse>("infosRomListe.php", false, null, cancellationToken);

        return response.Infos.Values.ToList();
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

    public async Task<MediaResponse> GetGameImage(Int32 systemId,
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
                "systemeid", systemId.ToString()
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

    public async Task<MediaResponse> GetSystemImage(Int32 systemId,
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
                "systemeid", systemId.ToString()
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

    public async Task<MediaResponse> GetSystemVideo(Int32 systemId,
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
                "systemeid", systemId.ToString()
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

    public async Task<MediaResponse> GetGameVideo(Int32 systemId,
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
                "systemeid", systemId.ToString()
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

    public async Task<MediaResponse> GetGameManual(Int32 systemId,
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
                "systemeid", systemId.ToString()
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

    public async Task<List<SearchGame>> SearchGames(String name, Int32? systemId = null, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<String, String>
        {
            {
                "recherche", name
            }
        };

        if (systemId != null)
        {
            parameters.Add("systemId", systemId.Value.ToString());
        }

        var response = await _requests.GetRequestAsync<SearchGamesResponse>("jeuRecherche.php", true, parameters, cancellationToken);

        return response.Games.ToList();
    }

    public async Task<GetGame?> GetGame(Int32 systemId,
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
                "systemeid", systemId.ToString()
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

        return response.Game;
    }
}
