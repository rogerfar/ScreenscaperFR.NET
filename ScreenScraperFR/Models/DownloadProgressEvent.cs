namespace ScreenScraperFR;

public class DownloadProgressEventArgs(Int64 bytesReceived, Int64 totalBytes, Double speedMbps) : EventArgs
{
    public Double ProgressPercentage { get; private set; } = (Double)bytesReceived / totalBytes * 100;
    public Double SpeedMbps { get; private set; } = speedMbps;
    public Int64 BytesReceived { get; private set; } = bytesReceived;
    public Int64 TotalBytes { get; private set; } = totalBytes;
}