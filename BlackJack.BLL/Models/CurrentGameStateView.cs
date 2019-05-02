using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class CurrentGameStateView
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public bool IsBot { get; set; }
        public IEnumerable<CardCurentGameStateViewItem> Cards { get; set; }
        public int TotalCount
        {
            get
            {
                int currentSum = Cards.Sum(x => x.Value);

                if (Cards.Where(x => x.Type == "ace").Count() > 0 && currentSum > 21)
                {
                    currentSum = 0;
                    foreach (var i in Cards)
                    {
                        if (i.Type == "ace")
                        {
                            currentSum++;
                        }
                        else
                        {
                            currentSum += i.Value;
                        }
                    }
                    return currentSum;
                }
                return currentSum;
            }
        }
    }

    public class CardCurentGameStateViewItem
    {
        public int CardId { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public string Suit { get; set; }
    }
}
