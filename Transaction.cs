using System;

public abstract class Transaction
{
    protected Stock _stock;
    protected decimal _price;
    protected int _quantity;
    protected string _summaryLine;
    private bool _hasExecuted = false;
    private bool _success = false;

    public Stock Stock
    {
        get { return _stock; }
    }

    public decimal Price
    {
        get { return _price; }
    }

    public int Quantity
    {
        get { return _quantity; }
    }

    public string SummaryLine
    {
        get { return _summaryLine; }
    }

    public bool HasExecuted
    {
        get
        {
            return _hasExecuted;
        }
    }

    public bool Success
    {
        get
        {
            return _success;
        }
        set
        {
            _success = value;
        }
    }

    public Transaction(Stock stock, int quantity)
    {
        _stock = stock;
        _quantity = quantity;

    }

    public virtual void Execute()
    {
        if (HasExecuted)
        {
            throw new InvalidOperationException("Executing a Transaction More than Once");
        }
        Console.WriteLine($"Transaction executed on: {DateTime.Now}");
        _summaryLine = $"- {_stock.name} x {_quantity} @ ${_price} = {status()}";
        _hasExecuted = true;
    }

    public abstract void PrintSummary();
    
    public String status()
    {
        if (Success)
        {
            return "Success";
        }
        else
        {
            return "Fail";
        }
    }
}