using System;
using SplashKitSDK;

public enum MenuOption
{
    BuyStock,
    SellStock,
    QueryStock,
    AdjustStock,
    RegisterNewStockItem,
    PrintTransactionHistory,
    Quit
}

public class Program
{
    public static Warehouse warehouse = new Warehouse();
    public static void Main()
    {
        MenuOption userSelection;
        do
        {
            userSelection = ReadUserOption();
            switch (userSelection)
            {
                case MenuOption.BuyStock:
                PerformBuyStock(warehouse);
                break;

                case MenuOption.SellStock:
                PerformSellStock(warehouse);
                break;

                case MenuOption.QueryStock:
                PerformQueryStock(warehouse);
                break;

                case MenuOption.AdjustStock:
                PerformAdjustStock(warehouse);
                break;

                case MenuOption.RegisterNewStockItem:
                RegisterNewStockItem();
                break;

                case MenuOption.PrintTransactionHistory:
                warehouse.PrintTransactionHistory();
                break;

                case MenuOption.Quit:
                Console.WriteLine("Exiting");
                break;

                default:
                Console.WriteLine("Invalid Input");
                break;
            }
        }
        while (userSelection != MenuOption.Quit);
    }

    private static MenuOption ReadUserOption()
    {
        int option;
        
        Console.WriteLine("");
        Console.WriteLine(@"******MANY STOCK ITEMS******
        1. Buy Stock
        2. Sell Stock
        3. Query Stock
        4. Adjust Stock
        5. Register New Stock
        6. Print Transactions
        7. Quit");

        do
        {
            Console.WriteLine("");
            Console.WriteLine("Make Your Selection from 1 to 7:");

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }

            catch
            {
                Console.WriteLine("Not a Valid Selection");
                option = -1;
            }
        }
        while (option > 7 || option < 1);
        return (MenuOption)(option - 1);
    }

    private static void PerformBuyStock(Warehouse toWarehouse)
    {
        Stock stock = FindStockItem(toWarehouse);
        if (stock == null) 
        return;

        int quantity;
        decimal price;

        Console.WriteLine($"Shares of {stock.name} Bought? ");
        quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Share Price of Item Purchased: ");
        price = Convert.ToInt32(Console.ReadLine());

        StockPurchaseTransaction purchase;
        purchase = new StockPurchaseTransaction(stock, price, quantity);
        warehouse.ExecuteTransaction(purchase);
        warehouse.AddTransaction(purchase);
        purchase.PrintSummary();

    }

    private static void PerformSellStock(Warehouse toWarehouse)
    {
        Stock stock = FindStockItem(toWarehouse);
        if (stock == null)
        return;

        int quantity;
        decimal price;

        Console.WriteLine($"Shares of {stock.name} Sold? ");
        quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Share Price of Item Sold: ");
        price = Convert.ToInt32(Console.ReadLine());

        StockSaleTransaction sale;
        sale = new StockSaleTransaction(stock, price, quantity);
        toWarehouse.ExecuteTransaction(sale);
        warehouse.AddTransaction(sale);
        sale.PrintSummary();
    }

    private static void PerformAdjustStock(Warehouse toWarehouse)
    {
        Stock stock = FindStockItem(toWarehouse);
        if (stock == null)
        return;

        int quantity;

        Console.WriteLine($"Shares of {stock.name} to Adjust? ");
        quantity = Convert.ToInt32(Console.ReadLine());

        StockAdjustmentTransaction adjust;
        adjust = new StockAdjustmentTransaction(stock, quantity);
        toWarehouse.ExecuteTransaction(adjust);
        warehouse.AddTransaction(adjust);
        adjust.PrintSummary();
    }

    private static void PerformQueryStock(Warehouse toWarehouse)
    {
        toWarehouse.PrintSummary();
    }

    public static void RegisterNewStockItem()
    {
        string name = ReadString("Enter the Name of the Stock Purchased: ");
        string code = ReadString("Enter the Code for the Stock Purchased: ");
        int initialLevel = ReadInteger("Enter the Initial Level for the Stock: ");
        Stock stock = new Stock(name, code, initialLevel);
        warehouse.AddStockItem(stock);
    }

    public static Stock FindStockItem(Warehouse fromWarehouse)
    {
        Console.WriteLine("Enter the Code of the Stock: ");
        String code = Console.ReadLine();
        Stock result = fromWarehouse.GetStockItem(code);
        if (result == null)
        {
            Console.WriteLine($"No Item Found Under the Given Code {code}");
        }
        return result;
    }

    public static int ReadInteger(string prompt)
    {
        Console.WriteLine(prompt);
        while (true)
        {
            try
            {
                return Int32.Parse(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Please Enter a Valid Integer");
            }
        }
    }

    public static string ReadString(string prompt)
    {
        Console.WriteLine(prompt);
        while (true)
        {
            try
            {
                return Console.ReadLine();

            }
            catch
            {
                Console.WriteLine("Please Enter a Valid String");
            }
        }
    }
}
