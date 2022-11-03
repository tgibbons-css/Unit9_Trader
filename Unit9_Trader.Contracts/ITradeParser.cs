using System.Collections.Generic;

namespace Unit9_Trader.Contracts
{
    public interface ITradeParser
    {
        IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData);
    }
}