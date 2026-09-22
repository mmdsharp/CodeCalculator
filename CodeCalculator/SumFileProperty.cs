namespace CodeCalculator
{
    internal class SumFileProperty
    {
        public SumFileProperty(List<FileProperty> files)
        {
            Files = files;

            FilesCount = files.Count;

            TotalChars = files
                .Sum(c => c.AllChars);

            Spaces = files
               .Sum(c => c.Spaces);

            BreakLines = files
               .Sum(c => c.BreakLines);

            LinesCount = files
                .Sum(c => c.LinesCount);
        }


        public override string ToString()
        {
            string nl = Environment.NewLine;

            return "File properties:" + nl +
                StringExtensions.ShiftTab(
                    $"Files: {FilesCount}{nl}" +
                    $"Lines: {LinesCount}{nl}" +
                    $"Chars: {TotalChars}{nl}" +
                    "{" + nl +
                    StringExtensions.ShiftTab(
                        $"Spaces/newlines: {SpacesAndBreakLines}{nl}" +
                        $"Other chars:    {NonSpaceChars}{nl}") +
                    $"Averages:{nl}" +
                    StringExtensions.ShiftTab(
                        $"Chars/line:            {AverageCharacterInLine}{nl}" +
                        $"Chars/line (no spaces):{AverageCharacterInLineNonSpaceChars}{nl}")
                );
        }


        public SumFileProperty(List<SumFileProperty> files) :
            this(files.SelectMany(f => f.Files)
                .DistinctBy(f => f.FileName.ToLower()).ToList())
        { }

        public List<FileProperty> Files { get; set; }

        #region count
        public int FilesCount { get; set; }
        public long TotalChars { get; private set; }
        public long Spaces { get; private set; }
        public long BreakLines { get; private set; }
        public long SpacesAndBreakLines
        {
            get => Spaces + BreakLines;
        }
        public long NonSpaceChars
        {
            get => TotalChars - SpacesAndBreakLines;
        }

        public long LinesCount { get; set; }

        public long AverageCharacterInLine
        {
            get => TotalChars / LinesCount;
        }
        public long AverageCharacterInLineNonSpaceChars
        {
            get => NonSpaceChars / LinesCount;
        }

        #endregion 
    }
}
