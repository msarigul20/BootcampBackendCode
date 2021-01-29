using System;
using System.Collections.Generic;
using System.Text;

namespace Day5Homework5
{
    interface IGameService
    {
        public void Add(Game game);
        public void Delete(Game game);
        public void Update(Game game);
        public void GetGame(Game game);
        public void GetAllGames();
    }
}
