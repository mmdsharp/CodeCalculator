using System;
using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal static class FileFinderExtensions
{
    public static List<FileProperty> GetFiles(
        this IFileFinder finder,
        string baseDirectory)
    {
        ArgumentNullException.ThrowIfNull(finder);
        ArgumentException.ThrowIfNullOrWhiteSpace(baseDirectory);

        return finder.GetFiles(
            FileFinderOptions.FromSingle(baseDirectory));
    }
}
