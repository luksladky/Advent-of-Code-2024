using System.Text.RegularExpressions;

var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
var inputPath = Path.Combine(projectRoot!, "input.txt");

var input  = File.ReadAllText(inputPath);

input = Regex.Replace(input, "don't\\(\\).*?do\\(\\)", "", RegexOptions.Singleline);

var matches = Regex.Matches(input, "mul\\((\\d+),(\\d+)\\)");
int result = 0;
foreach (Match match in matches)
{
    result += int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[1].Value);
}

Console.WriteLine(result);