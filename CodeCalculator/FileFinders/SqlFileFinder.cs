#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class SqlFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "bin",
        "obj",
        "build",
        "dist",
        "node_modules",
        "packages"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "schema.sql.bak"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".bak",
            ".mdf",
            ".ndf",
            ".ldf",
            ".db",
            ".sqlite",
            ".sqlite3"
        );
}
