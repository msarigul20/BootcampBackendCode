using System.Collections.Generic;

namespace Day5Homework5
{
    class GameManager:IGameService
    {
        List<Game> gameList = new List<Game>();

        public void Add(Game game)
        {
            gameList.Add(game);
            System.Console.WriteLine(game.Name+ " added the system.");
        }
         public void Delete(Game game)
        {
            gameList.Remove(game);
            System.Console.WriteLine(game.Name+ " deleted the system.");
        }

        public void Update(Game game)
        {
            System.Console.WriteLine(game.Name + " updated the system.");
        }

        public void GetGame(Game game)
        {
            System.Console.WriteLine("Game Name: " + game.Name);
            System.Console.WriteLine("Game Publisher: " + game.Publisher);
            System.Console.WriteLine("Game Release Date: " + game.ReleaseDate);
            System.Console.WriteLine("Game Price: " + game.Price);
        }

        public void GetAllGames()
        {
            System.Console.WriteLine("**************** GAME LİST ***************");
            foreach (var game in gameList) {
                System.Console.WriteLine("Game Name: " + game.Name);
                System.Console.WriteLine("Game Publisher: " + game.Publisher);
                System.Console.WriteLine("Game Release Date: " + game.ReleaseDate);
                System.Console.WriteLine("Game Price: " + game.Price);
                System.Console.WriteLine("------------");
            }
            System.Console.WriteLine("******************************************");
        }
    }
    
}
