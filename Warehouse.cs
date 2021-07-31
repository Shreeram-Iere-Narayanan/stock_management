using System;
using System.Collections.Generic;

public class Warehouse
{
    private List<Stock> _stockitems;
    private List<Transaction> _transactions;
    public void AddStockItem(Stock stock)
    {
        _stockitems.Add(stock);
    }
    
    public Warehouse()
    {
        _stockitems = new List<Stock>();
        _transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);

    }
    public Stock GetStockItem(String code)
    {
        foreach (Stock stock in _stockitems)
        {
            if (stock.Code == code)
            return stock;
        }
        return null;
    }

    public void ExecuteTransaction(Transaction transaction)
    {
        transaction.Execute();
    }

    public void PrintSummary()
    {
        Console.WriteLine("All Stocks Listed Below: ");
        _stockitems.ForEach(delegate (Stock stock)
        {
            stock.PrintSummary();
        });
        Console.WriteLine("");
    }

    public void PrintTransactionHistory()
    {
        Console.WriteLine("All Transactions Listed Below: ");
        _transactions.ForEach(delegate (Transaction transaction)
        {
            transaction.PrintSummary();
        });
        Console.WriteLine("");
    }

}