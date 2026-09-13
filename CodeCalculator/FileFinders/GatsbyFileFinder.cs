// GatsbyFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class GatsbyFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".cache",
            "public",
            "node_modules",
            "dist",
            "build",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "coverage",
            ".turbo",
            "storybook-static"
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
