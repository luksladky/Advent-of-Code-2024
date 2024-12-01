var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
var inputPath = Path.Combine(projectRoot!, "input.txt");

// a min-heap, if value == priority
var heapA = new PriorityQueue<int, int>();
var heapB = new PriorityQueue<int, int>();

// item -> count
var countB = new Dictionary<int, int>();

foreach (var line in File.ReadLines(inputPath))
{
    var lists = line.Split("   ", StringSplitOptions.TrimEntries);

    // items from list A and B
    var (itemA, itemB) = (int.Parse(lists[0]), int.Parse(lists[1]));
    heapA.Enqueue(itemA, itemA);
    heapB.Enqueue(itemB, itemB);

    // ensure all keys from list A are present
    if (!countB.ContainsKey(itemA))
    {
        countB[itemA] = 0;
    }

    if (!countB.ContainsKey(itemB))
    {
        countB[itemB] = 0;
    }

    countB[itemB]++;
}

int totalDist = 0;
int totalSimilarity = 0;

while (heapA.Count > 0 && heapB.Count > 0)
{
    var itemA = heapA.Dequeue();
    var itemB = heapB.Dequeue();
    
    totalDist += Math.Abs(itemA - itemB);
    totalSimilarity += countB[itemA] * itemA;
}

Console.WriteLine($"Total distance: {totalDist}");
Console.WriteLine($"Total similarity: {totalSimilarity}");