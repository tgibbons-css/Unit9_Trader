namespace Unit9_Trader.Contracts
{
    public interface ITradeValidator
    {
        bool Validate(string[] tradeData);
    }
}