using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

            }
        }

        public void PlayerChoiseCard(Player play)
        {
            play.CardsInHands.Push(deck.GetACard());
            //CheckGameRules();
        }

        public void CheckGameRules()
        {
            var sorted = players
                .Where(x => x.SumPoint <= 21)
                .OrderBy(x => x.SumPoint);


            //var last = sorted.Last();

            var loosers = players.Where(x => x.SumPoint > 21);
            var allWinners = sorted.Where(x => x.SumPoint <= 21);


            _gameRuleMessage.PlayerWinMessage(allWinners);
            _gameRuleMessage.PlayerLoseMessage(loosers);


            //if (allWinners.Count() == players.Count)
            //    _gameRuleMessage.PlayersDrawMessage(allWinners);

        }

        public bool DeckIsEmpty() => deck.Count > 0;
    }
}