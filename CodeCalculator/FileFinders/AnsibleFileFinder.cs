#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class AnsibleFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".cache",
        "__pycache__",
        ".ansible",
        "collections",
        "tmp"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "ansible.cfg"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared();
}
