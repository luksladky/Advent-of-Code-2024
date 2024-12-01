namespace CsNotes
{
    public class FileReading
    {
        /// <summary>
        /// File.ReadLines, lazy
        /// </summary>
        /// <param name="fullPath"></param>
        void ReadLines_1(string fullPath)
        {
            foreach (var line in File.ReadAllLines(fullPath))
            {
                ProcessLine(line);
            }
        }

        /// <summary> 
        /// StreamReader, lazy, flexible (encoding, etc)
        /// </summary>
        /// <param name="fullPath"></param>
        void ReadLines_2(string fullPath)
        {
            using var sr = File.OpenText(fullPath);

            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                ProcessLine(line);
            }
        }


        /// <summary> 
        /// StreamReader, lazy, flexible (encoding, etc) + pattern matching
        /// </summary>
        /// <param name="fullPath"></param>
        void ReadLines_3(string fullPath)
        {
            using var sr = File.OpenText(fullPath);

            // { } is match any object -> a non-null value
            while (sr.ReadLine() is { } line)
            {
                ProcessLine(line);
            }
        }

        private void ProcessLine(string? line)
        {
            Console.WriteLine(line);
        }
    }
}
