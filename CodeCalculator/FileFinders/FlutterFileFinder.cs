using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class FlutterFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "build",
            ".dart_tool",
            ".flutter-plugins",
            ".pub-cache",
            ".pub",
            "android/build",
            "android/.gradle",
            "android/.idea",
            "ios/Pods",
            "ios/.symlinks",
            "ios/Flutter/ephemeral",
            "macos/Pods",
            "macos/Flutter/ephemeral",
            "web/build",
            ".vscode",
            ".idea",
            ".git",
            ".svn",
            ".hg"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "pubspec.lock",
            "Podfile.lock",
            "GeneratedPluginRegistrant.java",
            "GeneratedPluginRegistrant.m",
            "GeneratedPluginRegistrant.swift"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".dill",
            ".snapshot",
            ".apk",
            ".aab",
            ".ipa"
        );
}
