using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    sealed class Rules
    {
        #region Properties
        public int Players { get; set; }

        public int Humans { get; set; }

        public int MaxWins { get; set; }

        public int MinMoney { get; set; }
        #endregion

        #region Constructors
        public Rules()
        {
            Players = 0;
            Humans = 0;
            MaxWins = 0;
            MinMoney = 0;
        }
        #endregion

        #region Methods
        public void SetRules(bool isMultiplayer)
        {
            string input;
            string[] ruleDescription = { "number of players", "number of human players", "target number of wins" };
            int[] minValues = { 2, 2, 3 }, maxValues = { 6, 6, 7 };

            Console.WriteLine("RULES SETTING");
            for (int i = 0; i < ruleDescription.Length; i++)
            {
                if (i == 1 && (!isMultiplayer || (isMultiplayer && minValues[i] == maxValues[i])))
                {
                    // Skip input if the game is not multiplayer or it's multiplayer and only two players will play.
                    Humans = maxValues[i];
                    continue;
                }

                Console.Write($"Enter {ruleDescription[i]} ({minValues[i]}-{maxValues[i]}): ");
                input = Console.ReadLine().Trim();

                if (ValidateRule(input, minValues[i], maxValues[i]))
                {
                    int value = Convert.ToInt32(input);

                    switch (i)
                    {
                        case 0:
                            Players = value;
                            maxValues[i + 1] = isMultiplayer ? value : 1;  // Changing of max value for human players
                            break;
                        case 1:
                            Humans = value;
                            break;
                        case 2:
                            MaxWins = value;
                            break;
                    }
                }
                else
                {
                    // If invalid, decrement the counter to try entering the value again.
                    i--;
                }

                Console.WriteLine();
            }
        }

        private bool ValidateRule(string input, int minValue, int maxValue)
        {
            if (input == "")
            {
                Console.WriteLine("ERROR: Please enter the value.");
                return false;
            }
            else if (!int.TryParse(input, out _))
            {
                Console.WriteLine("ERROR: Invalid value.");
                return false;
            }
            else if (Convert.ToInt32(input) < minValue || Convert.ToInt32(input) > maxValue)
            {
                Console.WriteLine($"ERROR: Value must be between {minValue} and {maxValue}.");
                return false;
            }

            return true;
        }
        #endregion
    }
}