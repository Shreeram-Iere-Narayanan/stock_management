using System;

public class StockAdjustmentTransaction : Transaction
{
    public StockAdjustmentTransaction(Stock stock, int quantity) : base(stock, quantity)
    {

    }

    public override void Execute()
    {
        if (_quantity >= 0)
        {
            Success = _stock.AddStock(_quantity);
        }
        else
        {
            Success = _stock.RemoveStock(-_quantity);
        }
        base.Execute();
    }

    public override void PrintSummary()
    {
        Console.Write($"Adjust {SummaryLine}");
        if (!HasExecuted)
        {
            Console.Write("PROCCESSED");
        }
        else if (!Success)
        {
            Console.Write("FAILED");
        }
        Console.WriteLine();
    }
}