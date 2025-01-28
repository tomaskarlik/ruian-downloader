using System.Text;

namespace RUIANDownloader.Services.Csv
{

    internal static class CsvParser
    {

        internal static IEnumerator<string[]> Read(
            string fileName,
            Encoding encoding,
            char delimiter = ',',
            char quote = '"',
            bool ignoreFirstLine = true
        )
        {
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs, encoding))
            {
                string? line = ignoreFirstLine ? sr.ReadLine() : null;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return ParseLine(line, delimiter, quote);
                }
                sr.Close();
            }
        }


        private static string[] ParseLine(string line, char delimiter, char quote)
        {
            if (String.IsNullOrEmpty(line))
            {
                return [];
            }

            List<string> result = [];

            int i = 0;
            while (true)
            {
                string? cell = ParseNextCell(line, ref i, delimiter, quote);
                if (cell == null)
                {
                    break;
                }
                result.Add(cell);
            }

            return [.. result];
        }


        private static string? ParseNextCell(string line, ref int i, char delimiter, char quote)
        {
            if (i >= line.Length)
            {
                return null;
            }

            if (line[i] != quote)
            {
                return ParseNotEscapedCell(line, ref i, delimiter);
            }
            else
            {
                return ParseEscapedCell(line, ref i, delimiter, quote);
            }
        }


        private static string ParseNotEscapedCell(string line, ref int i, char delimiter)
        {
            StringBuilder sb = new();

            while (true)
            {
                if (i >= line.Length)
                {   // return iterator after end of string
                    break;
                }

                if (line[i] == delimiter)
                {
                    i++; // return iterator after delimiter
                    break;
                }

                sb.Append(line[i]);
                i++;
            }

            return sb.ToString();
        }


        private static string ParseEscapedCell(string line, ref int i, char delimiter, char quote)
        {
            StringBuilder sb = new();
            i++; // omit first character (quotation mark)

            while (true)
            {
                if (i >= line.Length)
                {
                    break;
                }

                if (line[i] == quote)
                {
                    i++; // ignore quote char

                    if (i >= line.Length)
                    {
                        // quotation mark was closing cell;
                        // return iterator after end of string
                        break;
                    }

                    if (line[i] == delimiter)
                    {
                        // quotation mark was closing cell;
                        // return iterator after delimiter
                        i++;
                        break;
                    }
                }

                sb.Append(line[i]);
                i++;
            }

            return sb.ToString();
        }
    }

}
