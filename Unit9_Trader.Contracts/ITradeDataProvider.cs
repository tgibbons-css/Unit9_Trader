using System.Collections.Generic;

namespace Unit9_Trader.Contracts
{
    public interface ITradeDataProvider
    {
        IEnumerable<string> GetTradeData();
    }
}