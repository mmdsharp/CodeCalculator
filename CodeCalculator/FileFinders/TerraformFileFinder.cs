using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class TerraformFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            ".terraform",
            ".terragrunt-cache",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            ".terraform.lock.hcl",
            "terraform.tfstate",
            "terraform.tfstate.backup",
            "crash.log"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".tfstate",
            ".tfplan"
        );
}
