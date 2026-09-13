using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class GenericTextFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".git",
            ".svn",
            ".hg",
            ".vs",
            ".vscode",
            ".idea",
            "node_modules",
            "vendor",
            "packages",
            "bin",
            "obj",
            "dist",
            "build",
            "out",
            "target",
            "publish",
            ".cache",
            ".turbo",
            ".next",
            ".nuxt",
            "coverage",
            "TestResults"
        );
}
