#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class OCamlFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "_build",
        "_opam",
        "build",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "dune-package"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".cmo",
            ".cmi",
            ".cmx",
            ".cmxa",
            ".a",
            ".so"
        );
}
