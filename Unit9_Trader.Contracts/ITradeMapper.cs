namespace Unit9_Trader.Contracts
{
    public interface ITradeMapper
    {
        TradeRecord Map(string[] fields);
    }
}