using System;
using System.IO;
using System.Reflection;
using Unit9_Trader.AdoNet;
using Unit9_Trader.Contracts;

namespace Unit9_Trader
{
    class Program
    {
        static void Main(string[] args)
        {
            // data file to read from locally
            Stream tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Unit9_Trader.trades.txt");
            // URL to read trade file from
            string tradeURL = "http://faculty.css.edu/tgibbons/trades4.txt";
            //Two different URLs for Restful API
            //string restfulURL = "http://localhost:22359/api/TradeData";
            string restfulURL = "http://unit9trader.azurewebsites.net/api/TradeData";

            ILogger logger = new ConsoleLogger();
            ITradeValidator tradeValidator = new SimpleTradeValidator(logger);

            //These are three different trade providers that read from different sources
            ITradeDataProvider fileTradeDataProvider = new StreamTradeDataProvider(tradeStream, logger);
            ITradeDataProvider urlTradeDataProvider = new URLTradeDataProvider(tradeURL, logger);
            ITradeDataProvider restfulProvider = new RestfulTradeDataProvider(restfulURL, logger);

            ITradeMapper tradeMapper = new SimpleTradeMapper();
            ITradeParser tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            ITradeStorage tradeStorage = new AdoNetTradeStorage(logger);

            TradeProcessor tradeProcessor = new TradeProcessor(fileTradeDataProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}

