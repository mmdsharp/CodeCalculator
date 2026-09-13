#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class GraphQLFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "node_modules",
        "dist",
        "build",
        "coverage",
        ".cache"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "package-lock.json",
        "yarn.lock",
        "pnpm-lock.yaml",
        "bun.lockb",
        "bun.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(".map");
}
