namespace Jmelosegui.Mvc.GoogleMap.Examples
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        private const int IndentSize = 4;

        private const int WrapThreshold = 120;

        private static readonly string NewLine = Environment.NewLine;
        private static readonly int NewLineLength = NewLine.Length;

        public static string WordWrap(this string html)
        {
            // wrap lines
            var lines = html.Split(new[] { NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length <= WrapThreshold)
                {
                    continue;
                }

                var result = new StringBuilder();

                var currentLine = lines[i];

                var currentLineIndentSize = new Regex("^\\s+").Match(currentLine).Length;

                while (currentLine.Length > WrapThreshold)
                {
                    int splitPoint = currentLine.Substring(0, WrapThreshold - IndentSize).LastIndexOf(' ');

                    if (splitPoint < 0)
                    {
                        splitPoint = WrapThreshold; // cuts though code, though
                    }

                    result.Append(currentLine.Substring(0, splitPoint))
                          .Append(NewLine.PadRight(NewLineLength + currentLineIndentSize + IndentSize));

                    currentLine = currentLine.Substring(splitPoint + 1);
                }

                result.Append(currentLine);

                lines[i] = result.ToString();
            }

            return string.Join(NewLine, lines);
        }
    }
}