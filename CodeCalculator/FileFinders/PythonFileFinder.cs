using System.Collections.Generic;

namespace CodeCalculator.FileFinders;

internal sealed class PythonFileFinder : TextFileFinderBase
{
    protected override IReadOnlySet<string> IgnoredFolders { get; } =
        Set(
            "__pycache__",
            ".venv",
            "venv",
            "env",
            ".pytest_cache",
            ".mypy_cache",
            ".ruff_cache",
            ".tox",
            ".nox",
            ".hypothesis",
            ".eggs",
            "build",
            "dist",
            ".git",
            ".svn",
            ".hg",
            ".vscode",
            ".idea",
            ".ipynb_checkpoints",
            "site-packages",
            "node_modules",
            "htmlcov"
        );

    protected override IReadOnlySet<string> IgnoredFileNames { get; } =
        Set(
            "poetry.lock",
            "Pipfile.lock",
            "uv.lock"
        );

    protected override IReadOnlySet<string> BinaryExtensions { get; } =
        MergeShared(
            ".pyc",
            ".pyo",
            ".pyd",
            ".so",
            ".pdb",
            ".whl"
        );
}
