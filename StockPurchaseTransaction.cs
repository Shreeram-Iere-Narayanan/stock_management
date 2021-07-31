using System;

public class StockPurchaseTransaction : Transaction
{
    public StockPurchaseTransaction(Stock stock, decimal price, int quantity) : base(stock, quantity)
    {

    }

    public override void Execute()
    {
        Success = _stock.AddStock(_quantity);
        base.Execute();
    }
    
    public override void PrintSummary()
    {
        Console.WriteLine($"BUY {SummaryLine}");
        if (!HasExecuted)
        {
            Console.WriteLine("PROCCESSED");
        }
        else if (!Success)
        {
            Console.WriteLine("FAILED");
        }
        Console.WriteLine();
    }
}
