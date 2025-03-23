using ScreenScraperFR.Models;

namespace ScreenScraperFR;

public interface IScreenScraperFRClient
{
    /// <summary>
    /// Retrieves information about the ScreenScraper server infrastructure.
    /// </summary>
    Task<ServerInfrastructureInfo> GetInfrastructureInfo(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves information about the authenticated ScreenScraper user.
    /// </summary>
    Task<UserInfo?> GetUserInfo(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of user levels on ScreenScraper.
    /// </summary>
    Task<List<UserLevel>> GetUserLevels(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported player counts (e.g., 1-4 players, multiplayer, etc.).
    /// </summary>
    Task<List<PlayerCount>> GetPlayerCounts(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported media types (e.g., box, screenshot, title screen).
    /// </summary>
    Task<List<String>> GetSupportTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of ROM types recognized by ScreenScraper.
    /// </summary>
    Task<List<String>> GetRomTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of game genres.
    /// </summary>
    Task<List<Genre>> GetGenres(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported regions (e.g., Europe, USA, Japan).
    /// </summary>
    Task<List<Region>> GetRegions(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of supported languages.
    /// </summary>
    Task<List<Language>> GetLanguages(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of game content ratings/classifications (e.g., ESRB, PEGI).
    /// </summary>
    Task<List<Classification>> GetClassifications(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available media types for game systems.
    /// </summary>
    Task<List<SystemMedia>> GetSystemMedias(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available media types for games.
    /// </summary>
    Task<List<GameMedia>> GetGameMedias(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available text information fields for games (e.g., summary, developer).
    /// </summary>
    Task<List<GameInfoField>> GetGameInfoFields(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of available text information fields for ROMs.
    /// </summary>
    Task<List<RomInfoField>> GetRomInfoFields(CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads media images for game groups (e.g., sagas or franchises).
    /// Returns null when no media is available.
    /// </summary>
    Task<MediaResponse> GetGroupMedia(Int32 groupId,
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
    /// Downloads media images for game companies (e.g., logos, banners).
    /// </summary>
    Task<MediaResponse> GetCompanyMedia(Int32 companyId,
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
    Task<List<System>> GetSystems(CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads image media (e.g., logos, artwork) for a system.
    /// </summary>
    Task<MediaResponse> GetSystemMedia(Int32 systemId,
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
    /// Downloads video media (e.g., intro videos) for a system.
    /// </summary>
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
    /// </summary>
    Task<MediaResponse> GetGameMedia(Int32 systemId,
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
    /// Downloads video media for a specific game.
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
    /// Downloads manuals for a specific game.
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

    public async Task<List<SystemMedia>> GetSystemMedias(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<SystemMediasResponse>("mediasSystemeListe.php", false, null, cancellationToken);

        return response.Medias.Values.ToList();
    }

    public async Task<List<GameMedia>> GetGameMedias(CancellationToken cancellationToken = default)
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

    public async Task<MediaResponse> GetGroupMedia(Int32 groupId,
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

    public async Task<MediaResponse> GetCompanyMedia(Int32 companyId,
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

    public async Task<List<System>> GetSystems(CancellationToken cancellationToken = default)
    {
        var response = await _requests.GetRequestAsync<SystemsResponse>("systemesListe.php", false, null, cancellationToken);

        return response.Systems;
    }

    public async Task<MediaResponse> GetSystemMedia(Int32 systemId,
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

    public async Task<MediaResponse> GetGameMedia(Int32 systemId,
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
}
