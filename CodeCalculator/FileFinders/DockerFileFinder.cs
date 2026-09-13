#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class DockerFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "node_modules",
        "bin",
        "obj",
        "dist",
        "build",
        "target",
        ".docker",
        ".cache"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "docker-compose.override.yml"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".tar",
            ".tar.gz",
            ".tar.bz2",
            ".tar.xz"
        );
}
