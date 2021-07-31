using System;

public class Stock
{
    private int _quantityOnHand;
    private string _name;
    private string _code;

    public string Code
    {
        get { return _code; }
    }

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    
    public int QuantityOnHand
    {
        get { return _quantityOnHand; }
        set { _quantityOnHand = value; }
    }

    public Stock(string name, string code, int initiallevel)
    {
        _name = name;
        _quantityOnHand = initiallevel;
        _code = code;
    }

    public bool AddStock(int quantityAdded)
    {
       if (quantityAdded>0)
       {
            _quantityOnHand = _quantityOnHand + quantityAdded;
            return true;
       }
       else
       {
           return false;
       }
    }

    public bool RemoveStock(int quantityRemoved)
    {
        if (quantityRemoved > 0 && quantityRemoved < _quantityOnHand)
        {
            _quantityOnHand = _quantityOnHand - quantityRemoved;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PrintSummary()
    {
        Console.WriteLine($"{name}: {QuantityOnHand}");
    }

}