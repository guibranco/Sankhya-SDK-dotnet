using System.IO;

namespace Sankhya.Helpers;

/// <summary>
/// Provides helper methods for working with streams.
/// </summary>
internal static class StreamHelpers
{
    /// <summary>
    /// Copies the contents of the source stream to the destination memory stream.
    /// </summary>
    /// <param name="sourceStream">The source stream to copy from.</param>
    /// <param name="destination">The destination memory stream to copy to.</param>
    public static void CopyStreamToMemory(this Stream sourceStream, MemoryStream destination)
    {
        if (sourceStream == null)
        {
            return;
        }

        var buffer = new byte[32768];
        int bytesRead;

        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            destination.Write(buffer, 0, bytesRead);
        }

        sourceStream.Close();
    }
}
