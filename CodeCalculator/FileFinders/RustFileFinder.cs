using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class RustFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "target",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set("Cargo.lock");

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".rlib",
            ".rmeta",
            ".d",
            ".pdb"
        );
}
