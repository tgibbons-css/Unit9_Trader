using System.Collections.Generic;

namespace Unit9_Trader.Contracts
{
    public interface ITradeStorage
    {
        void StoreTrades(IEnumerable<TradeRecord> trades);
    }
}