using Lab3;

Console.WriteLine("Please, enter a line to encode");
var inputLine = Console.ReadLine();
var code = new HuffmanCode(inputLine);
Console.WriteLine("Codes table:");
foreach (var keyValuePair in code.Codes)
{
    Console.WriteLine($"{keyValuePair.Key}\t{keyValuePair.Value}");
}
Console.WriteLine($"Encoded line: {code.EncodedString}");
Console.WriteLine($"Decoded line: {code.DecodedString}");