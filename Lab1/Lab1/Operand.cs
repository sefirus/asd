namespace Lab1;

public class Operand
{
    public double Value { get; set; }
    public string Predecessor { get; set; }

    public static Operand operator +(Operand left, Operand right)
    {
        return new Operand()
        {
            Value = left.Value + right.Value,
            Predecessor = $"({left.Predecessor} + {right.Predecessor})"
        };
    }
    
    public static Operand operator -(Operand left, Operand right)
    {
        return new Operand()
        {
            Value = left.Value - right.Value,
            Predecessor = $"({left.Predecessor} - {right.Predecessor})"
        };
    }
    
    public static Operand operator *(Operand left, Operand right)
    {
        return new Operand()
        {
            Value = left.Value * right.Value,
            Predecessor = $"({left.Predecessor} * {right.Predecessor})"
        };
    }
    
    public static Operand operator /(Operand left, Operand right)
    {
        if (right.Value == 0)
            throw new DivideByZeroException();
        return new Operand()
        {
            Value = left.Value / right.Value,
            Predecessor = $"({left.Predecessor} / {right.Predecessor})"
        };
    }
}