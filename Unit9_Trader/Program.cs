using System;
using System.Reflection;
using Unit9_Trader.AdoNet;

namespace Unit9_Trader
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Unit9_Trader.trades.txt");

            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            var tradeDataProvider = new StreamTradeDataProvider(tradeStream);
            var tradeMapper = new SimpleTradeMapper();
            var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            var tradeStorage = new AdoNetTradeStorage(logger);

            var tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}

