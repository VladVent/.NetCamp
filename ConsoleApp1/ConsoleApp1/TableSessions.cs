using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    public class TableSessions
    {
        private IGameRuleMessage _gameRuleMessage;
        public Stack<Card> deck = Deck.CreateCards().ShuffleDeck();
        public List<Player> players = new List<Player>();

        public TableSessions() => this._gameRuleMessage = new ConsoleMessagePrinter();

        public void Join(List<Player> a)
        {
            foreach (var VARIABLE in a)
            {
                players.Add(VARIABLE);
            }
        }

        public void DealCard()
        {
            foreach (var p in players)
            {
                p.CardsInHands = deck.DealTheCards();
                p.Skip = false;
            }
        }


        public void SkipPlayersTurn(Player player)
        {
            player.Skip = true;
        }

        public void PlayerChoiseCard(int choise)
        {
            foreach (var p in players)
            {
                if (p.Lost)
                    return;

                switch (choise)
                {
                    case 0:
                        p.CardsInHands.Push(deck.GetACard());
                        break;
                    case 1:
                        SkipPlayersTurn(p);
                        break;
                }
                CheckGameRules();
            }
        }

        public void CheckGameRules()
        {
            var sorted = players
                .Where(x => x.SumPoint <= 21)
                .OrderBy(x => x.SumPoint);

            var last = sorted.Last();

            var loosers = players.Where(x => x.SumPoint > 21);
            var allWinners = sorted.Where(x => x.SumPoint == last.SumPoint);


            _gameRuleMessage.PlayerWinMessage(allWinners);
            _gameRuleMessage.PlayerLoseMessage(loosers);


            if (allWinners.Count() == players.Count)
                _gameRuleMessage.PlayersDrawMessage(allWinners);
        }


        //public void ContinueOrExitGame(int choise, Player player)
        //{
        //    switch (choise)
        //    {
        //        case 0:
        //            DealCard(player);
        //            Console.Clear();
        //            break;
        //        case 1:
        //            break;
        //    }
        //}

        //public void RestartRound()
        //{
        //	deck = Deck.CreateCards().ShuffleDeck();

        //	foreach (var p in players)
        //	{
        //		DealCard(p);
        //	}
        //}

        public bool DeckIsEmpty() => deck.Count > 0;
    }
}