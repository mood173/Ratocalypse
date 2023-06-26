namespace TeamOdd.Ratocalypse.Card
{
    public class DeckData : CardDataCollection
    {
        public DeckData(params CardData[] cardDataItems) : base(cardDataItems) { }

        public CardData Draw()
        {
            if (Count == 0)
            {
                return null;
            }
            CardData cardData = GetCard(0);
            RemoveCard(0);
            return cardData;
        }
    }
}