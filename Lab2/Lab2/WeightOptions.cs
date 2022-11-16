namespace Lab2;

public class WeightOptions
{
    public double MaxLateness { get; private set; } = double.MinValue;
    public double TotalLateness { get; private set; } = 0;

    public double GetMaxLateness(double currentLateness)
    {
        if (currentLateness > 0 && currentLateness > MaxLateness)
        {
            MaxLateness = currentLateness;
            return MaxLateness;
        }

        return MaxLateness > 0
            ? MaxLateness
            : 0;
    }

    public double GetTotalLateness(double currentLateness)
    {
        if(currentLateness > 0)
        {
            TotalLateness += currentLateness;
        }   
        return TotalLateness;
    }
}


