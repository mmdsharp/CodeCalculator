#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class ReactNativeFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        "node_modules",
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "android/build",
        "android/.gradle",
        "android/.idea",
        "ios/Pods",
        "ios/build",
        "coverage",
        ".cache",
        ".turbo",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "package-lock.json",
        "yarn.lock",
        "pnpm-lock.yaml",
        "bun.lockb",
        "bun.lock",
        "Podfile.lock"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(".map", ".apk", ".aab", ".ipa");
}
