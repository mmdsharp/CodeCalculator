using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class PhpFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "vendor",
            "storage",
            "bootstrap/cache",
            "public/build",
            "public/storage",
            "var/cache",
            "var/log",
            "build",
            "dist",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "node_modules"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "composer.lock",
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(".phar");
}
