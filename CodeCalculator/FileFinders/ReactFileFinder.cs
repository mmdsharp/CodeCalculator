// ReactFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class ReactFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "node_modules",
            "dist",
            "build",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            ".cache",
            ".turbo",
            "coverage",
            "test-results",
            "playwright-report",
            "storybook-static"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml",
            "bun.lockb",
            "bun.lock",
            "npm-shrinkwrap.json"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".map"
        );
}
