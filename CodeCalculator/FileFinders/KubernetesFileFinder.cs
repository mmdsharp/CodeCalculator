// KubernetesFileFinder.cs

namespace CodeCalculator.FileFinders;

internal sealed class KubernetesFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            ".cache",
            ".terraform"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "kubeconfig"
        );
}
