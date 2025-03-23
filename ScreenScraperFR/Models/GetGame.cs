using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class GetGameResponse
{
    [JsonPropertyName("jeu")]
    public GetGame? Game { get; set; }
}

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class GetGame
{
    [JsonPropertyName("actions")]
    public List<GetGameAction> Actions { get; set; } = [];

    [JsonPropertyName("classifications")]
    public List<GetGameClassification> Classifications { get; set; } = [];

    [JsonPropertyName("cloneof")]
    public Int32 Cloneof { get; set; }

    [JsonPropertyName("dates")]
    public List<GetGameDate> Dates { get; set; } = [];

    [JsonPropertyName("developpeur")]
    public GetGameDeveloppeur? Developpeur { get; set; }

    [JsonPropertyName("editeur")]
    public GetGameDeveloppeur? Editeur { get; set; }

    [JsonPropertyName("familles")]
    public List<GetGameFamille> Familles { get; set; } = [];

    [JsonPropertyName("genres")]
    public List<GetGameFamille> Genres { get; set; } = [];

    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    [JsonPropertyName("joueurs")]
    public GetGameJoueurs? Joueurs { get; set; }

    [JsonPropertyName("medias")]
    public List<GetGameMedia>? Medias { get; set; }

    [JsonPropertyName("modes")]
    public List<GetGameFamille>? Modes { get; set; }

    [JsonPropertyName("noms")]
    public List<GetGameDate>? Noms { get; set; }

    [JsonPropertyName("note")]
    public GetGameJoueurs? Note { get; set; }

    [JsonPropertyName("notgame")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean Notgame { get; set; }

    [JsonPropertyName("rom")]
    public GetGameRom? Rom { get; set; }

    [JsonPropertyName("romid")]

    public Int32 Romid { get; set; }

    [JsonPropertyName("roms")]
    public List<GetGameRomElement> Roms { get; set; } = [];

    [JsonPropertyName("rotation")]

    public Int32 Rotation { get; set; }

    [JsonPropertyName("synopsis")]
    public List<GetGameSynopsis> Synopsis { get; set; } = [];

    [JsonPropertyName("systeme")]
    public GetGameDeveloppeur? Systeme { get; set; }

    [JsonPropertyName("topstaff")]

    public Int32 Topstaff { get; set; }
}

public class GetGameAction
{
    [JsonPropertyName("controle")]
    public List<GetGameControle> Controle { get; set; } = [];

    [JsonPropertyName("id")]

    public Int32 Id { get; set; }
}

public class GetGameControle
{
    [JsonPropertyName("langue")]
    public String Langue { get; set; }

    [JsonPropertyName("recalboxtext")]
    public String Recalboxtext { get; set; }

    [JsonPropertyName("text")]
    public String Text { get; set; }
}

public class GetGameClassification
{
    [JsonPropertyName("text")]
    public String Text { get; set; }

    [JsonPropertyName("type")]
    public String Type { get; set; }
}

public class GetGameDate
{
    [JsonPropertyName("region")]
    public String Region { get; set; }

    [JsonPropertyName("text")]
    public String Text { get; set; }
}

public class GetGameDeveloppeur
{
    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    [JsonPropertyName("text")]
    public String Text { get; set; }
}

public class GetGameFamille
{
    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    [JsonPropertyName("nomcourt")]
    public String Nomcourt { get; set; }

    [JsonPropertyName("noms")]
    public List<GetGameSynopsis> Noms { get; set; } = [];

    [JsonPropertyName("parentid")]

    public Int32 Parentid { get; set; }

    [JsonPropertyName("principale")]

    public Int32 Principale { get; set; }
}

public class GetGameSynopsis
{
    [JsonPropertyName("langue")]
    public String Langue { get; set; }

    [JsonPropertyName("text")]
    public String Text { get; set; }
}

public class GetGameJoueurs
{
    [JsonPropertyName("text")]
    public String Text { get; set; }
}

public class GetGameMedia
{
    [JsonPropertyName("crc")]
    public String Crc { get; set; }

    [JsonPropertyName("format")]
    public String Format { get; set; }

    [JsonPropertyName("md5")]
    public String Md5 { get; set; }

    [JsonPropertyName("parent")]
    public String Parent { get; set; }

    [JsonPropertyName("region")]
    public String Region { get; set; }

    [JsonPropertyName("sha1")]
    public String Sha1 { get; set; }

    [JsonPropertyName("size")]

    public Int32? Size { get; set; }

    [JsonPropertyName("type")]
    public String Type { get; set; }

    [JsonPropertyName("url")]
    public String Url { get; set; }

    [JsonPropertyName("support")]

    public Int32? Support { get; set; }

    [JsonPropertyName("posh")]

    public Int32? Posh { get; set; }

    [JsonPropertyName("posw")]

    public Int32? Posw { get; set; }

    [JsonPropertyName("posx")]

    public Int32? Posx { get; set; }

    [JsonPropertyName("posy")]

    public Int32? Posy { get; set; }

    [JsonPropertyName("subparent")]
    public String Subparent { get; set; }

    [JsonPropertyName("id")]

    public Int32? Id { get; set; }
}

public class GetGameRom
{
    [JsonPropertyName("alt")]

    public Int32 Alt { get; set; }

    [JsonPropertyName("best")]

    public Int32 Best { get; set; }

    [JsonPropertyName("beta")]

    public Int32 Beta { get; set; }

    [JsonPropertyName("demo")]

    public Int32 Demo { get; set; }

    [JsonPropertyName("hack")]

    public Int32 Hack { get; set; }

    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    [JsonPropertyName("netplay")]

    public Int32 Netplay { get; set; }

    [JsonPropertyName("proto")]

    public Int32 Proto { get; set; }

    [JsonPropertyName("regions")]
    public GetGameRegions? Regions { get; set; }

    [JsonPropertyName("romcloneof")]

    public Int32 Romcloneof { get; set; }

    [JsonPropertyName("romcrc")]
    public String Romcrc { get; set; }

    [JsonPropertyName("romfilename")]
    public String Romfilename { get; set; }

    [JsonPropertyName("rommd5")]
    public String Rommd5 { get; set; }

    [JsonPropertyName("romnumsupport")]

    public Int32 Romnumsupport { get; set; }

    [JsonPropertyName("romregions")]
    public String Romregions { get; set; }

    [JsonPropertyName("romsha1")]
    public String Romsha1 { get; set; }

    [JsonPropertyName("romsize")]

    public Int32 Romsize { get; set; }

    [JsonPropertyName("romsupporttype")]
    public String Romsupporttype { get; set; }

    [JsonPropertyName("romtotalsupport")]

    public Int32 Romtotalsupport { get; set; }

    [JsonPropertyName("romtype")]
    public String Romtype { get; set; }

    [JsonPropertyName("trad")]

    public Int32 Trad { get; set; }

    [JsonPropertyName("unl")]

    public Int32 Unl { get; set; }
}

public class GetGameRegions
{
    [JsonPropertyName("regions_de")]
    public List<String> RegionsDe { get; set; } = [];

    [JsonPropertyName("regions_en")]
    public List<String> RegionsEn { get; set; } = [];

    [JsonPropertyName("regions_es")]
    public List<String> RegionsEs { get; set; } = [];

    [JsonPropertyName("regions_fr")]
    public List<String> RegionsFr { get; set; } = [];

    [JsonPropertyName("regions_id")]
    public List<Int32> RegionsId { get; set; } = [];

    [JsonPropertyName("regions_pt")]
    public List<String> RegionsPt { get; set; } = [];

    [JsonPropertyName("regions_shortname")]
    public List<String> RegionsShortname { get; set; } = [];

    [JsonPropertyName("regions_it")]
    public List<String> RegionsIt { get; set; } = [];
}

public class GetGameRomElement
{
    [JsonPropertyName("alt")]

    public Int32 Alt { get; set; }

    [JsonPropertyName("best")]

    public Int32 Best { get; set; }

    [JsonPropertyName("beta")]

    public Int32 Beta { get; set; }

    [JsonPropertyName("demo")]

    public Int32 Demo { get; set; }

    [JsonPropertyName("hack")]

    public Int32 Hack { get; set; }

    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    [JsonPropertyName("netplay")]

    public Int32 Netplay { get; set; }

    [JsonPropertyName("proto")]

    public Int32 Proto { get; set; }

    [JsonPropertyName("regions")]
    public GetGameRegions? Regions { get; set; }

    [JsonPropertyName("romcloneof")]

    public Int32 Romcloneof { get; set; }

    [JsonPropertyName("romcrc")]
    public String Romcrc { get; set; }

    [JsonPropertyName("romfilename")]
    public String Romfilename { get; set; }

    [JsonPropertyName("rommd5")]
    public String Rommd5 { get; set; }

    [JsonPropertyName("romnumsupport")]

    public Int32 Romnumsupport { get; set; }

    [JsonPropertyName("romsha1")]
    public String Romsha1 { get; set; }

    [JsonPropertyName("romsize")]

    public Int32 Romsize { get; set; }

    [JsonPropertyName("romtotalsupport")]

    public Int32 Romtotalsupport { get; set; }

    [JsonPropertyName("trad")]

    public Int32 Trad { get; set; }

    [JsonPropertyName("unl")]

    public Int32 Unl { get; set; }

    [JsonPropertyName("langues")]
    public GetGameLangues? Langues { get; set; }
}

public class GetGameLangues
{
    [JsonPropertyName("langues_de")]
    public List<String> LanguesDe { get; set; } = [];

    [JsonPropertyName("langues_en")]
    public List<String> LanguesEn { get; set; } = [];

    [JsonPropertyName("langues_es")]
    public List<String> LanguesEs { get; set; } = [];

    [JsonPropertyName("langues_fr")]
    public List<String> LanguesFr { get; set; } = [];

    [JsonPropertyName("langues_id")]
    public List<Int32> LanguesId { get; set; } = [];

    [JsonPropertyName("langues_it")]
    public List<String> LanguesIt { get; set; } = [];

    [JsonPropertyName("langues_pt")]
    public List<String> LanguesPt { get; set; } = [];

    [JsonPropertyName("langues_shortname")]
    public List<String> LanguesShortname { get; set; } = [];
}
