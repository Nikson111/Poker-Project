using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    class Human : Player
    {
        #region Constructors
        public Human(string name, int playerNum)
        {
            Name = (name != "") ? name : $"Player {playerNum}";
        }
        #endregion
    }
}
