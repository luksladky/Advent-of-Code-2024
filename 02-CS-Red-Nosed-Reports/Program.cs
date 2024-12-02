

var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
var inputPath = Path.Combine(projectRoot!, "input.txt");

int totalSafe = 0;

bool Check(List<int> level)
{
    if (level.Count < 2)
        return false;

    bool isIncreasing = level[0] < level[1];

    int prev = level[0];
    for (int i = 1; i < level.Count; i++)
    {
        if (level[i] == prev)
            return false;

        if (isIncreasing && level[i] < prev)
            return false;

        if (!isIncreasing && level[i] > prev)
            return false;

        if (Math.Abs(level[i] - prev) > 3)
            return false;

        prev = level[i];
    }

    return true;
}

bool IsSafe(List<int> level)
{
    // part 1
    if (Check(level)) 
        return true;

    // part 2
    for (int removedIdx = 0; removedIdx < level.Count; removedIdx++)
    {
        if (Check(level.Where((record, idx) => idx != removedIdx).ToList()))
            return true;
    }

    return false;
}


using var sr = new StreamReader(inputPath);
while (sr.ReadLine() is string line)
{
    var level = line.Split(' ').Select(int.Parse).ToList();

    if (IsSafe(level))
    {
        totalSafe++;
    }
}

Console.WriteLine($"Total safe: {totalSafe}");