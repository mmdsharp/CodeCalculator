using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class UnityFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "Library",
            "Temp",
            "Obj",
            "obj",
            "Build",
            "Builds",
            "Logs",
            "UserSettings",
            "MemoryCaptures",
            "Recordings",
            ".git",
            ".svn",
            ".hg",
            ".vs",
            ".vscode",
            ".idea",
            ".consulo"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set("packages-lock.json");

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".unitypackage",
            ".assetbundle",
            ".bytes",
            ".shadercache",
            ".pdb",
            ".dll"
        );
}
