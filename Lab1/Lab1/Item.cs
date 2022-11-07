namespace Lab1;

public abstract class Item
{
    public double Price { get; set; }
    public double Weight { get; set; }

    public string Tag { get; set; }

    public double GetPriceToWeight()
    {
        var ptw = Price / Weight;
        return ptw;
    }
    public abstract bool TryGetItemValue(double availableSpace, out ItemValue itemValue);
}