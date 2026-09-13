using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class ElectronFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "dist",
            "out",
            "release",
            "build",
            "dist_electron",
            "node_modules",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "coverage",
            "test-results",
            ".cache",
            ".turbo",
            ".electron-builder-cache"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml",
            "bun.lockb",
            "bun.lock"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(".map");
}
