namespace Lab1;

public static class Task1
{
    private static List<UndividedItem> GetItems(string line)
    {
        var result = new List<UndividedItem>();
        var pairs = line.Split(',', StringSplitOptions.TrimEntries);
        foreach (var pair in pairs)
        {
            var values = pair.Replace(",", "").Split(' ', StringSplitOptions.TrimEntries);
            int.TryParse(values[0], out var price);
            int.TryParse(values[1], out var weight);
            var item = new UndividedItem()
            {
                Price = price,
                Weight = weight
            };
            result.Add(item);
        }

        return result;
    }

    private static void InitiateTable(List<List<int>> array, int width, int height)
    {
        array.Clear();
        for (int i = 0; i < height; i++)
        {
            var l = new List<int>();
            for (int j = 0; j < width; j++)
                l.Add(0);
            array.Add(l);
        }
    }
    
    public static void ForUndivided()
    {
        var totalWeight = InputOutput.Input("Please, enter backpack capacity");
        Console.WriteLine("Input prices and weights like: p1 w1, p2 w2, p3 w3");
        var items = GetItems(Console.ReadLine()!);
        items.Insert(0, new UndividedItem(){Price = 0, Weight = 0});
        var worthMatrix = new List<List<int>>();
        InitiateTable(worthMatrix, totalWeight + 1, items.Count +1);
        for(int i = 1; i <= items.Count - 1; i++) // s -номер поточного предмета
        {
            for(int n = 0; n <= totalWeight; n++) // n -вага поточного рюкзака
            {
                worthMatrix[i][n] = worthMatrix[i - 1][n]; //Припускаємо, що s не беремо
                if (items[i].Weight <= n 
                    && worthMatrix[i][n] < items[i].Price + worthMatrix[i - 1][n-(int)items[i].Weight])
                {
                    worthMatrix[i][n] = worthMatrix[i - 1][n - (int)items[i].Weight] + (int)items[i].Price;
                }            
            }
        }
        Console.WriteLine("Items to take:");
        Print(worthMatrix, items, items.Count - 1, totalWeight);
     }
    
    private static void Print(List<List<int>> A, List<UndividedItem> items, int s, int n)
    {
        if (A[s][n]==0) 
            return; 
        if (A[s-1][n] == A[s][n])
            Print(A, items, s - 1,n); 
        else
        {
            Print(A, items, s-1,n - (int)items[s].Weight);
            Console.WriteLine(s); 
        }
    }
    
    private static List<Item> GetAnyItems(string line)
    {
        var result = new List<Item>();
        var pairs = line.Split(',', StringSplitOptions.TrimEntries);
        var iterator = 1;
        foreach (var pair in pairs)
        {
            var values = pair.Replace(",", "").Split(' ', StringSplitOptions.TrimEntries);
            if (values.Length <= 2 || values[2] == "0" || values[2] == "f")
            {
                double.TryParse(values[0], out var undividedPrice);
                double.TryParse(values[1], out var undividedWeight);
                var undividedItem = new UndividedItem()
                {
                    Price = (int)undividedPrice,
                    Weight = (int)undividedWeight,
                    Tag = iterator.ToString()
                };
                result.Add(undividedItem);
            }
            else
            {
                double.TryParse(values[0], out var dividedPrice);
                double.TryParse(values[1], out var dividedWeight);
                var dividedItem = new DividedItem()
                {
                    Price = (int)dividedPrice,
                    Weight = (int)dividedWeight,
                    Tag = iterator.ToString()
                };
                result.Add(dividedItem);
            }

            iterator++;
        }

        return result;
    }
    
    public static void ForDivided()
    {
        var totalWeight = InputOutput.InputDouble("Please, enter backpack capacity");
        Console.WriteLine("Input prices and weights like: p1 w1 1, p2 w2 0, p3 w3 0 | Where 0 for undivided item and 1 for divided");
        var items = GetAnyItems(Console.ReadLine()!)
            .OrderByDescending(item => item.GetPriceToWeight())
            .ToList();
        var resultValues = new List<ItemValue>();
        var capacityLeft = totalWeight;
        foreach (var item in items)
        {
            if (!item.TryGetItemValue(capacityLeft, out var itemValue))
            {
                continue;
            }
            resultValues.Add(itemValue);
            capacityLeft -= itemValue.ResultWeight;
            if (capacityLeft == 0)
            {
                break;
            }
        }

        foreach (var res in resultValues)
        {
            Console.WriteLine(res.ParentItem is UndividedItem
                ? $"Undivided number {res.ParentItem.Tag}, price: {res.ResultPrice}, weight: {res.ResultWeight}"
                : $"Divided number {res.ParentItem.Tag}, price {res.ResultPrice}, weight: {res.ResultWeight} " +
                  $"in proportion: {res.ResultPrice / (res.ParentItem as DividedItem)!.Price}");
        }
    }
}