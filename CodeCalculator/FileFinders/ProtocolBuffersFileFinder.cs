// ProtocolBuffersFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class ProtocolBuffersFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "node_modules",
            "vendor",
            "build",
            "dist",
            "out",
            "target"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "buf.lock"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".proto.bin"
        );
}
