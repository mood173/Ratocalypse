namespace TeamOdd.Ratocalypse.Card
{
    public class CardData
    {
        public long CardDataId { get; }
        public CardDataValue DataValue { get; }

        public CardData(long cardDataId)
        {
            CardDataId = cardDataId;
            DataValue = new CardDataValue();
        }

        public CardData(long cardDataId, CardDataValue dataValue) : this(cardDataId)
        {
            DataValue = dataValue;
        }

        public virtual CardData Clone()
        {
            return new CardData(CardDataId, DataValue.Clone());
        }
    }

    public class CardDataValue
    {
        public object ValueA { get; set; } = null;
        public object ValueB { get; set; } = null;
        public object ValueC { get; set; } = null;


        public virtual CardDataValue Clone()
        {
            return new CardDataValue();
        }
    }
}