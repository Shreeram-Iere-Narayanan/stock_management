using System;

public class StockSaleTransaction : Transaction
{
        public StockSaleTransaction(Stock stock, decimal price, int quantity) : base(stock, quantity)
    {

    }

    public override void Execute()
    {
        Success = _stock.RemoveStock(_quantity);
        base.Execute();
    }
    
    public override void PrintSummary()
    {
        Console.Write($"SELL {SummaryLine}");
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
