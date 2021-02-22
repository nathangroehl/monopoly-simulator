using MonopolyStatistics.Cards;
using MonopolyStatistics.MovementHelper;
using MonopolyStatistics.Tiles;
using MonopolyStatistics.Token;
using System;
using System.Collections.Generic;

namespace MonopolyStatistics.Helper
{
    public class GameFunctionality
    {
        MToken token = new MToken();
        MTiles tile = new MTiles();
        TwoDice dice = new TwoDice();
        CommunityChest communityChest = new CommunityChest();
        Chance chance = new Chance();
        public void RunMonopoly(int numberOfTurns, int numberOfGames)
        {
            int currentGameNum = 0;
            while (currentGameNum < numberOfGames)
            {
                while (token.Turn < numberOfTurns)
                {
                    if (!token.InJail)
                    {
                        do
                        {
                            dice.RollDice();
                            if (dice.NumberOfDoublesInARow < 3)
                            {
                                MovementAndTrack();
                            }
                            else
                            {
                                token.AdvanceTo(30);
                                dice.ToManyDoubles();
                            }
                        } while (dice.IsDouble);
                    } else
                    {
                        TryToGetOutOfJail();
                    }
                    token.EndTurn();
                }
                currentGameNum++;
                dice.NewGameDice();
                token.NewGamesToken();
                chance.NewCards();
                communityChest.NewCards();
            }
            foreach(KeyValuePair<int, int> indivTile in tile.TileOccurences)
            {
                Console.WriteLine($"{100*(decimal)indivTile.Value/token.Moves:0.##}% of the time {tile.TileNames[indivTile.Key]} was landed on");
            }
        }
        public void MovementAndTrack()
        {
            token.Advance(dice.TotalRoll);
            if (token.CheckIfChanceTile())
            {
                DrawChanceCard();
            }
            else if (token.CheckIfCommunityChestTile())
            {
                DrawCommunityChestCard();
            }
            tile.Track(token.TileLocation);
            token.CountMove();
        }
        public void UsedGetOutOfJail()
        {
            token.GetOutOfJail();
            dice.RollDice();
        }
        public void DrawChanceCard()
        {
            string pickedCard = chance.PickCard();
            Dictionary<string, int> advanceTo = new Dictionary<string, int>();
            advanceTo["Advance to Go"] = 0;
            advanceTo["Advance to Reading Railroad"] = 5;
            advanceTo["Advance to St Charles Place"] = 11;
            advanceTo["Advance to Illinois Avenue"] = 24;
            advanceTo["Go To Jail"] = 30;
            advanceTo["Advance to Board Walk"] = 39;
            advanceTo["Nearest Utility"] = 41;
            advanceTo["Nearest Railroad"] = 42;
            advanceTo["Go Back Three Spaces"] = 43;
            if (pickedCard != "")
            {
                int dictValue = advanceTo[pickedCard];
                if (dictValue < 41)
                {
                    token.AdvanceTo(advanceTo[pickedCard]);
                }
                else if (dictValue == 41)
                {
                    if (token.TileLocation < 12 || token.TileLocation > 27)
                    {
                        token.AdvanceTo(12);
                    }
                    else
                    {
                        token.AdvanceTo(28);
                    }
                }
                else if (dictValue == 42)
                {
                    if (token.TileLocation < 5 || token.TileLocation > 34)
                    {
                        token.AdvanceTo(5);
                    }
                    else if (token.TileLocation < 15)
                    {
                        token.AdvanceTo(15);
                    }
                    else if (token.TileLocation < 25)
                    {
                        token.AdvanceTo(25);
                    }
                    else
                    {
                        token.AdvanceTo(35);
                    }
                }
                else if (dictValue == 43)
                {
                    token.Advance(-3);
                }
            }
        }
        public void DrawCommunityChestCard()
        {
            string pickedCard = communityChest.PickCard();
            Dictionary<string, int> advanceTo = new Dictionary<string, int>();
            advanceTo["Advance to Go"] = 0;
            advanceTo["Go To Jail"] = 30;
            if (pickedCard != "")
            {
                token.AdvanceTo(advanceTo[pickedCard]);
            }
        }
        public void TryToGetOutOfJail()
        {
            if (chance.PlayerHasGetOutOfJailCard)
            {
                chance.UseGetOutOfJail();
                UsedGetOutOfJail();
                MovementAndTrack();
            }
            else if (communityChest.PlayerHasGetOutOfJailCard)
            {
                communityChest.UseGetOutOfJail();
                UsedGetOutOfJail();
                MovementAndTrack();
            }
            else
            {
                dice.RollDice();
                if (dice.IsDouble)
                {
                    token.GetOutOfJail();
                    token.ResetCounterTurnsInJail();
                    MovementAndTrack();
                }
                else
                {
                    if (token.CheckTurnsInJail())
                    {
                        token.GetOutOfJail();
                        token.ResetCounterTurnsInJail();
                        MovementAndTrack();
                    }
                }
            }
        }
    }
}
