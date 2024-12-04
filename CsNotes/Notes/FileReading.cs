namespace CSUtils.Notes
{
    public class FileReading
    {

        void ReadLines(string fullPath)
        {
            {
                // File.ReadLines, lazy
                foreach (var line in File.ReadAllLines(fullPath))
                {
                    ProcessLine(line);
                }
            }
            {
                // StreamReader, lazy, flexible (encoding, etc)
                using var sr = File.OpenText(fullPath);
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    ProcessLine(line);
                }
            }
            {
                // StreamReader, lazy, flexible (encoding, etc) + pattern matching
                using var sr2 = File.OpenText(fullPath);

                // { } is match any object -> a non-null value
                while (sr2.ReadLine() is { } line2)
                {
                    ProcessLine(line2);
                }
            }
            {
                // StreamReader, lazy, flexible (encoding, etc) + pattern matching
                using var sr3 = File.OpenText(fullPath);

                // { } is match any object -> a non-null value
                while (sr3.ReadLine() is string line3)
                {
                    ProcessLine(line3);
                }
            }
        }

        private void ProcessLine(string? line)
        {
            Console.WriteLine(line);
        }
    }
}
