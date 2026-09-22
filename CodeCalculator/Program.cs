using CodeCalculator;
using CodeCalculator.FileFinders;

int pageNumber = 1;
bool isFirstAttempt = true;

IFileFinder fileFinder;

while (true)
{
    string previousPage = pageNumber > 1 ? "last page : l" : "";
    string nextPage = pageNumber < 9 ? "next page : n" : "";

    string navigation = string.Join(
        ", ",
        new[] { nextPage, previousPage }
            .Where(x => !string.IsNullOrEmpty(x)));

    string text =
        $"page {pageNumber} :\r\n" +
        FileFinderFactory.GetGuide(pageNumber) +
        "\r\n" +
        $"enter type number: ({navigation})\r\n";

    if (isFirstAttempt)
    {
        Console.Write(text);
        isFirstAttempt = false;
    }
    else
    {
        ReplaceLastLines(text);
    }

    string? input = Console.ReadLine();

    if (int.TryParse(input, out int projectType))
    {
        if (projectType >= 1 && projectType <= 70)
        {
            fileFinder = FileFinderFactory.Create(projectType);
            break;
        }

        continue;
    }

    switch (input?.Trim().ToLowerInvariant())
    {
        case "n":
            if (pageNumber < 9)
                pageNumber++;

            break;

        case "l":
            if (pageNumber > 1)
                pageNumber--;

            break;
    }
}


FileFinderOptions options = GetFileFinderOptions();

List<FileProperty> files = fileFinder.GetFiles(options);

SumFileProperty sumFileProperty = new(files);

Console.WriteLine(
    "all files : \n" +
    StringExtensions.ShiftTab(
        sumFileProperty.ToString()));

List<SumFilePropertyGroup> groups =
    SumFilePropertyGroup.GroupByExtension(sumFileProperty);

if (groups.Count > 1)
{
    Console.WriteLine($"your projct contains {JoinWithAnd(
        groups.Select(g => g.Key).ToList())} files");
}

foreach (var group in groups)
{
    Console.WriteLine(group.ToString());
}


static string JoinWithAnd(List<string> types)
{
    string result = types[0];

    for (int i = 1; i < types.Count - 1; i++)
    {
        result += ", " + types[i];
    }

    result += " and " + types.Last();

    return result;
}

static FileFinderOptions GetFileFinderOptions()
{
    Console.WriteLine();
    Console.WriteLine("=== File Finder Options ===");
    Console.WriteLine();

    IReadOnlyList<string> rootDirectories = GetRootDirectories();

    Console.WriteLine();

    IReadOnlySet<string> excludedDirectories =
        GetExcludedDirectories();

    Console.WriteLine();

    bool throwOnMissingRoot = GetThrowOnMissingRoot();

    return new FileFinderOptions
    {
        RootDirectories = rootDirectories,
        ExcludedDirectories = excludedDirectories,
        ThrowOnMissingRoot = throwOnMissingRoot
    };
}


static IReadOnlyList<string> GetRootDirectories()
{
    int count = ReadPositiveInteger(
        "How many root directories? ");

    var directories = new List<string>(count);

    Console.WriteLine();

    for (int i = 0; i < count; i++)
    {
        while (true)
        {
            Console.Write($"Root directory {i + 1}: ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(
                    "Directory path cannot be empty.");

                continue;
            }

            string path = input.Trim();

            if (!TryGetFullPath(path, out string? fullPath))
            {
                Console.WriteLine(
                    "Invalid directory path.");

                continue;
            }

            if (directories.Contains(
                    fullPath,
                    StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    "This directory has already been added.");

                continue;
            }

            if (!Directory.Exists(fullPath))
            {
                Console.WriteLine(
                    "This directory does not exist.");

                if (!ReadYesNo(
                        "Use this path anyway? (y/n): "))
                {
                    continue;
                }
            }

            directories.Add(fullPath);
            break;
        }
    }

    return directories;
}


static IReadOnlySet<string> GetExcludedDirectories()
{
    int count = ReadNonNegativeInteger(
        "How many directories should be excluded? ");

    var directories = new HashSet<string>(
        StringComparer.OrdinalIgnoreCase);

    if (count == 0)
        return directories;

    Console.WriteLine();

    for (int i = 0; i < count; i++)
    {
        while (true)
        {
            Console.Write($"Excluded directory {i + 1}: ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(
                    "Directory cannot be empty.");

                continue;
            }

            string directory = input.Trim();

            directories.Add(directory);
            break;
        }
    }

    return directories;
}


static bool GetThrowOnMissingRoot()
{
    return ReadYesNo(
        "Throw an error when a root directory is missing? (y/n): ");
}


static int ReadPositiveInteger(string message)
{
    while (true)
    {
        Console.Write(message);

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value) && value > 0)
            return value;

        Console.WriteLine(
            "Please enter a number greater than zero.");

        Console.WriteLine();
    }
}


static int ReadNonNegativeInteger(string message)
{
    while (true)
    {
        Console.Write(message);

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value) && value >= 0)
            return value;

        Console.WriteLine(
            "Please enter zero or a positive number.");

        Console.WriteLine();
    }
}


static bool ReadYesNo(string message)
{
    while (true)
    {
        Console.Write(message);

        string? input = Console.ReadLine();

        switch (input?.Trim().ToLowerInvariant())
        {
            case "y":
            case "yes":
                return true;

            case "n":
            case "no":
                return false;

            default:
                Console.WriteLine(
                    "Please enter 'y' or 'n'.");

                Console.WriteLine();
                break;
        }
    }
}


static bool TryGetFullPath(
    string path,
    out string? fullPath)
{
    try
    {
        fullPath = Path.GetFullPath(path);
        return true;
    }
    catch (ArgumentException)
    {
        fullPath = null;
        return false;
    }
    catch (NotSupportedException)
    {
        fullPath = null;
        return false;
    }
    catch (PathTooLongException)
    {
        fullPath = null;
        return false;
    }
}


static void ReplaceLastLines(
    string newText,
    int oldLineCount = 13)
{
    int startLine = Math.Max(
        0,
        Console.CursorTop - oldLineCount);

    int width = Console.WindowWidth;

    for (int i = 0; i < oldLineCount; i++)
    {
        int targetLine = startLine + i;

        if (targetLine >= Console.BufferHeight)
            break;

        Console.SetCursorPosition(0, targetLine);
        Console.Write(new string(' ', width));
    }

    Console.SetCursorPosition(0, startLine);
    Console.Write(newText);
}