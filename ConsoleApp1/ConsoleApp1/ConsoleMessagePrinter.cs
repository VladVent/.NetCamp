﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;

//namespace ConsoleApp1
//{
//    public class ConsoleMessagePrinter : IGameRuleMessage
//    {
//        public void CleanWin()
//        {
//            Console.WriteLine("GG EZ!!!!");
//        }
//        private static string NamesToSingleString(IEnumerable<Player> enumerable)
//        {
//            return string.Join(",", enumerable.Select(x => x.Name));
//        }

//        public void PlayerLoseMessage(IEnumerable<Player> enumerable)
//        {
           
//            foreach (var p in enumerable)
//            {
//            Console.WriteLine("Loosers:" + NamesToSingleString(enumerable));
//                p.IsDoneTakingCards = true;
//            }
//        }

//        public void PlayerWinMessage(IEnumerable<Player> allWinners)
//        {
//            foreach (var p in allWinners)
//            {
//                if (p.IsDoneTakingCards)
//                {
//                Console.WriteLine("Winners:" + NamesToSingleString(allWinners));
//                p.IsDoneTakingCards = true;
//                }
//                else
//                {
//                    p.IsDoneTakingCards = false;
//                }
//            }
//        }

//        public void PlayersDrawMessage(IEnumerable<Player> allWinners)

//        {
//            Console.WriteLine("Draw:" + NamesToSingleString(allWinners));
//        }
//    }
//}