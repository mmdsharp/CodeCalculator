namespace CodeCalculator.FileFinders;

internal interface IFileFinder
{
    List<FileProperty> GetFiles(FileFinderOptions options);
}
