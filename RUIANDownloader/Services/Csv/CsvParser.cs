using System.Text;

namespace RUIANDownloader.Services.Csv
{

    internal class CsvParser : IDisposable
    {

        private readonly FileStream? _fileStream;


        private readonly StreamReader? _streamReader;


        private readonly char _delimiter;


        private readonly char _quote;


        private readonly bool _ignoreFirstLine;


        public CsvParser(
            string fileName,
            Encoding encoding,
            char delimiter = ',',
            char quote = '"',
            bool ignoreFirstLine = true
        )
        {
            this._delimiter = delimiter;
            this._quote = quote;
            this._ignoreFirstLine = ignoreFirstLine;

            this._fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            this._streamReader = new StreamReader(this._fileStream, encoding);
        }


        internal IEnumerator<string[]> Read()
        {
            if (this._streamReader != null)
            {
                if (this._ignoreFirstLine)
                {
                    this._streamReader.ReadLine();
                }

                string? line;
                while ((line = this._streamReader.ReadLine()) != null)
                {
                    yield return this.ParseLine(line);
                }
            }
        }


        internal void Close()
        {
            this._streamReader?.Close();
            this._fileStream?.Close();
        }


        public void Dispose()
        {
            this._streamReader?.Dispose();
            this._fileStream?.Dispose();
        }


        private string[] ParseLine(string line)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                return [];
            }

            List<string> result = [];

            int i = 0;
            while (true)
            {
                string? cell = this.ParseNextCell(line, ref i);
                if (cell == null)
                {
                    break;
                }
                result.Add(cell);
            }

            return [.. result];
        }


        private string? ParseNextCell(string line, ref int i)
        {
            if (i >= line.Length)
            {
                return null;
            }

            if (line[i] != this._quote)
            {
                return this.ParseNotEscapedCell(line, ref i);
            }
            else
            {
                return this.ParseEscapedCell(line, ref i);
            }
        }


        private string ParseNotEscapedCell(string line, ref int i)
        {
            StringBuilder sb = new();

            while (true)
            {
                if (i >= line.Length)
                {   // return iterator after end of string
                    break;
                }

                if (line[i] == this._delimiter)
                {
                    i++; // return iterator after delimiter
                    break;
                }

                sb.Append(line[i]);
                i++;
            }

            return sb.ToString();
        }


        private string ParseEscapedCell(string line, ref int i)
        {
            StringBuilder sb = new();
            i++; // omit first character (quotation mark)

            while (true)
            {
                if (i >= line.Length)
                {
                    break;
                }

                if (line[i] == this._quote)
                {
                    i++; // ignore quote char

                    if (i >= line.Length)
                    {
                        // quotation mark was closing cell;
                        // return iterator after end of string
                        break;
                    }

                    if (line[i] == this._delimiter)
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
