#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class RubyFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "vendor",
        "tmp",
        "log",
        "coverage",
        "node_modules",
        "public/assets",
        "public/packs",
        "public/packs-test",
        "storage",
        "build",
        "dist"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "Gemfile.lock",
        "yarn.lock",
        "package-lock.json",
        "pnpm-lock.yaml"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".gem",
            ".rbc"
        );
}
