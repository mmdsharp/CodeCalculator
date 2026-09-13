using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class SwiftFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "build",
            "Build",
            "DerivedData",
            "xcuserdata",
            "Pods",
            ".build",
            ".swiftpm",
            "Carthage/Build",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "TestResults"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "Package.resolved",
            "Podfile.lock"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".xcarchive",
            ".ipa",
            ".app",
            ".dSYM",
            ".o",
            ".a",
            ".framework",
            ".xcframework",
            ".swiftmodule",
            ".swiftdoc"
        );
}
