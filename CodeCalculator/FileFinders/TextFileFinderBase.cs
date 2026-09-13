using System;
using System.Collections.Generic;
using System.IO;

namespace CodeCalculator.FileFinders;

internal abstract class TextFileFinderBase : IFileFinder
{
    protected abstract IReadOnlySet<string> IgnoredFolders { get; }

    protected virtual IReadOnlySet<string> IgnoredFileNames { get; } =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    protected virtual IReadOnlySet<string> BinaryExtensions =>
        SharedBinaryExtensions;

    protected virtual long MaxTextFileSizeBytes => 10 * 1024 * 1024;

    protected virtual int SniffBytes => 8192;

    protected static readonly IReadOnlySet<string> SharedBinaryExtensions =
        Set(
            ".png",
            ".jpg",
            ".jpeg",
            ".gif",
            ".bmp",
            ".ico",
            ".webp",
            ".tif",
            ".tiff",
            ".avif",
            ".heic",

            ".mp3",
            ".mp4",
            ".wav",
            ".avi",
            ".mkv",
            ".mov",
            ".webm",
            ".ogg",

            ".zip",
            ".rar",
            ".7z",
            ".tar",
            ".gz",
            ".bz2",
            ".xz",

            ".exe",
            ".dll",
            ".so",
            ".dylib",
            ".pdb",
            ".lib",
            ".bin",
            ".class",
            ".jar",
            ".war",
            ".apk",
            ".a",
            ".o",

            ".doc",
            ".docx",
            ".xls",
            ".xlsx",
            ".ppt",
            ".pptx",

            ".db",
            ".sqlite",
            ".mdf",
            ".ldf",

            ".ttf",
            ".otf",
            ".woff",
            ".woff2",
            ".eot",

            ".pdf",
            ".iso",
            ".img",
            ".nupkg",
            ".snk",
            ".pfx"
        );

    protected static IReadOnlySet<string> Set(params string[] values)
    {
        return new HashSet<string>(
            values,
            StringComparer.OrdinalIgnoreCase);
    }

    protected static IReadOnlySet<string> MergeShared(params string[] additionalExtensions)
    {
        var extensions = new HashSet<string>(
            SharedBinaryExtensions,
            StringComparer.OrdinalIgnoreCase);

        foreach (var extension in additionalExtensions)
        {
            extensions.Add(extension);
        }

        return extensions;
    }

    public List<FileProperty> GetFiles(FileFinderOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (options.RootDirectories is null)
        {
            throw new ArgumentException(
                "RootDirectories cannot be null.",
                nameof(options));
        }

        if (options.RootDirectories.Count == 0)
        {
            throw new ArgumentException(
                "At least one root directory is required.",
                nameof(options));
        }

        if (options.ExcludedDirectories is null)
        {
            throw new ArgumentException(
                "ExcludedDirectories cannot be null.",
                nameof(options));
        }

        if (MaxTextFileSizeBytes < 0)
        {
            throw new InvalidOperationException(
                "MaxTextFileSizeBytes cannot be negative.");
        }

        if (SniffBytes < 1)
        {
            throw new InvalidOperationException(
                "SniffBytes must be greater than zero.");
        }

        var files = new List<FileProperty>();
        var seenFiles = new HashSet<string>(
            StringComparer.OrdinalIgnoreCase);

        foreach (var rootDirectory in options.RootDirectories)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(
                rootDirectory,
                nameof(options.RootDirectories));

            var fullRootDirectory = Path.GetFullPath(rootDirectory);

            if (!Directory.Exists(fullRootDirectory))
            {
                if (options.ThrowOnMissingRoot)
                {
                    throw new DirectoryNotFoundException(
                        $"Root directory was not found: {fullRootDirectory}");
                }

                continue;
            }

            Collect(
                fullRootDirectory,
                options,
                seenFiles,
                files);
        }

