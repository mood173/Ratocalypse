using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamOdd.Ratocalypse.Card
{
    public class CardOriginData
    {
        private static CardOriginData _instance;

        private readonly Dictionary<long, CardData> _data;

        private CardOriginData()
        {
            _data = new Dictionary<long, CardData>();
        }

        public static CardOriginData Instance => _instance ??= new CardOriginData();

        public int Count => _data.Count;

        public bool AddData(CardData data)
        {
            if (_data.ContainsKey(data.CardDataId))
            {
                return false;
            }
            _data[data.CardDataId] = data;
            return true;
        }

        public bool AddData(Func<CardData> generator)
        {
            return AddData(generator());
        }

        public bool RemoveData(long id)
        {
            return _data.Remove(id);
        }

        public bool RemoveData(CardData cardData)
        {
            return RemoveData(cardData.CardDataId);
        }

        public bool RemoveDataBy(Func<CardData, bool> filter)
        {
            bool ret = true;
            foreach (CardData data in _data.Values.Where(filter))
            {
                ret &= _data.Remove(data.CardDataId);
            }
            return ret;
        }

        public TCardData GetData<TCardData>(long id) where TCardData : CardData
        {
            if (!_data.ContainsKey(id))
            {
                return null;
            }
            CardData data = _data[id];
            if (data is not TCardData cardData)
            {
                throw new InvalidCastException("Cannot cast");
            }
            return cardData;
        }
    }
}