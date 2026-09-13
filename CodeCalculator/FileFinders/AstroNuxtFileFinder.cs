// AstroNuxtFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class AstroNuxtFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".astro",
            ".output",
            ".nuxt",
            ".cache",
            "build",
            ".vercel",
            ".netlify",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            "node_modules",
            ".pnpm-store",
            ".turbo",
            "coverage",
            "test-results",
            "playwright-report",
            "dist"
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
        MergeShared(
            ".map"
        );
}
