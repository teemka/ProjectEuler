namespace ProjectEuler.Problems._001_100._51_60;

public class Problem054 : IProblem
{
    public enum Figure
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush,
    }

    public enum Color
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
    }

    public async Task<string> CalculateAsync(string[] args)
    {
        var lines = await File.ReadAllLinesAsync("Problems/001-100/51-60/Problem054_poker.txt");
        var rounds = lines.Select(line => line.Split(" ").Select(x => new Card(x[0], x[1])).ToArray()).ToArray();

        var player1WinsCount = 0;

        foreach (var round in rounds)
        {
            var player1Hand = new Hand(round[..5]);
            var player2Hand = new Hand(round[5..]);

            var result = player1Hand.CompareTo(player2Hand);

            if (result > 0)
            {
                player1WinsCount++;
            }
        }

        return player1WinsCount.ToString();
    }

    public class Hand : IComparable<Hand>
    {
        private readonly Card[] orderedCards;
        private readonly Card[][] groupedCards;

        public Hand(Card[] cards)
        {
            if (cards.Length != 5)
            {
                throw new ArgumentException("Hand must have 5 cards", nameof(cards));
            }

            if (cards.Distinct().Count() != cards.Length)
            {
                throw new ArgumentException("Cards must be distinct", nameof(cards));
            }

            this.orderedCards = [.. cards.OrderByDescending(x => x.Value)];
            this.groupedCards = this.orderedCards.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).Select(x => x.ToArray()).ToArray();
            this.Figure = this.CalculateFigure();
        }

        public Figure Figure { get; }

        private Figure CalculateFigure()
        {
            var isSameSuit = this.orderedCards.Select(x => x.Color).Distinct().Count() == 1;

            var isStraight = this.orderedCards
                .Zip(this.orderedCards.Skip(1))
                .All(pair => pair.First.Value - 1 == pair.Second.Value);

            if (isSameSuit && isStraight)
            {
                var highestCard = this.orderedCards[0];
                return highestCard.Value == 14
                    ? Figure.RoyalFlush
                    : Figure.StraightFlush;
            }

            var highestGroup = this.groupedCards[0];
            if (highestGroup.Length == 4)
            {
                return Figure.FourOfAKind;
            }

            var secondHighestGroup = this.groupedCards[1];
            if (highestGroup.Length == 3 && secondHighestGroup.Length == 2)
            {
                return Figure.FullHouse;
            }

            if (isSameSuit)
            {
                return Figure.Flush;
            }

            if (isStraight)
            {
                return Figure.Straight;
            }

            return highestGroup.Length switch
            {
                3 => Figure.ThreeOfAKind,
                2 when secondHighestGroup.Length == 2 => Figure.TwoPairs,
                2 => Figure.OnePair,
                _ => Figure.HighCard,
            };
        }

        public int CompareTo(Hand? other)
        {
            if (other == null)
            {
                return 1;
            }

            var figureCompare = this.Figure.CompareTo(other.Figure);
            if (figureCompare != 0)
            {
                return figureCompare;
            }

            for (var i = 0; i < this.groupedCards.Length; i++)
            {
                var thisCard = this.groupedCards[i][0];
                var otherCard = other.groupedCards[i][0];

                var result = thisCard.Value.CompareTo(otherCard.Value);
                if (result != 0)
                {
                    return result;
                }
            }

            return 0;
        }
    }

    public record Card
    {
        public Card(char value, char color)
        {
            this.Value = ParseValue(value);
            this.Color = ParseColor(color);
        }

        public int Value { get; }

        public Color Color { get; }

        private static int ParseValue(char value) => value switch
        {
            'T' => 10,
            'J' => 11,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => int.Parse(value.ToString()),
        };

        private static Color ParseColor(char color) => color switch
        {
            'C' => Color.Clubs,
            'D' => Color.Diamonds,
            'H' => Color.Hearts,
            'S' => Color.Spades,
            _ => throw new ArgumentException("Invalid color"),
        };
    }
}
