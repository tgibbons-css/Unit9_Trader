using System;
using System.Collections.Generic;
using System.Text;
using Unit9_Trader.Contracts;

namespace Unit9_Trader
{
    public class URLTradeDataProvider : ITradeDataProvider
    {
        public URLTradeDataProvider(string url, ILogger logger)
        {
        }

        public IEnumerable<string> GetTradeData()
        {
            throw new NotImplementedException();
        }
    }
}
