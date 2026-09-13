#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class ElixirFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "_build",
        "deps",
        ".elixir_ls",
        "cover",
        "tmp",
        "node_modules"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "mix.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".beam",
            ".ez"
        );
}
