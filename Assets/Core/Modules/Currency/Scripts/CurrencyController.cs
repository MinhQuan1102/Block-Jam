namespace Core
{
    [StaticUnload]
    public static class CurrencyController
    {
        public static void Init(CurrencyDatabase currenciesDatabase)
        {
            
        }
    }

    public delegate void CurrencyCallback(Currency currency, int difference);

}