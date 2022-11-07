namespace Lab1;

public class DividedItem : Item
{
    public override bool TryGetItemValue(double availableSpace, out ItemValue itemValue)
    {
        if (availableSpace >= Weight)
        {
            itemValue = new ItemValue()
            {
                ResultPrice = Price,
                ResultWeight = Weight,
                ParentItem = this
            };
            return true;
        }

        itemValue = new ItemValue()
        {
            ResultPrice = availableSpace / Weight * Price,
            ResultWeight = availableSpace,
            ParentItem = this
        };
        return true;
    }
}