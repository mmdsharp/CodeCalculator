namespace CodeCalculator
{
    internal class SumFilePropertyGroup
    {
        public string Key { get; set; }
        public SumFileProperty SumFileProperty { get; set; }

        public static List<SumFilePropertyGroup> GroupByExtension(SumFileProperty sumFileProperty)
        {
            var groups = sumFileProperty.Files.GroupBy(f => GetExtension(f.FileName)).ToList();

            var result = new List<SumFilePropertyGroup>();
            foreach (var group in groups)
            {
                var item = new SumFilePropertyGroup()
                {
                    Key = group.Key,
                    SumFileProperty = new(group.ToList())
                };
            }

            return result;
        }

        private static string GetExtension(string fileName)
        {
            return fileName.Split('.').ToList().Last();
        }
    }
}
