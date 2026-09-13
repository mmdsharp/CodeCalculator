#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class CMakeFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "build",
        "Build",
        "cmake-build-debug",
        "cmake-build-release",
        "cmake-build-relwithdebinfo",
        "cmake-build-minsizerel",
        "Debug",
        "Release",
        "x64",
        "x86"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
        "CMakeCache.txt",
        "compile_commands.json"
    );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".o",
            ".obj",
            ".a",
            ".lib",
            ".so",
            ".dll",
            ".dylib",
            ".exe",
            ".pdb"
        );
}
