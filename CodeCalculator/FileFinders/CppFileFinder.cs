#nullable enable

namespace CodeCalculator.FileFinders;

internal sealed class CppFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } = Set(
        ".git",
        ".svn",
        ".hg",
        ".vscode",
        ".idea",
        "build",
        "Build",
        "bin",
        "obj",
        "out",
        "cmake-build-debug",
        "cmake-build-release",
        "cmake-build-relwithdebinfo",
        "cmake-build-minsizerel",
        "Debug",
        "Release",
        "x64",
        "x86",
        "coverage"
    );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } = Set(
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
            ".pdb",
            ".gch",
            ".pch"
        );
}
