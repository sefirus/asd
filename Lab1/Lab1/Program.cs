// See https://aka.ms/new-console-template for more information

using Lab1;

InputOutput.PrintMenu();
while (true)
{
    var task = InputOutput.Input("Please, enter a command");
    InputOutput.BoldLine();
    switch (task)
    {
        case 1:
            Task1.ForUndivided();
            break;
        case 10:
            Task1.ForDivided();
            break;
        case 2:
            Task2.Run();
            break;
        case 31:
            Task3.Run(Task3.GetAreaWorth);
            break;
        case 32:
            Task3.Run(Task3.GetDiagonalLengthWorth);
            break;
        case 4:
            InputOutput.PrintMenu();
            break;
        case 0:
            return;
    }
    InputOutput.BoldLine();
}