#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class ObjectiveCFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "build",
        "Build",
        "DerivedData",
        "xcuserdata",
        "Pods",
        "Carthage/Build",
        ".build"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "Podfile.lock",
        "Package.resolved"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".o",
            ".a",
            ".dylib",
            ".framework",
            ".xcframework",
            ".app",
            ".dSYM",
            ".ipa"
        );
}
