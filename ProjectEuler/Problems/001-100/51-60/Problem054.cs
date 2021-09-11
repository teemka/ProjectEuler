﻿namespace ProjectEuler.Problems._001_100._51_60;

public class Problem054 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var textFile = await File.ReadAllTextAsync("Problems/001-100/51-60/Problem054_poker.txt");

        int player1WinsCount = 0;
        int player2WinsCount = 0;

        var rounds = textFile.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
        foreach (var round in rounds)
        {
            var cards = round.Split(" ").Select(x => new Card(x[0], x[1])).ToArray();
            var player1Hand = new Hand(cards.Take(5).ToArray());
            var player2Hand = new Hand(cards.Skip(5).ToArray());
            if (player1Hand.Figure > player2Hand.Figure)
            {
                player1WinsCount++;
            }
            else if (player1Hand.Figure == player2Hand.Figure)
            {
                if (player1Hand.HighestValueInFigure > player2Hand.HighestValueInFigure)
                {
                    player1WinsCount++;
                }
                else if (player1Hand.HighestValueInFigure < player2Hand.HighestValueInFigure)
                {
                    player2WinsCount++;
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (player1Hand.OrderedCards[i].Value > player2Hand.OrderedCards[i].Value)
                        {
                            player1WinsCount++;
                            break;
                        }
                        else if (player1Hand.OrderedCards[i].Value == player2Hand.OrderedCards[i].Value)
                        {
                            continue;
                        }
                        else
                        {
                            player2WinsCount++;
                            break;
                        }
                    }
                }
            }
            else
                player2WinsCount++;
        }

        return player1WinsCount.ToString();
    }

    public class Hand
    {
        public Hand(Card[] cards)
        {
            Cards = cards;
            OrderedCards = cards.OrderByDescending(x => x.Value).ToArray();
            Figure = CalculateValue(out var hc, out var hvif);
            HighestCard = hc;
            HighestValueInFigure = hvif;
        }

        public Card[] Cards { get; }
        public Card[] OrderedCards { get; }
        public Figure Figure { get; }
        public int HighestValueInFigure { get; }
        public Card HighestCard { get; }

        public Figure CalculateValue(out Card highestCard, out int highestValueInFigure)
        {
            bool isSameSuit = Cards.All(x => x.Color == Cards[0].Color);

            var isStraight = OrderedCards
                .Zip(OrderedCards.Skip(1), (x, y) => (x, y))
                .All(pair => pair.x.Value - 1 == pair.y.Value);

            highestCard = OrderedCards.First();
            highestValueInFigure = highestCard.Value;

            var groupsByValue = Cards.GroupBy(x => x.Value);
            if (isSameSuit && isStraight)
            {
                if (highestCard.Value == 14)
                    return Figure.RoyalFlush;
                return Figure.StraightFlush;
            }
            var groups = Cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count());
            var highestGroupCount = groups.Select(x => x.Count()).First();
            if (highestGroupCount == 4)
            {
                highestValueInFigure = groups.Take(1).SelectMany(x => x).First().Value;
                return Figure.FourOfAKind;
            }
            var secondHighestGroupCount = groups.Select(x => x.Count()).Skip(1).First();
            if (highestGroupCount == 3 && secondHighestGroupCount == 2)
                return Figure.FullHouse;
            if (isSameSuit)
                return Figure.Flush;
            if (isStraight)
                return Figure.Straight;
            if (highestGroupCount == 3)
            {
                highestValueInFigure = groups.Take(1).SelectMany(x => x).First().Value;
                return Figure.ThreeOfAKind;
            }
            if (highestGroupCount == 2 && secondHighestGroupCount == 2)
            {
                highestValueInFigure = groups.Take(2).SelectMany(x => x).OrderByDescending(x => x.Value).First().Value;
                return Figure.TwoPairs;
            }
            if (highestGroupCount == 2)
            {
                highestValueInFigure = groups.Take(1).SelectMany(x => x).First().Value;
                return Figure.OnePair;
            }

            return Figure.HighCard;
        }
    }

    public class Card
    {
        public Card(char value, char color)
        {
            Value = value switch
            {
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => int.Parse(value.ToString())
            };
            Color = color;
        }

        public int Value { get; }
        public char Color { get; }
    }

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
        RoyalFlush
    }
}
