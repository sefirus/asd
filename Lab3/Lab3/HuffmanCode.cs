namespace Lab3;

public class HuffmanCode
{
    public string? OriginalString { get; private set; }
    public string EncodedString => GetEncodedString(OriginalString, Codes);
    public string DecodedString => DecodeString(EncodedString, _parentNode);
    private readonly HuffmanNode _parentNode;
    public IReadOnlyDictionary<char, string?> Codes { get; private set; }
    public HuffmanCode(string? inputString)
    {
        OriginalString = inputString;
        var symbolsFrequencies = GetSymbolsFrequencies(inputString);
        var nodeList = ConstructNodes(symbolsFrequencies);
        _parentNode = BuildTree(nodeList);
        Codes = GetCodes(symbolsFrequencies, _parentNode);
    }
    private static List<HuffmanNode> ConstructNodes(Dictionary<char, int> symbols)
    {
        var nodes = symbols.Select(symbol => new HuffmanNode()
            {
                Data = symbol.Key, 
                Frequency = symbol.Value
            })
            .ToList();
        return nodes;
    }

    private static Dictionary<char, int> GetSymbolsFrequencies(string? inputLine)
    {
        if (inputLine is null)
            return new Dictionary<char, int>();
        var symbolFrequencies = inputLine
            .GroupBy(c => c)
            .Select(g => new
            {
                Key = g.Key,
                Freq = g.Count()
            })
            .ToDictionary(
                keySelector: keyFreqPair => keyFreqPair.Key, 
                elementSelector: keyFreqPair => keyFreqPair.Freq);
        
        return symbolFrequencies;
    }

    private static HuffmanNode BuildTree(List<HuffmanNode> treeNodes)
    {
        while (treeNodes.Count > 1)
        {
            treeNodes = treeNodes
                .OrderByDescending(node => node.Frequency)
                .ToList();
            var parent = new HuffmanNode()
            {
                Data = null, 
                Frequency = treeNodes[^2].Frequency + treeNodes[^1].Frequency, 
                Left = treeNodes[^2], 
                Right = treeNodes[^1]
            };
            treeNodes = treeNodes 
                .Take(treeNodes.Count - 2) //All except two last 
                .ToList();
            treeNodes.Add(parent);

        }

        return treeNodes.First();
    }

    private static Dictionary<char, string?> GetCodes (IReadOnlyDictionary<char, int> symbols, HuffmanNode tree)
    {
        var codes = symbols
            .ToDictionary(
                keySelector: symbol => symbol.Key, 
                elementSelector: symbol => tree.GetCode(symbol.Key));
        return codes;
    }

    private static string GetEncodedString(string s, IReadOnlyDictionary<char, string?> codes)
    {
        var encoded = string.Empty;
        foreach (var c in s)
        {
            encoded += codes[c];
        }

        return encoded;
    }

    private static string DecodeString(string encoded, HuffmanNode root)
    {
        var decoded = string.Empty;

        var current = root;
        foreach (var c in encoded)
        {
            if (c == '0')
                current = current?.Left;
            else
                current = current?.Right;

            if (current?.Data is null)
            {
                continue;
            }
            decoded += current.Data;
            current = root;
        }

        return decoded;
    }
}