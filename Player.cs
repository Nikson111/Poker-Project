using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    abstract class Player
    {
        #region Properties
        public string Name { get; set; }

        public Card[] Hand { get; set; }

        public int HandRank { get; set; }

        public string[] CardHierarchy { get; set; }

        public bool WinStatus { get; set; }

        public int Wins { get; set; }
        #endregion

        #region Constructors
        public Player()
        {
            ToDefaultValues();
            Wins = 0;
        }
        #endregion

        #region Methods
        public void SetCard(int index, Card card)
        {
            Hand[index] = card;
        }

        public void ToDefaultValues()
        {
            Hand = new Card[5];
            HandRank = 0;
            CardHierarchy = Array.Empty<string>();
            WinStatus = false;
        }
        #endregion
    }
}