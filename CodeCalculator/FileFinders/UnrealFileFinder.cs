#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class UnrealFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vs",
        ".vscode",
        ".idea",
        "Binaries",
        "DerivedDataCache",
        "Intermediate",
        "Saved",
        "Build"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        ".suo"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".uasset",
            ".umap",
            ".pak",
            ".dll",
            ".lib",
            ".obj",
            ".pdb"
        );
}
