using System;
using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class FileFinderOptions
{
    public required IReadOnlyList<string> RootDirectories { get; init; }

    public IReadOnlySet<string> ExcludedDirectories { get; init; } =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public bool ThrowOnMissingRoot { get; init; } = true;

    public static FileFinderOptions FromSingle(string baseDirectory)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(baseDirectory);

        return new FileFinderOptions
        {
            RootDirectories = new[] { baseDirectory }
        };
    }

    public static FileFinderOptions FromMany(params string[] baseDirectories)
    {
        ArgumentNullException.ThrowIfNull(baseDirectories);

        if (baseDirectories.Length == 0)
        {
            throw new ArgumentException(
                "At least one root directory is required.",
                nameof(baseDirectories));
        }

        for (var i = 0; i < baseDirectories.Length; i++)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(
                baseDirectories[i],
                nameof(baseDirectories));
        }

        return new FileFinderOptions
        {
            RootDirectories = baseDirectories
        };
    }
}
