namespace Lab1;

public static class Task2
{
    public static void Run()
    {
        Console.WriteLine("Please, enter an expression:");
        var expression = Console.ReadLine()!;
        var maxOperand = GetAllPossibleValues(expression)
            .OrderByDescending(operand => operand.Value)
            .First();
        Console.WriteLine($"{maxOperand.Predecessor} = {maxOperand.Value}");
    }
    
    private static List<Operand> GetAllPossibleValues(string input) 
    {
        var result = new List<Operand>();
        var hasDivisionByZeroHappened = false;
        
        for (int i = 0; i < input.Length; i++) 
        {
            if (!input[i].IsOperator()) {
                continue;
            }

            try
            {
                var leftPossibleValues = GetAllPossibleValues(input.Substring(0, i));
                var rightPossibleValues = GetAllPossibleValues(input.Substring(i + 1));

                foreach (var left in leftPossibleValues)
                {
                    foreach (var right in rightPossibleValues)
                    {
                        var val = Evaluate(left, right, input[i]);
                        result.Add(val);
                    }
                }
            }
            catch (DivideByZeroException)
            {
                hasDivisionByZeroHappened = true;
            }
        }
        
        if (!result.Any() && !hasDivisionByZeroHappened) 
        {
            result.Add(new Operand()
            {
                Value = double.Parse(input), 
                Predecessor = input
            });
        }
        return result;
    }

    private static Operand Evaluate(Operand left, Operand right, char op)
    {
        switch (op)
        {
            case '+':
                return left + right;
            case '-':
                return left - right;
            case '*':
                return left * right;
            case '/':
                return left / right;
        }
        throw new InvalidOperationException();
    }

    private static bool IsOperator(this char op) 
    {
        return op is '+' or '-' or '*' or '/';
    }
}