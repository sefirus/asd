namespace Lab1;

public class UndividedItem : Item
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

        itemValue = null;
        return false;
    }
}