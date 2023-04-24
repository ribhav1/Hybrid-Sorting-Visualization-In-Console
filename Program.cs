Console.WriteLine("How many bars would you like?");
int numOfBars = int.Parse(Console.ReadLine());

Console.WriteLine("What is the max bar height you would like?");
int maxBarHeight = int.Parse(Console.ReadLine() + "\n");

List<int> barHeights = new List<int>();

Random random = new Random();

for (int i = 1; i <= numOfBars; i++)
{
    barHeights.Add(random.Next(1, maxBarHeight + 1));
}

//int currentHeight = 0;

/*foreach (int barHeight in barHeights)
{
    int previousHeight = currentHeight;

    if (barHeight > previousHeight)
    {
        currentHeight = barHeight;
    }
}*/

List<List<int>> rows = new List<List<int>>();

int currentHeight = maxBarHeight;

int highlightIndex = 0;

void drawBars(int currentHeight, List<int> barHeights, List<List<int>> rows)
{

    while (currentHeight > 0)
    {
        int tempSortIndex = 0;

        List<int> row = new List<int>();

        foreach (int height in barHeights)
        {
            if (currentHeight - height > 0)
            {
                Console.Write("      ");
                row.Add(0);
            }
            else if (currentHeight - height <= 0)
            {
                if (tempSortIndex == highlightIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("#     ", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("#     ");
                }

                row.Add(1);
            }
            tempSortIndex++;
        }
        rows.Add(row);
        Console.WriteLine("\n");
        currentHeight--;
    }
}

/*void printRowData(List<List<int>> rows)
{
    int rowIndex = 1;

    foreach (List<int> row in rows)
    {
        Console.WriteLine($"Row {rowIndex}");

        foreach (int space in row)
        {
            Console.Write($"{space} ");
        }

        Console.WriteLine("\n");

        rowIndex++;
    }
}*/

drawBars(currentHeight, barHeights, rows);
//printRowData(rows);

bool sorting = true;

while (sorting)
{
    for (int i = 0; i < barHeights.Count; i++)
    {
        if (i != barHeights.Count - 1)
        {
            int currentBarHeight = barHeights[i];
            int nextBarHeight = barHeights[i + 1];
            if (currentBarHeight > nextBarHeight)
            {

                int sortIndex = i + 1;
                highlightIndex = sortIndex;

                while (barHeights[sortIndex] < barHeights[sortIndex - 1])
                {
                    Console.Clear();
                    drawBars(currentHeight, barHeights, rows);
                    int tempUpperVal = barHeights[sortIndex - 1];

                    barHeights[sortIndex - 1] = barHeights[sortIndex];
                    barHeights[sortIndex] = tempUpperVal;
                    if (sortIndex - 2 >= 0)
                    {
                        sortIndex--;
                        highlightIndex = sortIndex;
                    }
                    Thread.Sleep(250);
                    Console.Clear();
                    drawBars(currentHeight, barHeights, rows);
                }
            }
            Thread.Sleep(500);
        }
    }

    sorting = false;
}

Console.WriteLine("Sorting Finished");