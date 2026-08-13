using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [StaticUnload]
    public static class CurrencyController
    {
        private static Currency[] currencies;
        public static Currency[] Currencies => currencies;

        private static Dictionary<CurrencyType, int> currenciesLink;
        private static bool isInitialized;

        public static void Init(CurrencyDatabase currenciesDatabase)
        {
            if (isInitialized) return;

            // Store active currencies
            currencies = currenciesDatabase.Currencies;

            // Initialize currencies
            foreach (Currency currency in currencies)
            {
                currency.Init();
            }

            CurrencyRemoteConfigData remoteConfigData = RemoteConfigController.TryGetConfig<CurrencyRemoteConfigData>("currencies");

            currenciesLink = new Dictionary<CurrencyType, int>();

            for (int i = 0; i < currencies.Length; i++)
            {
                if (!currenciesLink.ContainsKey(currencies[i].CurrencyType))
                {
                    currenciesLink.Add(currencies[i].CurrencyType, i);
                }
                else
                {
                    Debug.LogError(string.Format("[Currency Syste]: Currency with type {0} added to database twice!", currencies[i].CurrencyType));
                }

                Currency.Save save = SaveController.GetSaveObject<Currency.Save>("currency" + ":" + (int)currencies[i].CurrencyType);
                if (save.Amount == -1)
                {
                    int defaultAmount = currencies[i].DefaultAmount;

                    if (remoteConfigData != null)
                    {
                        CurrencyRemoteConfigData.Currency currencyOverride = remoteConfigData.GetCurrencyOverride(currencies[i].CurrencyType);
                        if (currencyOverride != null)
                        {
                            defaultAmount = currencyOverride.defaultCount;
                        }
                    }

                    save.Amount = defaultAmount;
                }

                currencies[i].SetSave(save);
            }

            isInitialized = true;
        }

        public static Currency GetCurrency(CurrencyType currencyType)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                ProjectInitSettings projectInitSettings = RuntimeEditorUtils.GetAsset<ProjectInitSettings>();
                if (projectInitSettings != null)
                {
                    CurrencyInitModule currencyInitModule = projectInitSettings.GetModule<CurrencyInitModule>();
                    if (currencyInitModule != null)
                    {
                        CurrencyDatabase currencyDatabase = currencyInitModule.Database;
                        if (currencyDatabase != null)
                        {
                            return currencyDatabase.Currencies.Find(x => x.CurrencyType.Equals(currencyType));
                        }
                    }
                }

                return null;
            }
#endif

            return currencies[currenciesLink[currencyType]];
        }
    }

    public delegate void CurrencyCallback(Currency currency, int difference);

}