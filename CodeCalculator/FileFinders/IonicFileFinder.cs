// IonicFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class IonicFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "node_modules",
            "www",
            "dist",
            "build",
            ".ionic",
            ".angular",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            ".cache",
            ".turbo",
            "coverage"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml",
            "bun.lockb",
            "bun.lock"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".map"
        );
}
