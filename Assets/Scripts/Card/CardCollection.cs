using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TeamOdd.Ratocalypse.Card
{
    public class CardCollection : IEnumerable<CardData>
    {
        protected readonly List<CardData> _cardList;

        public CardCollection(params CardData[] cardDataItems)
        {
            _cardList = cardDataItems.ToList();
        }

        public int Count { get => _cardList.Count; }

        public CardData GetCard(int index)
        {
            return _cardList[index];
        }

        public void AddCard(CardData cardData)
        {
            _cardList.Add(cardData);
        }

        public void AddCards(params CardData[] cardDataItems)
        {
            foreach (CardData cardData in cardDataItems)
            {
                AddCard(cardData);
            }
        }
        public void RemoveCard(int index)
        {
            _cardList.RemoveAt(index);
        }

        public void RemoveCards(ISet<int> indices)
        {
            SortedSet<int> sortedIndices = new SortedSet<int>(indices);
            foreach (int i in sortedIndices.Reverse())
            {
                _cardList.RemoveAt(i);
            }
        }

        public IEnumerator<CardData> GetEnumerator()
        {
            return _cardList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}