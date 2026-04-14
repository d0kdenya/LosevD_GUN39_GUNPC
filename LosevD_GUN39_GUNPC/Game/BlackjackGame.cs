using LosevD_GUN39_GUNPC.Cards;
using LosevD_GUN39_GUNPC.Enums;

namespace LosevD_GUN39_GUNPC.Game
{
   public sealed class BlackjackGame : CasinoGameBase
   {
      private Queue<Card> _deck = new Queue<Card>();

      private int _cardCount = 0;

      public BlackjackGame(int cardCount)
      {
         if (cardCount < 4 || cardCount > 56)
         {
            _cardCount = 56;
         }
         else
         {
            _cardCount = cardCount;
         }

         FactoryMethod();
      }

      public override void PlayGame()
      {
         FactoryMethod();

         int playerScore = 0;
         int computerScore = 0;

         Card cardOne = _deck.Dequeue();
         Card cardTwo = _deck.Dequeue();
         Card cardThree = _deck.Dequeue();
         Card cardFour = _deck.Dequeue();

         playerScore += GetCardScore(playerScore, cardOne);

         Console.WriteLine($"Player draws: {cardOne.Suit} {cardOne.Rank}");
         Console.WriteLine($"Player draws: {cardTwo.Suit} {cardTwo.Rank}");

         playerScore += GetCardScore(playerScore, cardTwo);

         Console.WriteLine($"Computer draws: {cardThree.Suit} {cardThree.Rank}");
         Console.WriteLine($"Computer draws: {cardFour.Suit} {cardFour.Rank}");

         computerScore += GetCardScore(computerScore, cardThree);
         computerScore += GetCardScore(computerScore, cardFour);

         while (playerScore != computerScore
               && playerScore < 21
               && computerScore < 21
               && _deck.Count >= 2)
         {
            Card cardOneNext = _deck.Dequeue();
            Card cardTwoNext = _deck.Dequeue();

            Console.WriteLine($"Player draws: {cardOneNext.Suit} {cardOneNext.Rank}");
            Console.WriteLine($"Computer draws: {cardTwoNext.Suit} {cardTwoNext.Rank}");

            playerScore += GetCardScore(playerScore, cardOneNext);
            computerScore += GetCardScore(computerScore, cardTwoNext);
         }

         Console.WriteLine("Final score: ");
         Console.WriteLine($"Player - {playerScore} : Computer - {computerScore}");

         CheckResult(playerScore, computerScore);
      }

      protected override void FactoryMethod()
      {
         List<Card> cards = GenerateDeck();

         Shuffle(cards);
      }

      private List<Card> GenerateDeck()
      {
         List<Card> cards = new List<Card>();

         foreach (Suit suit in Enum.GetValues<Suit>())
         {
            foreach (Rank rank in Enum.GetValues<Rank>())
            {
               cards.Add(new Card(suit, rank));
            }
         }

         return cards;
      }
      private void Shuffle(List<Card> cards)
      {
         for (int i = 0; i < cards.Count; i++)
         {
            int j = Random.Shared.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
         }

         _deck = new Queue<Card>(cards.Take(_cardCount));
      }

      private void CheckResult(int playerScore, int computerScore)
      {
         if (playerScore > 21 && computerScore > 21)
         {
            OnDrawInvoke();
            return;
         }

         if (playerScore <= 21 && (computerScore > 21 || computerScore < playerScore))
         {
            OnWinInvoke();
         }
         else if (computerScore <= 21 && (playerScore > 21 || playerScore < computerScore))
         {
            OnLooseInvoke();
         }
         else
         {
            OnDrawInvoke();
         }
      }

      private int GetCardScore(int playerScore, Card card)
      {
         switch (card.Rank)
         {
            case Rank.One:
               return 1;
            case Rank.Two:
               return 2;
            case Rank.Three:
               return 3;
            case Rank.Four:
               return 4;
            case Rank.Five:
               return 5;
            case Rank.Six:
               return 6;
            case Rank.Seven:
               return 7;
            case Rank.Eight:
               return 8;
            case Rank.Nine:
               return 9;
            case Rank.Ten:
               return 10;
            case Rank.Jack:
               return 10;
            case Rank.Queen:
               return 10;
            case Rank.King:
               return 10;
            case Rank.Ace:
               if (playerScore + 11 > 21)
               {
                  return 1;
               }
               else
               {
                  return 11;
               }
            default:
               return 0;
         }
      }
   }
}
