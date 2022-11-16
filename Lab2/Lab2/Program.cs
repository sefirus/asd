using Lab2;

InputOutput.PrintMenu();
while (true)
{
    var task = InputOutput.Input("Please, enter a command");
    InputOutput.BoldLine();
    switch (task)
    {
        case 1:
        {
            var opts = new WeightOptions();
            Task1.Run(opts.GetMaxLateness);
            break;
        }
        case 2:
        {
            var opts = new WeightOptions();
            Task1.Run(opts.GetTotalLateness);
            break;
        }
        case 3:
            Task2.Run();
            break;
        case 4:
            InputOutput.PrintMenu();
            break;
        case 0:
            return;
    }
    InputOutput.BoldLine();
}