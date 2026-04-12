using LosevD_GUN39_GUNPC.Enums;

namespace LosevD_GUN39_GUNPC.Cards
{
   public struct Card
   {
      private readonly Suit _suit;

      private readonly Rank _rank;

      public Suit Suit => _suit;

      public Rank Rank => _rank;

      public Card(Suit suit, Rank rank)
      {
         _suit = suit;
         _rank = rank;
      }
   }
}
