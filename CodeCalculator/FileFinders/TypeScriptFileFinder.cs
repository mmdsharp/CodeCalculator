#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class TypeScriptFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        "node_modules",
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        ".cache",
        ".turbo",
        ".yarn",
        ".pnpm-store",
        ".pnp",
        "dist",
        "build",
        "out",
        "coverage",
        ".nyc_output",
        "test-results",
        "playwright-report",
        "storybook-static"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "package-lock.json",
        "yarn.lock",
        "pnpm-lock.yaml",
        "bun.lockb",
        "bun.lock",
        "npm-shrinkwrap.json",
        "tsconfig.tsbuildinfo"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".map",
            ".tsbuildinfo"
        );
}
