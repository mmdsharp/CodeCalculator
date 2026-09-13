using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class ViteFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".vite",
            "dist",
            "build",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "node_modules",
            ".pnpm-store",
            ".cache",
            ".turbo",
            "coverage",
            ".nyc_output",
            "playwright-report",
            "test-results",
            "storybook-static"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml",
            "bun.lockb",
            "bun.lock",
            "npm-shrinkwrap.json"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(".map");
}