        return files;
    }

    private void Collect(
        string directory,
        FileFinderOptions options,
        HashSet<string> seenFiles,
        List<FileProperty> files)
    {
        IEnumerable<string> filePaths;

        try
        {
            filePaths = Directory.EnumerateFiles(directory);
        }
        catch (IOException)
        {
            return;
        }
        catch (UnauthorizedAccessException)
        {
            return;
        }

        foreach (var filePath in filePaths)
        {
            try
            {
                var fullFilePath = Path.GetFullPath(filePath);

                if (!seenFiles.Add(fullFilePath))
                {
                    continue;
                }

                if (ShouldSkipFile(fullFilePath))
                {
                    continue;
                }

                files.Add(new FileProperty(fullFilePath));
            }
            catch (IOException)
            {
                // The file may disappear or become unavailable while scanning.
            }
            catch (UnauthorizedAccessException)
            {
                // Ignore files that cannot be accessed.
            }
        }

        IEnumerable<string> subDirectories;

        try
        {
            subDirectories = Directory.EnumerateDirectories(directory);
        }
        catch (IOException)
        {
            return;
        }
        catch (UnauthorizedAccessException)
        {
            return;
        }

        foreach (var subDirectory in subDirectories)
        {
            try
            {
                var fullSubDirectory = Path.GetFullPath(subDirectory);

                if (options.ExcludedDirectories.Contains(fullSubDirectory))
                {
                    continue;
                }

                var directoryName = Path.GetFileName(
                    fullSubDirectory.TrimEnd(
                        Path.DirectorySeparatorChar,
                        Path.AltDirectorySeparatorChar));

                if (IgnoredFolders.Contains(directoryName))
                {
                    continue;
                }

                var attributes = File.GetAttributes(fullSubDirectory);

                if ((attributes & FileAttributes.ReparsePoint) != 0)
                {
                    continue;
                }

                Collect(
                    fullSubDirectory,
                    options,
                    seenFiles,
                    files);
            }
            catch (IOException)
            {
                // Ignore directories that disappear or become unavailable.
            }
            catch (UnauthorizedAccessException)
            {
                // Ignore directories that cannot be accessed.
            }
        }
    }

    private bool ShouldSkipFile(string filePath)
    {
        var fileName = Path.GetFileName(filePath);

        if (IgnoredFileNames.Contains(fileName))
        {
            return true;
        }

        var extension = Path.GetExtension(filePath);

        if (BinaryExtensions.Contains(extension))
        {
            return true;
        }

        var fileInfo = new FileInfo(filePath);

        if (fileInfo.Length == 0)
        {
            return false;
        }

        if (fileInfo.Length > MaxTextFileSizeBytes)
        {
            return true;
        }

        return IsBinary(filePath);
    }

    private bool IsBinary(string filePath)
    {
        var bufferSize = Math.Min(
            SniffBytes,
            int.MaxValue);

        Span<byte> buffer = stackalloc byte[bufferSize];

        using var stream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite);

        var bytesRead = stream.Read(buffer);

        if (bytesRead == 0)
        {
            return false;
        }

        if (bytesRead >= 3 &&
            buffer[0] == 0xEF &&
            buffer[1] == 0xBB &&
            buffer[2] == 0xBF)
        {
            return false;
        }

        if (bytesRead >= 2 &&
            buffer[0] == 0xFF &&
            buffer[1] == 0xFE)
        {
            return false;
        }

        if (bytesRead >= 2 &&
            buffer[0] == 0xFE &&
            buffer[1] == 0xFF)
        {
            return false;
        }

        var controlCharacters = 0;

        for (var i = 0; i < bytesRead; i++)
        {
            var value = buffer[i];

            if (value == 0x00)
            {
                return true;
            }

            if (value < 0x09 ||
                (value >= 0x0E && value <= 0x1F))
            {
                controlCharacters++;
            }
        }

        return controlCharacters > bytesRead * 0.30;
    }
}
