namespace CodeCalculator
{
    public static class StringExtensions
    {
        private const string Indent = "    "; // 4 spaces = 1 tab

        public static string ShiftTab(string? value, int tabCount = 1)
        {
            if (string.IsNullOrEmpty(value) || tabCount <= 0)
                return value ?? string.Empty;

            // ساخت سریع رشته‌ی فاصله‌ها
            string spaces = string.Concat(Enumerable.Repeat(Indent, tabCount));

            // نرمال‌سازی خط‌پایان‌ها به \n تا مشکل \r\n و \r نداشته باشیم
            string normalized = value.Replace("\r\n", "\n").Replace("\r", "\n");

            // اضافه کردن فاصله بعد از هر \n (نه به آخرین خط خالی)
            string result = spaces + normalized.Replace("\n", "\n" + spaces);

            // اگر رشته با \n تمام شده بود، فاصله‌های اضافی آخر را حذف کن
            if (normalized.EndsWith('\n'))
            {
                result = result[..^spaces.Length];
            }

            return result;
        }
    }
}
