#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class NestJsFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        "node_modules",
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "dist",
        "build",
        "coverage",
        ".cache",
        ".turbo",
        "test-results"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "package-lock.json",
        "yarn.lock",
        "pnpm-lock.yaml",
        "bun.lockb",
        "bun.lock",
        "npm-shrinkwrap.json"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(".map", ".tsbuildinfo");
}
