namespace ScreenScraperFR;

public class MediaResponse(Byte[]? data, MediaResponseType? response)
{
    public Byte[]? Data { get; } = data;
    public MediaResponseType? Result { get; } = response;
}

public enum MediaResponseType
{
    CrcOk,
    Md5Ok,
    Sha1Ok,
    Nomedia
}