namespace LosevD_GUN39_GUNPC
{
   internal class Dungeon
   {
      private Room[] _rooms;

      public Dungeon()
      {
         _rooms = new Room[]
         {
         new Room(new Unit("Knight"), new Weapon("Sword", 10, 20)),
         new Room(new Unit("Archer"), new Weapon("Bow", 8, 15)),
         new Room(new Unit("Orc"), new Weapon("Club", 18, 30)),
         new Room(new Unit("Elf"), new Weapon("Staff", 12, 25)),
         new Room(new Unit("Gnome"), new Weapon("Hammer", 7, 12))
         };
      }

      public void ShowRooms()
      {
         for (int i = 0; i < _rooms.Length; i++)
         {
            Room room = _rooms[i];

            Console.WriteLine("Unit of room " + room.Unit);
            Console.WriteLine("Weapon of room " + room.Weapon);
            Console.WriteLine("—");
         }
      }
   }
}
