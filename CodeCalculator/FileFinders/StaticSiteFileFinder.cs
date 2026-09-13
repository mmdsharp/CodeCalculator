using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class StaticSiteFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "public",
            "resources/_gen",
            "_site",
            ".jekyll-cache",
            ".jekyll-metadata",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "node_modules",
            ".pnpm-store",
            ".cache",
            ".turbo"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml",
            "Gemfile.lock",
            "bun.lockb",
            "bun.lock"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(".map");
}
