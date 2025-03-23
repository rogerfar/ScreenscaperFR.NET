using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class UserLevelsResponse
{
    /// <summary>
    /// Dictionary of user levels keyed by their numeric ID as a string (from JSON).
    /// </summary>
    [JsonPropertyName("userlevels")]
    public Dictionary<String, UserLevel> UserLevels { get; set; } = new();
}

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class UserLevel
{
    /// <summary>
    /// Numeric identifier of the user level.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Name of the user level in French.
    /// </summary>
    [JsonPropertyName("nom_fr")]
    public required String NameFr { get; set; }

    /// <summary>
    /// Name of the user level in English.
    /// </summary>
    [JsonIgnore]
    public String NameEn
    {
        get
        {
            return NameFr switch
            {
                "Membre" => "Inactive Member",
                "Contributeur Occasionnel" => "Casual Contributor",
                "Infographiste Contributeur Occasionnel" => "Casual Graphic Artist Contributor",
                "Contributeur" => "Contributor",
                "Infographiste Contributeur" => "Infographist Contributor",
                "Fervent Contributeur" => "Enthusiast Contributor",
                "Fervent Infographiste Contributeur" => "Enthusiast Graphic Artist Contributor",
                "Maître Contributeur" => "Master Contributor",
                "Maître Infographiste Contributeur" => "Master Graphic Artist Contributor",
                "Grand Grourou Contributeur" => "Great Guru Contributor",
                "Grand Gourou Infographiste Contributeur" => "Great Guru Graphic Designer Contributor",
                "Contributeur de Confiance" => "Trusted Contributor",
                "Infographiste Contributeur de Confiance" => "Trusted Infographist Contributor",
                "Traducteur" => "Translator",
                "Community Manager" => "Community Manager",
                "Modérateur Système(s)" => "System Moderator",
                "Modérateur" => "Moderator",
                "Super Modérateur" => "Super Moderator",
                "Admin" => "Administrator",
                "Super Admin" => "Super Admin",
                "Robot" => "Robot",
                "Darwiniste qui en veut" => "Darwinist",
                "Demi Dieu" => "Half-God",
                "2/3 de Dieu" => "2/3 God",
                "Dieu tout puissant" => "Almighty God",
                "Chuck Norris" => "Chuck Norris",
                _ => NameFr
            };

        }
    }
}
