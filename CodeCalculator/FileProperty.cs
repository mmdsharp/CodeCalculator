namespace CodeCalculator
{
    internal class FileProperty
    {
        public FileProperty()
        {

        }

        public FileProperty(string fileName)
        {
            FileName = fileName;
        }

        private void FillCounts()
        {
            string fileContent = File.ReadAllText(FileName);

            AllChars = fileContent.Length;
            Spaces = fileContent.Count(c => c == ' ');
            BreakLines = fileContent.Count(c =>
                c == '\n' || c == '\r');

            LinesCount = fileContent
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Count(c => c == '\n') + 1;
        }

        private string _fileName;

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                FillCounts();
            }
        }


        #region count

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
