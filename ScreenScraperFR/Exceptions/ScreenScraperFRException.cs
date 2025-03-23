namespace ScreenScraperFR;

public class ScreenScraperFRException(String error, Int32 statusCode) : Exception(GetMessage(error, statusCode))
{
    public String Error { get; } = error;
    public Int32 StatusCode { get; } = statusCode;

    private static readonly Dictionary<String, String> ErrorMessages = new()
    {
        {
            "problème avec l'url", "Bad request: The API call URL contains no information."
        },
        {
            "Il manque des champs obligatoires dans l'url", "Bad request: Required fields are missing from the API URL."
        },
        {
            "Erreur dans le nom du fichier rom : celui-ci contient un chemin d'accés", "Invalid ROM file name: It contains a file path."
        },
        {
            "Champ crc, md5 ou sha1 erroné", "Invalid checksum field: CRC, MD5, or SHA1 is incorrectly formatted."
        },
        {
            "Problème dans le nom du fichier rom", "Invalid ROM file name format."
        },
        {
            "API fermé pour les non membres ou les membres inactifs", "Unauthorized: API access restricted to active members only."
        },
        {
            "Erreur de login : Vérifier vos identifiants développeur !", "Login error: Check your developer credentials."
        },
        {
            "Erreur : Jeu non trouvée ! / Erreur : Rom/Iso/Dossier non trouvée !", "Not found: The requested game, ROM, ISO, or folder could not be located."
        },
        {
            "API totalement fermé", "Locked: The API is completely closed due to critical server issues."
        },
        {
            "Le logiciel de scrape utilisé a été blacklisté (non conforme / version obsolète)", "Upgrade required: Your scraping software is outdated or non-compliant."
        },
        {
            "Le nombre de threads autorisé pour le membre est atteint", "Too many requests: You’ve reached the allowed thread limit."
        },
        {
            "Le nombre de threads par minute autorisé pour le membre est atteint", "Too many requests: You’ve exceeded the thread-per-minute limit."
        },
        {
            "The maximum threads allowed to leecher users is already used", "Too many requests: Maximum threads used for leecher users."
        },
        {
            "The maximum threads is already used", "Too many requests: Overall thread limit reached."
        },
        {
            "Votre quota de scrape est dépassé pour aujourd'hui !", "Quota exceeded: You’ve reached your daily scrape limit."
        },
        {
            "Faite du tri dans vos fichiers roms et repassez demain !", "Too many unrecognized ROMs: Clean up your files and try again tomorrow."
        }
    };

    private static String GetMessage(String error, Int32 statusCode)
    {
        if (ErrorMessages.TryGetValue(error, out var errorMessage))
        {
            return errorMessage;
        }
        return $"An error has occurred on the ScreenScraper.fr API with statuscode {statusCode}: {error}";
    }
}