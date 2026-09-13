// NextJsFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class NextJsFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".next",
            "out",
            ".turbo",
            ".vercel",
            ".swc",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "node_modules",
            ".pnp",
            ".yarn",
            ".pnpm-store",
            ".cache",
            "coverage",
            ".nyc_output",
            "playwright-report",
            "test-results",
            "dist",
            "build",
            "storybook-static",
            "tmp",
            "temp"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml",
            "bun.lockb",
            "bun.lock",
            "npm-shrinkwrap.json",
            "next-env.d.ts"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".map",
            ".tsbuildinfo"
        );
}
