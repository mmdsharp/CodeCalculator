namespace CodeCalculator
{
    internal class SumFileProperty
    {
        public SumFileProperty(List<FileProperty> files)
        {
            Files = files;

            FilesCount = files.Count;

            AllChars = files
                .Sum(c => c.AllChars);

            Spaces = files
               .Sum(c => c.Spaces);

            BreakLines = files
               .Sum(c => c.BreakLines);

            LinesCount = files
                .Sum(c => c.LinesCount);
        }

        public SumFileProperty(List<SumFileProperty> files) :
            this(files.SelectMany(f => f.Files)
                .DistinctBy(f => f.FileName.ToLower()).ToList())
        { }

        public List<FileProperty> Files { get; set; }

        #region count
        public int FilesCount { get; set; }
        public long AllChars { get; private set; }
        public long Spaces { get; private set; }
        public long BreakLines { get; private set; }
        public long SpacesAndBreakLines
        {
            get => Spaces + BreakLines;
        }
        public long ExceptSpacesAndBreakLines
        {
            get => AllChars - SpacesAndBreakLines;
        }

        public long LinesCount { get; set; }

        #endregion 
    }
}
