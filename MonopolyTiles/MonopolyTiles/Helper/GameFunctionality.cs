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
                    if (token.InJail)
                    {
                        TryToGetOutOfJail();
                    }
                    else
                    {
                        do
                        {
                            dice.RollDice();
                            if (dice.NumberOfDoublesInARow > 2)
                            {
                                token.AdvanceTo(30);
                                dice.ToManyDoubles();
                            }
                            else
                            {
                                MovementAndTrack();
                            }
                        } while (dice.IsDouble);
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
            if (pickedCard == "Advance to Go")
            {
                token.AdvanceTo(0);
            }
            else if (pickedCard == "Go To Jail")
            {
                token.AdvanceTo(30);
            }
            else if (pickedCard == "Advance to Illinois Avenue")
            {
                token.AdvanceTo(24);
            }
            else if (pickedCard == "Advance to St Charles Place")
            {
                token.AdvanceTo(11);
            }
            else if (pickedCard == "Nearest Utility")
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
            else if (pickedCard == "Nearest Railroad")
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
            else if (pickedCard == "Go Back Three Spaces")
            {
                token.Advance(-3);
            }
            else if (pickedCard == "Advance to Reading Railroad")
            {
                token.AdvanceTo(5);
            }
            else if (pickedCard == "Advance to Board Walk")
            {
                token.AdvanceTo(39);
            }
        }
        public void DrawCommunityChestCard()
        {
            string pickedCard = communityChest.PickCard();
            if (pickedCard == "Advance to Go")
            {
                token.AdvanceTo(0);
            }
            else if (pickedCard == "Go To Jail")
            {
                token.AdvanceTo(30);
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
