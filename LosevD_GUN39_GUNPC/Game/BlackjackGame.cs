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
         if (cardCount < 4 || cardCount > 52)
         {
            _cardCount = 52;
         }
         else
         {
            _cardCount = cardCount;
         }

         FactoryMethod();
      }

      private void Shuffle()
      {
         List<Card> cards = _deck.ToList();

         for (int i = 0; i < cards.Count; i++)
         {
            int j = Random.Shared.Next(i + 1);

            (cards[i], cards[j]) = (cards[j], cards[i]);
         }

         _deck.Clear();

         foreach (Card card in cards)
         {
            _deck.Enqueue(card);
         }
      }

      public override void PlayGame()
      {
         List<Card> playersCard = new List<Card>();
         List<Card> computersCard = new List<Card>();

         playersCard.Add(_deck.Dequeue());
         playersCard.Add(_deck.Dequeue());

         computersCard.Add(_deck.Dequeue());
         computersCard.Add(_deck.Dequeue());


      }

      protected override void FactoryMethod()
      {
         GenerateDeck();

         Shuffle();

         var finalDeck = _deck.Take(_cardCount).ToList();
      }

      private void GenerateDeck()
      {
         foreach (Suit suit in Enum.GetValues<Suit>())
         {
            foreach (Rank rank in Enum.GetValues<Rank>())
            {
               _deck.Enqueue(new Card(suit, rank));
            }
         }
      }

      private void CheckResult(int playerScore, int computerScore)
      {
         if (playerScore > computerScore)
         {
            OnWinInvoke();
         }
         else if (playerScore < computerScore)
         {
            OnLooseInvoke();
         }
         else
         {
            OnDrawInvoke();
         }
      }
   }
}
