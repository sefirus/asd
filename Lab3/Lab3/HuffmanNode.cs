namespace Lab3;

public class HuffmanNode
{
    public char? Data { get; set; }
    public int Frequency { get; set; }
    public HuffmanNode? Left { get; set; }
    public HuffmanNode? Right { get; set; }

    public string? GetCode(char symbol, string binaryCode = "")
    {
        if (Data == symbol)
        {
            return binaryCode;
        }
        if (Left is not null)
        {
            var path = Left.GetCode(symbol, binaryCode + "0");
            if (path is not null)
            {
                return path;
            }
        }
        if (Right is not null)
        {
            var path = Right.GetCode(symbol, binaryCode + "1");
            if (path is not null)
            {
                return path;
            }
        }
        return null;
    }
}