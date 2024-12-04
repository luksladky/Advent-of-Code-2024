using System.Diagnostics;
using CSUtils;

string input = PuzzleInput.ReadAllText();

string[] rows = input.Trim().Split('\n');
int sizeX = rows[0].Length;
int sizeY = rows.Length;

bool IsOutOfBounds(int x, int y) => x < 0 || y < 0 || x >= sizeX || y >= sizeY;

int total = 0;

for (int startPosX = 0; startPosX < sizeX; startPosX++)
{
    for (int startPosY = 0; startPosY < sizeY; startPosY++)
    {
        // X
        if (rows[startPosX][startPosY] == 'X')
        {
            var directions =
                (from dirX in new[] { -1, 1, 0 }
                 from dirY in new[] { -1, 1, 0 }
                 select (dirX, dirY));

            foreach (var (dirX, dirY) in directions)
            {
                int x = startPosX;
                int y = startPosY;

                //Console.WriteLine($"X [{x},{y}] --> {Pos(x, y)} (dir [{dirX},{dirY}]");

                // M
                (x, y) = (x + dirX, y + dirY);
                if (IsOutOfBounds(x, y))
                    continue;

                //Console.WriteLine($"{input[Pos(x,y)]} [{x},{y}] -> {Pos(x, y)}");
                if (rows[x][y] != 'M')
                    continue;

                // A
                (x, y) = (x + dirX, y + dirY);
                if (IsOutOfBounds(x, y))
                    continue;

                //Console.WriteLine($"{input[Pos(x, y)]} [{x},{y}] -> {Pos(x, y)}");
                if (rows[x][y] != 'A')
                    continue;
                
                // S
                (x, y) = (x + dirX, y + dirY);
                if (IsOutOfBounds(x, y))
                    continue;

                //Console.WriteLine($"{input[Pos(x, y)]} [{x},{y}] -> {Pos(x, y)}");
                if (rows[x][y] != 'S')
                    continue;

                //Console.WriteLine("Here!");
                total++;
            }
        }
    }
}

Console.WriteLine(total);
